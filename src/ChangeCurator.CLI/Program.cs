using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ChangeCurator.CLI.ActionArgs;
using ChangeCurator.SDK.Actions;
using ChangeCurator.SDK.Models;
using CommandLine;

namespace ChangeCurator.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Type[] types = LoadActionArgs();
            Parser parser = SetupCLIParser();

            parser.ParseArguments(args, types)
                .WithParsed(ExecAction)
                .WithNotParsed(errors => DisplayHelp(errors, parser.Settings.HelpWriter));
        }

        private static Type[] LoadActionArgs()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
        }

        private static Parser SetupCLIParser()
        {
            var helpWriter = new StringWriter();
            return new Parser(with =>
            {
                with.HelpWriter = helpWriter;
                with.AutoHelp = true;
                with.AutoVersion = true;
            });
        }

        private static void ExecAction(object obj)
        {
            IAction action = null;

            switch (obj)
            {
                case InitArgs args:
                    var settings = new ProjectSettings(args.ProjectName, args.RootDirectory, args.IssueUrl);
                    action = new InitAction(settings);
                    break;
                case AddArgs args:
                    break;
            }

            action.Execute();
        }

        private static void DisplayHelp(IEnumerable<Error> errors, TextWriter helpWriter)
        {
            Console.WriteLine(helpWriter.ToString());
        }
    }
}
