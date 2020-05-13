using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ChangeCurator.SDK.Configurations;
using ChangeCurator.SDK.Models;
using YamlDotNet.Serialization;

namespace ChangeCurator.SDK.Core
{
    internal class ChangeLogEntryRepository
    {
        private readonly ProjectSettings settings;

        internal ChangeLogEntryRepository(ProjectSettings settings)
        {
            this.settings = settings;
        }

        internal void SaveChangelogEntry(ChangeLogEntry entry)
        {
            var serializer = new SerializerBuilder()
                .EmitDefaults()
                .Build();

            string content = serializer.Serialize(entry);
            var filePath = Path.Join(settings.RootDirectory, ProjectStructureConstants.ChangelogEntriesDirectory, entry.IssueId + ".yml");
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new ProjectStructureFaultyException($"Could not save changlog entry: {e.Message}");
            }
        }

        internal IEnumerable<ChangeLogEntry> GetChangelogEntries()
        {
            var deserializer = new DeserializerBuilder()
                .Build();

            string[] files = Directory.GetFiles(Path.Join(settings.RootDirectory, ProjectStructureConstants.ChangelogEntriesDirectory), "*.yml");

            var changelogEntries = new List<ChangeLogEntry>();
            foreach (var file in files)
            {
                var fileContent = File.ReadAllText(file);
                var changelogEntry = deserializer.Deserialize<ChangeLogEntry>(fileContent);

                changelogEntries.Add(changelogEntry);
            }

            return changelogEntries;
        }

        internal void DeleteChangelogEntries()
        {
            string[] files = Directory.GetFiles(Path.Join(settings.RootDirectory, ProjectStructureConstants.ChangelogEntriesDirectory), "*.yml");

            foreach (var file in files)
            {
                File.Delete(file);
            }
        }
    }
}
