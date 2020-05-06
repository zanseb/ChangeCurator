using CommandLine;

namespace ChangeCurator.CLI.ActionArgs
{
    [Verb("init", HelpText = "Initialize the project to keep track of")]
    class InitArgs
    {
        [Option('p', "project", Required = true, HelpText = "The name of the project")]
        public string ProjectName { get; set; }

        [Option('d', "directory", Required = true, HelpText = "The root of the directory")]
        public string RootDirectory { get; set; }

        [Option('u', "url", HelpText = "The url which has to be prefixed to the issue identifier")]
        public string IssueUrl { get; set; }
    }
}
