using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Core2_2
{
    public class log4netLog
    {
        private static string _pattern = "%date %level %message %exception%newline";
        static string _baseDirLog = Directory.GetCurrentDirectory();
        private static void ConfigureLog()
        {
            var root = ((Hierarchy)LogManager.GetAllRepositories().First()).Root;
            root.AddAppender(GetFileAppender(_baseDirLog, "log4net.txt", Level.All));
            root.Repository.Configured = true;
        }

        private static FileAppender GetFileAppender(string directory, string fileName, Level threshold)
        {
            var appender = new FileAppender
            {
                Name = "File",
                AppendToFile = true,
                File = directory + "\\" + fileName,
                Layout = new PatternLayout(_pattern),
                Threshold = threshold
            };

            appender.ActivateOptions();
            return appender;
        }
    }
}