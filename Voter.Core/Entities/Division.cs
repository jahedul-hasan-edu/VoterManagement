using AdminSystem.Core.Entities;

namespace Voter.Core.Entities;

public class Division(Guid id, string name) : Audit<Guid>
{
    public sealed override Guid Id { get; protected set; } = id;
    public string Name { get; private set; } = name;

    public ICollection<Zilla> Zillas { get; set; }
}


