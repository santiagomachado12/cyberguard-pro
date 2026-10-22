namespace CyberGuard.Domain.Enums;

public enum DeviceCategory
{
    Server = 1,
    Workstation = 2,
    NetworkDevice = 3,
    IoT = 4,
    Printer = 5,
    Other = 99
}

public enum MonitoringStatus
{
    Unknown = 0,
    Reachable = 1,
    Unreachable = 2,
    Degraded = 3,
    Maintenance = 4
}

public enum CheckType
{
    Icmp = 1,
    Tcp = 2,
    Http = 3,
    Https = 4
}

public enum CheckResult
{
    Success = 1,
    Failure = 2,
    Timeout = 3
}

public enum Protocol
{
    Tcp = 1,
    Udp = 2
}

public enum EventSeverity
{
    Info = 1,
    Low = 2,
    Medium = 3,
    High = 4,
    Critical = 5
}

public enum AlertStatus
{
    New = 1,
    Acknowledged = 2,
    Investigating = 3,
    Resolved = 4,
    Closed = 5,
    Suppressed = 6
}

public enum IncidentStatus
{
    Open = 1,
    Investigating = 2,
    Contained = 3,
    Resolved = 4,
    Closed = 5
}

public enum IncidentSeverity
{
    Low = 1,
    Medium = 2,
    High = 3,
    Critical = 4
}

public enum ProcessingStatus
{
    Pending = 1,
    Processed = 2,
    Failed = 3
}

public enum RetentionClass
{
    Standard = 1,
    Extended = 2,
    Permanent = 3
}
