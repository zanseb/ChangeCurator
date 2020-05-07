using System;
using System.Collections.Generic;
using System.Text;
using ChangeCurator.SDK.Configurations;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Actions
{
    public class AddAction : IAction
    {
        private readonly ChangeLogEntry changlogEntry;

        public AddAction(ChangeLogEntry changlogEntry)
        {
            this.changlogEntry = changlogEntry;
        }

        public void Execute()
        {
            var configuration = new ProjectConfiguration();
            ProjectSettings settings = configuration.GetProjectSettings();

            // TODO: Generate file content (yaml) with all information contained in changlogEntry
            // TODO: Save content to file
        }
    }
}
