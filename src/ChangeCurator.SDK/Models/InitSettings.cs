using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeCurator.SDK.Models
{
    public class InitSettings
    {
        public string ProjectName { get; }

        public string FilePath { get; }

        public string IssueUrl { get; }

        public InitSettings(string projectName, string filePath, string issueUrl)
        {
            ProjectName = projectName;
            FilePath = filePath;
            IssueUrl = issueUrl;
        }
    }
}
