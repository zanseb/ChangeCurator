using ChangeCurator.SDK.Core;
using CommandLine;

namespace ChangeCurator.CLI.ActionArgs
{
    [Verb("add", HelpText = "Add changelog entry")]
    class AddArgs
    {
        [Option('d', "description", Required = true, HelpText = "The description of the changelog entry")]
        public string Description { get; set; }

        [Option('a', "author", HelpText = "The author of the changelog entry")]
        public string Author { get; set; }

        [Option('i', "issue", HelpText = "The issue identifier of the changelog entry")]
        public string IssueId { get; set; }

        [Option('t', "type", Default = EntryType.Added, HelpText = "The type of the changelog entry")]
        public EntryType Type { get; set; }
    }
}
