namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Enums;

public class DetectionRule : Entity<Guid>
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public bool IsEnabled { get; private set; } = true;
    public EventSeverity Severity { get; private set; }
    public string CriteriaJson { get; private set; } = "{}";
    public TimeSpan EvaluationWindow { get; private set; }
    public int Threshold { get; private set; }
    public TimeSpan Cooldown { get; private set; }
    public string? GroupingKey { get; private set; }
    public DateTime? LastExecutionAt { get; private set; }
    public int AlertsGenerated { get; private set; }

    private DetectionRule() { }

    public static DetectionRule Create(string name, string description, EventSeverity severity, string criteriaJson, TimeSpan window, int threshold, TimeSpan cooldown, string? groupingKey = null)
    {
        return new DetectionRule
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Severity = severity,
            CriteriaJson = criteriaJson,
            EvaluationWindow = window,
            Threshold = threshold,
            Cooldown = cooldown,
            GroupingKey = groupingKey
        };
    }

    public void RecordExecution() { LastExecutionAt = DateTime.UtcNow; AlertsGenerated++; }
}
