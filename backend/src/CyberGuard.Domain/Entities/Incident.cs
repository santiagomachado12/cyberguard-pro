namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Enums;

public class Incident : Entity<Guid>
{
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public IncidentSeverity Severity { get; private set; }
    public IncidentStatus Status { get; private set; } = IncidentStatus.Open;
    public Guid? AssignedToUserId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ClosedAt { get; private set; }
    public string? ClosureReason { get; private set; }
    public ICollection<IncidentAlert> IncidentAlerts { get; private set; } = new List<IncidentAlert>();
    public ICollection<IncidentNote> Notes { get; private set; } = new List<IncidentNote>();

    private Incident() { }

    public static Incident Create(string title, string description, IncidentSeverity severity, Guid? assignedTo = null)
    {
        return new Incident { Id = Guid.NewGuid(), Title = title, Description = description, Severity = severity, AssignedToUserId = assignedTo };
    }

    public void UpdateStatus(IncidentStatus status) { Status = status; UpdatedAt = DateTime.UtcNow; if (status == IncidentStatus.Closed) ClosedAt = DateTime.UtcNow; }
    public void Assign(Guid userId) { AssignedToUserId = userId; UpdatedAt = DateTime.UtcNow; }
    public void Close(string reason) { Status = IncidentStatus.Closed; ClosureReason = reason; ClosedAt = DateTime.UtcNow; UpdatedAt = DateTime.UtcNow; }
}
