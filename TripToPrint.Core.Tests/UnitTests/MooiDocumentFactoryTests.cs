﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TripToPrint.Core.ModelFactories;
using TripToPrint.Core.Models;

namespace TripToPrint.Core.Tests.UnitTests
{
    [TestClass]
    public class MooiDocumentFactoryTests
    {
        private readonly Mock<IMooiGroupFactory> _mooiGroupFactoryMock = new Mock<IMooiGroupFactory>();

        private MooiDocumentFactory _factory;

        [TestInitialize]
        public void TestInitialize()
        {
            _factory = new MooiDocumentFactory(_mooiGroupFactoryMock.Object);
        }

        [TestMethod]
        public void When_creating_model_the_values_are_copied_correctly()
        {
            // Arrange
            var kmlDocument = new KmlDocument {
                Title = "kml-title",
                Description = "kml-desc",
                Folders = {
                    new KmlFolder("folder-1", new List<KmlPlacemark> {
                            new KmlPlacemark()
                        })
                }
            };
            _mooiGroupFactoryMock.Setup(x => x.CreateList(kmlDocument.Folders[0], null, string.Empty)).Returns(new List<MooiGroup>());

            // Act
            var result = _factory.Create(kmlDocument, null, string.Empty);

            // Verify
            Assert.AreEqual(kmlDocument.Title, result.Title);
            Assert.AreEqual(kmlDocument.Description, result.Description);
            Assert.AreEqual(kmlDocument.Folders[0].Name, result.Sections[0].Name);
        }
    }
}
