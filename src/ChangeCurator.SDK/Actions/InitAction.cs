using System;
using System.Configuration;
using System.IO;
using ChangeCurator.SDK.Core;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Actions
{
    public class InitAction : IAction
    {
        private readonly ProjectSettings settings;

        public InitAction(ProjectSettings settings)
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