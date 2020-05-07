using System;

namespace ChangeCurator.SDK.Core
{
    public class ProjectStructureFaultyException : Exception
    {
        public ProjectStructureFaultyException(string message) : base(message)
        {
        }
    }
}
