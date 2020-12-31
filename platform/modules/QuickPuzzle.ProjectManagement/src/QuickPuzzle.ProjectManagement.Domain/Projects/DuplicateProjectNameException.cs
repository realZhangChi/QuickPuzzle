using Volo.Abp;

namespace QuickPuzzle.ProjectManagement.Projects
{
    public class DuplicateProjectNameException : UserFriendlyException
    {
        public DuplicateProjectNameException()
            : base(ProjectManagementErrorCodes.Project.DuplicateProjectName)
        {

        }
    }
}