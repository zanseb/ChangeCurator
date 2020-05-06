using System.Configuration;
using System.IO;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Configurations
{
    internal class ProjectConfiguration
    {
        private const string ConfigFileName = "config";
        private const string ProjectNameKey = "ProjectName";
        private const string ProjectIssueUrlKey = "IssueUrl";

        internal void SaveConfiguration(ProjectSettings settings)
        {
            string configPath = Path.Combine(settings.RootDirectory, ProjectStructureConfig.ToolDirectory, ConfigFileName);
            var fileMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = configPath,
            };

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings.Add(new KeyValueConfigurationElement(ProjectNameKey, settings.ProjectName));
            config.AppSettings.Settings.Add(new KeyValueConfigurationElement(ProjectIssueUrlKey, settings.IssueUrl));

            config.Save();
        }

        internal ProjectSettings GetConfiguration()
        {
            return null;
        }
    }
}
