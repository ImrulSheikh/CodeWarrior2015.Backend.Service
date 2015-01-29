using System;

namespace ApplicationLogger
{
    public static class ImsLogManager
    {
        public static ILogger GetLogger(Type type)
        {
            return new Log4NetWrapper(type);
        }
    }
}
