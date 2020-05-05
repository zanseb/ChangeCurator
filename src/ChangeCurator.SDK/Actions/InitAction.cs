using System;
using System.Configuration;
using System.IO;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Actions
{
    public class InitAction : IAction
    {
        private readonly InitSettings settings;

        public InitAction(InitSettings settings)
        {
            this.settings = settings;
        }

        public void Execute()
        {
            GenerateProjectConfig();
            GenerateProjectStructure();
        }

        private void GenerateProjectConfig()
        {
            string configPath = Path.Combine(settings.FilePath, ".cc");
            Directory.CreateDirectory(configPath);

            var fileMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = Path.Combine(configPath, "config"),
            };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings.Add(new KeyValueConfigurationElement("ProjectName", settings.ProjectName));
            config.AppSettings.Settings.Add(new KeyValueConfigurationElement("IssueUrl", settings.IssueUrl));

            config.Save();
        }

        private void GenerateProjectStructure()
        {
            string changelogEntriesPath = Path.Combine(settings.FilePath, "changelogs", "unreleased");
            string trackDirectoryFilePath = Path.Combine(changelogEntriesPath, ".keep");

            Directory.CreateDirectory(changelogEntriesPath);
            File.Create(trackDirectoryFilePath).Dispose();
        }
    }
}