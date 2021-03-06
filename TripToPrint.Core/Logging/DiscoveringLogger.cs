namespace TripToPrint.Core.Logging
{
    public interface IDiscoveringLogger : ILogger
    {
    }

    internal class DiscoveringLogger : LoggerBase, IDiscoveringLogger
    {
        public DiscoveringLogger(ILogStorage logStorage) : base(logStorage)
        {
        }

        public override LogCategory Category => LogCategory.Discovering;
    }
}
