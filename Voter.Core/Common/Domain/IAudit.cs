namespace Voter.Core.Common.Domain;

public interface IAudit
{
    DateTime CreatedOn { get; }
    DateTime? ModifiedOn { get; }

    void SetCreatedOn(DateTime dateTimeOffset);

    void SetModifiedOn(DateTime dateTimeOffset);
}