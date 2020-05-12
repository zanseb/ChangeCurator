using System;
using System.Collections.Generic;
using System.IO;
using ChangeCurator.SDK.Configurations;
using ChangeCurator.SDK.Core;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Commands
{
    public class MergeCommand : ICommand
    {
        public void Execute()
        {
            var configuration = new ProjectConfiguration();
            ProjectSettings settings = configuration.GetProjectSettings();

            string sourceContent = File.ReadAllText(Path.Join(settings.RootDirectory, ProjectStructureConstants.ChangelogFileName));

            var repository = new ChangeLogEntryRepository(settings);
            IEnumerable<ChangeLogEntry> entries = repository.GetChangelogEntries();

            var changelogContent = new ChangeLogBuilder()
                .WithContent(sourceContent)
                .WithEntries(entries)
                .Build();

            File.WriteAllText(Path.Join(settings.RootDirectory, ProjectStructureConstants.ChangelogFileName), changelogContent);

            repository.DeleteChangelogEntries();
        }
    }
}
