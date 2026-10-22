namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Enums;

public class AlertHistory : Entity<Guid>
{
    public Guid AlertId { get; private set; }
    public AlertStatus FromStatus { get; private set; }
    public AlertStatus ToStatus { get; private set; }
    public Guid? ChangedByUserId { get; private set; }
    public string? Notes { get; private set; }
    public DateTime ChangedAt { get; private set; } = DateTime.UtcNow;
    public Alert Alert { get; private set; } = default!;

    private AlertHistory() { }

    public static AlertHistory Create(Guid alertId, AlertStatus from, AlertStatus to, Guid? userId = null, string? notes = null)
    {
        return new AlertHistory { Id = Guid.NewGuid(), AlertId = alertId, FromStatus = from, ToStatus = to, ChangedByUserId = userId, Notes = notes };
    }
}
