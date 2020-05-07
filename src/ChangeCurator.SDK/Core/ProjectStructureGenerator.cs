using System.IO;
using ChangeCurator.SDK.Configurations;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Core
{
    internal class ProjectStructureGenerator
    {
        private readonly ProjectSettings settings;

        public ProjectStructureGenerator(ProjectSettings settings)
        {
            this.settings = settings;
        }

        internal void Generate()
        {
            GenerateProjectStructure(settings);
        }

        private void GenerateProjectStructure(ProjectSettings settings)
        {
            string configPath = Path.Combine(settings.RootDirectory, ProjectStructureConstants.ToolDirectory);
            string changelogEntriesPath = Path.Combine(settings.RootDirectory, ProjectStructureConstants.ChangelogEntriesDirectory);
            string trackDirectoryFilePath = Path.Combine(changelogEntriesPath, ".keep");
            string changelogFilePath = Path.Combine(settings.RootDirectory, ProjectStructureConstants.ChangelogFileName);

            Directory.CreateDirectory(configPath);
            Directory.CreateDirectory(changelogEntriesPath);
            File.Create(trackDirectoryFilePath).Dispose();
            File.Create(changelogFilePath).Dispose();

            SaveProjectConfiguration(settings);
        }

        private void SaveProjectConfiguration(ProjectSettings settings)
        {
            var configuration = new ProjectConfiguration();
            configuration.SaveProjectSettings(settings);
        }
    }
}
