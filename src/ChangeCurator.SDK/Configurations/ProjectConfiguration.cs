using System;
using System.Configuration;
using System.IO;
using ChangeCurator.SDK.Core;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Configurations
{
    internal class ProjectConfiguration
    {
        private const string ConfigFileName = "config";
        private const string ProjectNameKey = "ProjectName";
        private const string ProjectIssueUrlKey = "IssueUrl";

        internal void SaveProjectSettings(ProjectSettings settings)
        {
            Configuration config = GetConfigurationFile(settings.RootDirectory);

            config.AppSettings.Settings.Add(new KeyValueConfigurationElement(ProjectNameKey, settings.ProjectName));
            config.AppSettings.Settings.Add(new KeyValueConfigurationElement(ProjectIssueUrlKey, settings.IssueUrl));

            config.Save();
        }

        internal ProjectSettings GetProjectSettings()
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            Configuration config = GetConfigurationFile(workingDirectory);
            if (!config.HasFile)
            {
                throw new ProjectSettingsNotFoundException("Project not initialized properly");
            }

            return new ProjectSettings(
                config.AppSettings.Settings[ProjectNameKey].Value,
                workingDirectory,
                config.AppSettings.Settings[ProjectIssueUrlKey].Value
                );
        }

        private Configuration GetConfigurationFile(string currentDirectory)
        {
            var configPath = Path.Combine(currentDirectory, ProjectStructureConstants.ToolDirectory, ConfigFileName);

            var fileMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = configPath,
            };

            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }
    }
}
