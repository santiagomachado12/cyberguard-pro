namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Common.ValueObjects;
using CyberGuard.Domain.Enums;

public class SecurityEvent : Entity<Guid>
{
    public string Source { get; private set; } = default!;
    public string EventType { get; private set; } = default!;
    public EventSeverity Severity { get; private set; }
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
    public Guid? DeviceId { get; private set; }
    public IpAddress? SourceAddress { get; private set; }
    public string Summary { get; private set; } = default!;
    public string Details { get; private set; } = "{}";
    public string? CorrelationId { get; private set; }
    public ProcessingStatus ProcessingStatus { get; private set; } = ProcessingStatus.Pending;
    public RetentionClass RetentionClass { get; private set; } = RetentionClass.Standard;

    private SecurityEvent() { }

    public static SecurityEvent Create(string source, string eventType, EventSeverity severity, string summary, Guid? deviceId = null, IpAddress? sourceAddress = null, string? correlationId = null)
    {
        return new SecurityEvent
        {
            Id = Guid.NewGuid(),
            Source = source,
            EventType = eventType,
            Severity = severity,
            Timestamp = DateTime.UtcNow,
            DeviceId = deviceId,
            SourceAddress = sourceAddress,
            Summary = summary,
            CorrelationId = correlationId
        };
    }
}
