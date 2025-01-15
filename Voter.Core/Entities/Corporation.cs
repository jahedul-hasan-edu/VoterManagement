using AdminSystem.Core.Entities;

namespace Voter.Core.Entities;

public class Corporation(Guid id, string name, int wardNo, Guid zillaId) : Audit<Guid>
{
    public override Guid Id { get; protected set; } = id;
    public string Name { get; private set; } = name;
    public int WardNo { get; private set; } = wardNo;
    public Guid ZillaId { get; private set; } = zillaId;

    public Zilla? Zilla { get; private set; } 
    public ICollection<VoterArea> VoterAreas { get; private set; }
}


