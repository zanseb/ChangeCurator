using ChangeCurator.SDK.Configurations;
using ChangeCurator.SDK.Core;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Commands
{
    public class AddCommand : ICommand
    {
        private readonly ChangeLogEntry changlogEntry;

        public AddCommand(ChangeLogEntry changlogEntry)
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
