using Voter.Core.Common.Domain;

namespace AdminSystem.Core.Entities;

public abstract class Audit<T> : BaseEntity<T>, IAudit
{
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }

    public DateTime CreatedOn { get; private set; }
    public DateTime? ModifiedOn { get; private set; }

    public void SetCreatedOn(DateTime dateTimeOffset)
    {
        CreatedOn = dateTimeOffset;
    }

    public void SetModifiedOn(DateTime dateTimeOffset)
    {
        ModifiedOn = dateTimeOffset;
    }
}
