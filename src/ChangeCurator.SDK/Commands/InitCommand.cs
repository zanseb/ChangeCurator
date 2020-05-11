using ChangeCurator.SDK.Core;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Commands
{
    public class InitCommand : ICommand
    {
        private readonly ProjectSettings settings;

        public InitCommand(ProjectSettings settings)
        {
            this.settings = settings;
        }

        public void Execute()
        {
            var structureGenerator = new ProjectStructureGenerator(settings);
            structureGenerator.Generate();
        }
    }
}