using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Logging;

class Program {
    public static void Main() {
        int n = int.Parse(Console.ReadLine());
        IAppender[] appenders = new IAppender[n];

        for (int i = 0; i < n; i++){
            string[] data = Console.ReadLine().Split();

            IMessageFormatter<LogMessage> formatter = BuildFormatter(data[1]);
            
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(data[2], true);
            appenders[i] = CreateAppender(data[0], formatter, reportLevel);
        }
        
        ILogger logger = new Logger(appenders.ToImmutableArray());
        ProcessMessages(logger);
    }

    private static void ProcessMessages(ILogger logger) {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END"){
            string[] data = input.Split('|');
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(data[1], true);
            string time = data[1];
            string message = data[2];
            
            logger.Log(time, reportLevel, message);
        }
    }

    private static IMessageFormatter<LogMessage> BuildFormatter(string type) {
        if (type == "Simple") return new SimpleMessageFormatter();
        if (type == "Xml") return new XmlLogMessageFormatter();
        if (type == "Json") return new JsonLogMessageFormatter();
        
        throw new InvalidOperationException();
    }

    private static IAppender CreateAppender(string type, IMessageFormatter<LogMessage> formatter, ReportLevel reportLevel) {
        if (type == "Console") return new ConsoleAppender(formatter, reportLevel);
        if (type == "File") return new FileAppender(formatter, reportLevel, "");
        throw new InvalidOperationException();
    }

    private static void Demo() {
        IMessageFormatter<LogMessage> simpleFormatter = new SimpleMessageFormatter();
        IMessageFormatter<LogMessage> xmlFormatter = new XmlLogMessageFormatter();
        IMessageFormatter<LogMessage> jsonFormatter = new JsonLogMessageFormatter();
        
        IAppender SimpleConsoleAppender = new ConsoleAppender(simpleFormatter);
        IAppender JsonConsoleAppender = new ConsoleAppender(jsonFormatter);
        IAppender fileAppender = new FileAppender(xmlFormatter, ReportLevel.Error, "");

        IImmutableList<IAppender> appenders = new[] { SimpleConsoleAppender, JsonConsoleAppender, fileAppender }.ToImmutableList();
        ILogger logger = new Logger(appenders);
        
        logger.Log("3/26/2015 2:08:11 PM", ReportLevel.Error, "Error parsing JSON.");
        logger.Log("3/26/2015 2:08:11 PM", ReportLevel.Info, "User Pesho successfully registered.");
    }
}






