namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Common.ValueObjects;
using CyberGuard.Domain.Enums;

public class Device : Entity<Guid>
{
    public string Hostname { get; private set; } = default!;
    public string DisplayName { get; private set; } = default!;
    public IpAddress IpAddress { get; private set; }
    public IpAddress? Ipv6Address { get; private set; }
    public MacAddress? MacAddress { get; private set; }
    public DeviceCategory Category { get; private set; }
    public string? OperatingSystem { get; private set; }
    public string? Location { get; private set; }
    public string? Owner { get; private set; }
    public string? Description { get; private set; }
    public MonitoringStatus MonitoringStatus { get; private set; } = MonitoringStatus.Unknown;
    public DateTime? LastSuccessfulCheck { get; private set; }
    public DateTime? LastFailedCheck { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public ICollection<DeviceTag> Tags { get; private set; } = new List<DeviceTag>();
    public ICollection<ApprovedService> ApprovedServices { get; private set; } = new List<ApprovedService>();
    public ICollection<MonitoringConfiguration> MonitoringConfigurations { get; private set; } = new List<MonitoringConfiguration>();

    private Device() { }

    public static Device Create(string hostname, string displayName, IpAddress ipAddress, DeviceCategory category)
    {
        return new Device
        {
            Id = Guid.NewGuid(),
            Hostname = hostname,
            DisplayName = displayName,
            IpAddress = ipAddress,
            Category = category,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public void UpdateMonitoringStatus(MonitoringStatus status, DateTime checkedAt)
    {
        MonitoringStatus = status;
        if (status == MonitoringStatus.Reachable) LastSuccessfulCheck = checkedAt;
        else LastFailedCheck = checkedAt;
        UpdatedAt = DateTime.UtcNow;
    }
}
