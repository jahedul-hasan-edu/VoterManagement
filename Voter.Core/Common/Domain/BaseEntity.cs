namespace Voter.Core.Common.Domain;

public abstract class BaseEntity<TId>
{
    public virtual TId Id { get; protected set; }

    protected BaseEntity()
    {
    }

    protected BaseEntity(TId id)
    {
        Id = id;
    }
}
