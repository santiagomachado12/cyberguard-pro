namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;

public class IncidentNote : Entity<Guid>
{
    public Guid IncidentId { get; private set; }
    public Guid AuthorUserId { get; private set; }
    public string Content { get; private set; } = default!;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public Incident Incident { get; private set; } = default!;

    private IncidentNote() { }

    public static IncidentNote Create(Guid incidentId, Guid authorId, string content) => new() { Id = Guid.NewGuid(), IncidentId = incidentId, AuthorUserId = authorId, Content = content };
}
