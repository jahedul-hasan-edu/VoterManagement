using AdminSystem.Core.Entities;

namespace Voter.Core.Entities;

public class VoterMember(Guid id, string name, string voterNo, string? fatherName, string? motherName, string? occupation, DateTime? birthDate, string? address, string? imageUrl) : Audit<Guid>
{
    public override Guid Id { get; protected set; } = id;
    public string Name { get; private set; } = name;
    public string VoterNo { get; private set; } = voterNo;
    public string? FatherName { get; private set; } = fatherName;
    public string? MotherName { get; private set; } = motherName;
    public string? Occupation { get; private set; } = occupation;
    public DateTime? BirthDate { get; private set; } = birthDate;
    public string? Address { get; private set; } = address;
    public string? ImageUrl { get; private set; } = imageUrl;
}




