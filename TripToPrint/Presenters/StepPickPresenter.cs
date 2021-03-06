using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using TripToPrint.Core;
using TripToPrint.Core.Models;
using TripToPrint.Properties;
using TripToPrint.Services;
using TripToPrint.ViewModels;
using TripToPrint.Views;

namespace TripToPrint.Presenters
{
    public interface IStepPickPresenter : IPresenter<StepPickViewModel, IStepPickView>, IStepPresenter, IDisposable
    {
    }

    public class StepPickPresenter : IStepPickPresenter
    {
        private readonly IGoogleMyMapAdapter _googleMyMapAdapter;
        private readonly IResourceNameProvider _resourceName;
        private readonly IWebClientService _webClient;
        private readonly IDialogService _dialog;
        private readonly IUserSession _userSession;
        private readonly IFileService _file;
        private readonly IKmlFileReader _kmlFileReader;
        private readonly IKmlObjectsTreePresenter _kmlObjectsTreePresenter;

        private readonly List<string> _tempFilesCreated = new List<string>();
        private KmlDocument _kmlDocument;
        private CancellationTokenSource _cancellationTokenSource;

        public StepPickPresenter(IGoogleMyMapAdapter googleMyMapAdapter, IWebClientService webClient,
            IFileService file, IResourceNameProvider resourceName, IDialogService dialog, IUserSession userSession,
            IKmlFileReader kmlFileReader, IKmlObjectsTreePresenter kmlObjectsTreePresenter)
        {
            _googleMyMapAdapter = googleMyMapAdapter;
            _webClient = webClient;
            _file = file;
            _resourceName = resourceName;
            _dialog = dialog;
            _userSession = userSession;
            _kmlFileReader = kmlFileReader;
            _kmlObjectsTreePresenter = kmlObjectsTreePresenter;
        }

        public IStepPickView View { get; private set; }
        public virtual StepPickViewModel ViewModel { get; private set; }
        public virtual IMainWindowPresenter MainWindow { get; set; }

        public void InitializePresenter(IStepPickView view, StepPickViewModel viewModel = null)
        {
            ViewModel = viewModel ?? new StepPickViewModel();

            View = view;
            View.DataContext = ViewModel;
            View.Presenter = this;

            _kmlObjectsTreePresenter.InitializePresenter(View.KmlObjectsTreeView, ViewModel.KmlObjectsTree);
        }

        public async Task Activated()
        {
            _userSession.Document = null;
            SetDocument(null);
            _cancellationTokenSource = new CancellationTokenSource();

            if (!await PrepareAndReadInputFile())
            {
                await MainWindow.GoBack();
                return;
            }

            var kmlDocument = await _kmlFileReader.ReadFromFile(ViewModel.InputFileName);
            if (kmlDocument == null)
            {
                await _dialog.InvalidOperationMessage(Resources.Error_FailedToLoadDocument);
                await MainWindow.GoBack();
                return;
            }
            SetDocument(kmlDocument);

            _kmlObjectsTreePresenter.HandleActivated(kmlDocument, _cancellationTokenSource.Token);
        }

        public Task<bool> BeforeGoBack()
        {
            _cancellationTokenSource?.Cancel();

            return Task.FromResult(true);
        }

        public async Task<bool> BeforeGoNext()
        {
            UpdateSessionDocument();

            if (!_userSession.Document.Folders.Any(f => f.Placemarks.Any()))
            {
                await _dialog.InvalidOperationMessage("There are no placemarks selected for a report generation.");
                return false;
            }

            _cancellationTokenSource?.Cancel();
            return true;
        }

        public void GetBackNextTitles(ref string back, ref string next)
        {
        }

        public void Dispose()
        {
            foreach (var tempFile in _tempFilesCreated)
            {
                _file.Delete(tempFile);
            }
        }

        internal void SetDocument(KmlDocument kmlDocument)
        {
            _kmlDocument = kmlDocument;
        }

        private async Task<bool> PrepareAndReadInputFile()
        {
            switch (_userSession.InputSource)
            {
                case InputSource.LocalFile:
                    ViewModel.InputFileName = _userSession.InputUri;
                    return true;
                case InputSource.GoogleMyMapsUrl:
                    var errorMessage = "Cannot download KML file for provided URL. Make sure the map is shared publicly.";
                    var uri = _googleMyMapAdapter.GetKmlDownloadUrl(new Uri(_userSession.InputUri));
                    if (uri == null)
                    {
                        await _dialog.InvalidOperationMessage(errorMessage);
                        return false;
                    }
                    try
                    {
                        var inputData = await _webClient.GetAsync(uri);
                        ViewModel.InputFileName = $"{Path.GetTempPath()}{_resourceName.GetTempFolderPrefix()}{Guid.NewGuid()}.kmz";
                        await _file.WriteBytesAsync(ViewModel.InputFileName, inputData);

                        _tempFilesCreated.Add(ViewModel.InputFileName);
                        return true;
                    }
                    catch (Exception)
                    {
                        await _dialog.InvalidOperationMessage(errorMessage);
                    }
                    break;
                default:
                    throw new NotSupportedException($"Input source type is invalid: {_userSession.InputSource}");
            }

            return false;
        }

        private void UpdateSessionDocument()
        {
            var elementsToExclude = ViewModel.KmlObjectsTree.FoldersToInclude.Where(x => !x.Enabled).Select(x => x.Element)
                .Concat(ViewModel.KmlObjectsTree.FoldersToInclude.SelectMany(x => x.Children).Where(x => !x.Enabled).Select(x => x.Element))
                .ToArray();

            _userSession.Document = _kmlDocument.CloneWithExcluding(elementsToExclude);
        }
    }
}
