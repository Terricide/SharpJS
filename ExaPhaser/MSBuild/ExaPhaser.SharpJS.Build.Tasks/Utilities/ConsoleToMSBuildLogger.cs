using Microsoft.Build.Utilities;
using System.IO;
using System.Text;

namespace ExaPhaser.SharpJS.Build.Tasks.Utilities
{
    internal class ConsoleToMSBuildLogger : TextWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return System.Text.Encoding.Default;
            }
        }

        private TaskLoggingHelper _logger;
        private TaskLoggerType _loggerType;

        public ConsoleToMSBuildLogger(TaskLoggingHelper logger, TaskLoggerType loggerType)
        {
            _logger = logger;
            _loggerType = loggerType;
        }

        public override void WriteLine(string format, params object[] args)
        {
            switch (_loggerType)
            {
                case TaskLoggerType.Log:
                    _logger.LogMessage(format, args);
                    break;

                case TaskLoggerType.Error:
                    _logger.LogError(format, args);
                    break;
            }

            base.WriteLine(format, args);
        }
    }
}