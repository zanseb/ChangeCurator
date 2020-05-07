namespace ChangeCurator.SDK.Core
{
    public class ProjectSettingsNotFoundException : ProjectStructureFaultyException
    {
        public ProjectSettingsNotFoundException(string message) : base(message)
        {
        }
    }
}
