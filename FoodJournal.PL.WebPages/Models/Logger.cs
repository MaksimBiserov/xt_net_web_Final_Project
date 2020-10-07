using log4net;
using log4net.Config;


namespace FoodJournal.PL.WebPages.Models
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger("ErrorLog");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}