using AdminSystem.Core.Entities;

namespace Voter.Core.Entities;

public class Zilla(Guid id, string name, Guid divisionId) : Audit<Guid>
{
    public override Guid Id { get; protected set; } = id;
    public string Name { get; private set; } = name;
    public Guid DivisionId { get; private set; } = divisionId;

    public Division? Division { get; private set; }
    public ICollection<Upazilla>? Upazillas { get; private set; }
    public ICollection<Corporation>? Corporations { get; private set; }
}
