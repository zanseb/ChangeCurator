using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ChangeCurator.CLI.ActionArgs;
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
            switch (obj)
            {
                case InitArgs args:
                    break;
                case AddArgs args:
                    break;
            }
        }

        private static void DisplayHelp(IEnumerable<Error> errors, TextWriter helpWriter)
        {
            Console.WriteLine(helpWriter.ToString());
        }
    }
}
