using AdminSystem.Core.Entities;

namespace Voter.Core.Entities;

public class Upazilla(Guid id, string name, Guid zillaId) : Audit<Guid>
{
    public override Guid Id { get; protected set; } = id;
    public string Name { get; private set; } = name;
    public Guid ZillaId { get; private set; } = zillaId;

    public Zilla? Zilla { get; private set; } 
    public ICollection<UnionCouncil>? UnionCouncils { get; private set; }
    public ICollection<PostOffice>? PostOffices { get; private set; }
}
