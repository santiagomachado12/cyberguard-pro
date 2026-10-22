namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;

public class IncidentAlert : Entity<Guid>
{
    public Guid IncidentId { get; private set; }
    public Guid AlertId { get; private set; }
    public Incident Incident { get; private set; } = default!;

    private IncidentAlert() { }

    public static IncidentAlert Create(Guid incidentId, Guid alertId) => new() { Id = Guid.NewGuid(), IncidentId = incidentId, AlertId = alertId };
}
