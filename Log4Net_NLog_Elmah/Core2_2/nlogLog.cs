using System;
using System.IO;
using NLog;
using NLog.Config;
using NLog.Targets;

public static class NlogLog
{
    static string _baseDirLog = string.Empty;
    public static Logger Logger { get; private set; }

    public static void SetLog()
    {
        _baseDirLog = Directory.GetCurrentDirectory();
        var defaultLayout = "${longdate} ${level} ${message} ${exception}";
        var config = new LoggingConfiguration();
        var filetarget = new FileTarget("fileTarget"){
            FileName = $"{_baseDirLog}/LOG_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.txt",
            Layout = defaultLayout
        };
        config.AddTarget(filetarget);
        config.AddRuleForAllLevels(filetarget);

        LogManager.Configuration = config;

        Logger = LogManager.GetLogger("Padrao");
    }
}