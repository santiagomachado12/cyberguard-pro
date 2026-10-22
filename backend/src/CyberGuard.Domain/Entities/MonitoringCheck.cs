namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Enums;

public class MonitoringCheck : Entity<Guid>
{
    public Guid MonitoringConfigurationId { get; private set; }
    public Guid DeviceId { get; private set; }
    public CheckType CheckType { get; private set; }
    public CheckResult Result { get; private set; }
    public int ResponseTimeMs { get; private set; }
    public string? ErrorMessage { get; private set; }
    public DateTime CheckedAt { get; private set; } = DateTime.UtcNow;

    private MonitoringCheck() { }

    public static MonitoringCheck CreateSuccess(Guid configId, Guid deviceId, CheckType type, int responseTimeMs)
    {
        return new MonitoringCheck
        {
            Id = Guid.NewGuid(),
            MonitoringConfigurationId = configId,
            DeviceId = deviceId,
            CheckType = type,
            Result = CheckResult.Success,
            ResponseTimeMs = responseTimeMs,
            CheckedAt = DateTime.UtcNow
        };
    }

    public static MonitoringCheck CreateFailure(Guid configId, Guid deviceId, CheckType type, string error, int responseTimeMs = 0)
    {
        return new MonitoringCheck
        {
            Id = Guid.NewGuid(),
            MonitoringConfigurationId = configId,
            DeviceId = deviceId,
            CheckType = type,
            Result = CheckResult.Failure,
            ResponseTimeMs = responseTimeMs,
            ErrorMessage = error,
            CheckedAt = DateTime.UtcNow
        };
    }
}
