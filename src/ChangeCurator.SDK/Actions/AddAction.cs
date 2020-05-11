using System;
using System.Collections.Generic;
using System.Text;
using ChangeCurator.SDK.Configurations;
using ChangeCurator.SDK.Core;
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

            var repository = new ChangeLogEntryRepository(settings);
            repository.SaveChangelogEntry(changlogEntry);
        }
    }
}
