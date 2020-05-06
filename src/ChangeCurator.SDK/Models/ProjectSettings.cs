using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeCurator.SDK.Models
{
    public class ProjectSettings
    {
        public string ProjectName { get; }

        public string RootDirectory { get; }

        public string IssueUrl { get; }

        public ProjectSettings(string projectName, string rootDirectory, string issueUrl)
        {
            ProjectName = projectName;
            RootDirectory = rootDirectory;
            IssueUrl = issueUrl;
        }
    }
}
