namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Enums;

public class MonitoringConfiguration : Entity<Guid>
{
    public Guid DeviceId { get; private set; }
    public CheckType CheckType { get; private set; }
    public int IntervalSeconds { get; private set; } = 60;
    public int TimeoutSeconds { get; private set; } = 10;
    public int MaxRetries { get; private set; } = 3;
    public bool IsEnabled { get; private set; } = true;
    public string? HttpEndpoint { get; private set; }
    public int? HttpExpectedStatus { get; private set; }
    public string? HttpExpectedContent { get; private set; }
    public Device Device { get; private set; } = default!;

    private MonitoringConfiguration() { }

    public static MonitoringConfiguration CreateIcmp(Guid deviceId, int intervalSeconds = 60)
    {
        return new MonitoringConfiguration
        {
            Id = Guid.NewGuid(),
            DeviceId = deviceId,
            CheckType = CheckType.Icmp,
            IntervalSeconds = intervalSeconds
        };
    }

    public static MonitoringConfiguration CreateTcp(Guid deviceId, int port, int intervalSeconds = 60)
    {
        return new MonitoringConfiguration
        {
            Id = Guid.NewGuid(),
            DeviceId = deviceId,
            CheckType = CheckType.Tcp,
            IntervalSeconds = intervalSeconds,
            HttpEndpoint = port.ToString()
        };
    }

    public static MonitoringConfiguration CreateHttp(Guid deviceId, string endpoint, int expectedStatus = 200, int intervalSeconds = 60)
    {
        return new MonitoringConfiguration
        {
            Id = Guid.NewGuid(),
            DeviceId = deviceId,
            CheckType = CheckType.Http,
            IntervalSeconds = intervalSeconds,
            HttpEndpoint = endpoint,
            HttpExpectedStatus = expectedStatus
        };
    }
}
