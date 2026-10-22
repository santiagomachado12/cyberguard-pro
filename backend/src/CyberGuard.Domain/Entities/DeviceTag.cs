namespace CyberGuard.Domain.Entities;

using CyberGuard.Domain.Common;

public class DeviceTag : Entity<Guid>
{
    public Guid DeviceId { get; private set; }
    public string Tag { get; private set; } = default!;
    public Device Device { get; private set; } = default!;

    private DeviceTag() { }

    public static DeviceTag Create(Guid deviceId, string tag)
    {
        return new DeviceTag { Id = Guid.NewGuid(), DeviceId = deviceId, Tag = tag };
    }
}
