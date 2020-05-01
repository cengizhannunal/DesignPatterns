using FactoryMethod.Abstract;
using FactoryMethod.Manager;

namespace FactoryMethod
{
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(LoggerType loggerType)
        {
            switch (loggerType)
            {
                case LoggerType.DatabaseLogger:
                    return new DatabaseLogManager();
                case LoggerType.FileLogger:
                    return new FileLogManager();
                case LoggerType.EmailLogger:
                    return new EmailLogManager();
                default:
                    break;
            }
            return null;
        }
    }
}
