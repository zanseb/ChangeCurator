using System.IO;

namespace ChangeCurator.SDK.Configurations
{
    internal static class ProjectStructureConstants
    {
        internal const string ToolDirectory = ".cc";
        internal const string ChangelogFileName = "CHANGELOG.md";
        internal static readonly string ChangelogEntriesDirectory = Path.Combine("changelogs", "unreleased");
    }
}
