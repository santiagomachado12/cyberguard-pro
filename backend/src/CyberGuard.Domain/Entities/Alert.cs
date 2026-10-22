namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Enums;

public class Alert : Entity<Guid>
{
    public Guid DetectionRuleId { get; private set; }
    public Guid? DeviceId { get; private set; }
    public EventSeverity Severity { get; private set; }
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public AlertStatus Status { get; private set; } = AlertStatus.New;
    public Guid? AssignedToUserId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? AcknowledgedAt { get; private set; }
    public DateTime? ResolvedAt { get; private set; }
    public string? ResolutionNotes { get; private set; }
    public ICollection<AlertHistory> History { get; private set; } = new List<AlertHistory>();

    private Alert() { }

    public static Alert Create(Guid ruleId, EventSeverity severity, string title, string description, Guid? deviceId = null)
    {
        return new Alert
        {
            Id = Guid.NewGuid(),
            DetectionRuleId = ruleId,
            DeviceId = deviceId,
            Severity = severity,
            Title = title,
            Description = description,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Acknowledge(Guid userId) { Status = AlertStatus.Acknowledged; AssignedToUserId = userId; AcknowledgedAt = DateTime.UtcNow; }
    public void Resolve(Guid userId, string notes) { Status = AlertStatus.Resolved; AssignedToUserId = userId; ResolvedAt = DateTime.UtcNow; ResolutionNotes = notes; }
    public void Close() => Status = AlertStatus.Closed;
}
