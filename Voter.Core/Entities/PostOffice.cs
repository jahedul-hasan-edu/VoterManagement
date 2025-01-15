using AdminSystem.Core.Entities;

namespace Voter.Core.Entities;

public class PostOffice(Guid id, string name, string postCode, Guid upazillaId) : Audit<Guid>
{
    public override Guid Id { get; protected set; } = id;
    public string Name { get; private set; } = name;
    public string PostCode { get; private set; } = postCode;
    public Guid UpazillaId { get; private set; } = upazillaId;

    public Upazilla? Upazilla { get; private set; }
    public ICollection<VoterArea>? VoterAreas { get; private set; }
}


