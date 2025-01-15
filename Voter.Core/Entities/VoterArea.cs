using AdminSystem.Core.Entities;

namespace Voter.Core.Entities;

public class VoterArea(Guid id, string name, int areaNo, int maleVoterCount, int allVoterCount, Guid? corporationId, Guid? unionCouncilId, Guid? postOfficeId) : Audit<Guid>
{
    public override Guid Id { get; protected set; } = id;
    public string Name { get; private set; } = name;
    public int AreaNo { get; private set; } = areaNo;
    public int MaleVoterCount { get; private set; } = maleVoterCount;
    public int AllVoterCount { get; private set; } = allVoterCount;
    public Guid? CorporationId { get; private set; } = corporationId;
    public Guid? UnionCouncilId { get; private set; } = unionCouncilId;
    public Guid? PostOfficeId { get; private set; } = postOfficeId;

    public Corporation? Corporation { get; set; }
    public UnionCouncil? UnionCouncil { get; set; }
    public PostOffice? PostOffice { get; set; }
}
