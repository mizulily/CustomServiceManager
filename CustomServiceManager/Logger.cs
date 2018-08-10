using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "CustomServiceManager.log.config", Watch = true)]

namespace CustomServiceManager
{
    class Logger
    {
        public static readonly ILog logger = LogManager.GetLogger(typeof(Logger));
        public enum logLevelType { ERROR, WARN, DEBUG, INFO};

        public static void Write(logLevelType logLevel, String logMessage)
        {
            switch (logLevel)
            {
                case logLevelType.ERROR:
                    logger.Error(logMessage);
                    break;
                case logLevelType.WARN:
                    logger.Warn(logMessage);
                    break;
                case logLevelType.DEBUG:
                    logger.Debug(logMessage);
                    break;
                case logLevelType.INFO:
                    logger.Info(logMessage);
                    break;
            }
        }

        public static void Write(Exception e)
        {
            logger.Error(e.Message);
        }
    }
}