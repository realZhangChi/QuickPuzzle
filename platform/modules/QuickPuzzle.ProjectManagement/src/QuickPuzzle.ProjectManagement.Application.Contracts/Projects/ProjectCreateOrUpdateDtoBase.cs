using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;
using Volo.Abp.ObjectExtending;

namespace QuickPuzzle.ProjectManagement.Projects
{
    public abstract class ProjectCreateOrUpdateDtoBase : ExtensibleObject
    {
        [DynamicStringLength(
            typeof(ProjectConsts),
            nameof(ProjectConsts.NameMaxLength),
            nameof(ProjectConsts.NameMinLength))]
        [Required]
        [Display(Name = "ProjectName")]
        public string Name { get; set; }

        public ProjectCreateOrUpdateDtoBase() : base(false)
        {

        }
    }
}