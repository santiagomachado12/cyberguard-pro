namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;
using CyberGuard.Domain.Enums;

public class ApprovedService : Entity<Guid>
{
    public Guid DeviceId { get; private set; }
    public int Port { get; private set; }
    public Protocol Protocol { get; private set; }
    public string? ServiceName { get; private set; }
    public string? Description { get; private set; }
    public Device Device { get; private set; } = default!;

    private ApprovedService() { }

    public static ApprovedService Create(Guid deviceId, int port, Protocol protocol, string? serviceName = null)
    {
        return new ApprovedService
        {
            Id = Guid.NewGuid(),
            DeviceId = deviceId,
            Port = port,
            Protocol = protocol,
            ServiceName = serviceName
        };
    }
}
