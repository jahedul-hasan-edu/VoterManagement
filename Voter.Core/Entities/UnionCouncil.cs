using AdminSystem.Core.Entities;

namespace Voter.Core.Entities;

public class UnionCouncil(Guid id, string name, int wardNo, Guid upazillaId) : Audit<Guid>
{
    public override Guid Id { get; protected set; } = id;
    public string Name { get; private set; } = name;
    public int WardNo { get; private set; } = wardNo;
    public Guid UpazillaId { get; private set; } = upazillaId;

    public Upazilla? Upazilla { get; private set; } 
    public ICollection<VoterArea> VoterAreas { get; private set; }
}


