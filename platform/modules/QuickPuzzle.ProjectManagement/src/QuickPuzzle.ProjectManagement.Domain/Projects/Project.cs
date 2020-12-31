using System.ComponentModel.DataAnnotations;
using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation;

namespace QuickPuzzle.ProjectManagement.Projects
{
    public class Project : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; private set; }

        [Required]
        [NotNull]
        [DynamicStringLength(
            typeof(ProjectConsts),
            nameof(ProjectConsts.NameMaxLength),
            nameof(ProjectConsts.NameMinLength))]
        public string Name { get; private set; }

        protected Project()
        {
        }

        internal Project([NotNull] string name, Guid? tenantId)
        {
            TenantId = tenantId;
            SetName(name);
        }

        internal Project SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                ProjectConsts.NameMaxLength,
                ProjectConsts.NameMinLength);
            Name = name;
            return this;
        }

    }
}