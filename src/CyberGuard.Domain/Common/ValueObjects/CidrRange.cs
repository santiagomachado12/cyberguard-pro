namespace CyberGuard.Domain.Common.ValueObjects;

using System.Net;
using System.Net.Sockets;

public readonly record struct CidrRange
{
    public IPAddress NetworkAddress { get; }
    public int PrefixLength { get; }

    private CidrRange(IPAddress network, int prefix) => (NetworkAddress, PrefixLength) = (network, prefix);

    public static CidrRange Parse(string cidr)
    {
        var parts = cidr.Split('/', 2);
        if (parts.Length != 2 || !IPAddress.TryParse(parts[0], out var ip) || !int.TryParse(parts[1], out var prefix))
            throw new ArgumentException($"Invalid CIDR: {cidr}", nameof(cidr));
        if (ip.AddressFamily == AddressFamily.InterNetwork && prefix > 32)
            throw new ArgumentException("IPv4 prefix max 32");
        if (ip.AddressFamily == AddressFamily.InterNetworkV6 && prefix > 128)
            throw new ArgumentException("IPv6 prefix max 128");
        var mask = prefix == 0 ? IPAddress.Any : CreateMask(ip.AddressFamily, prefix);
        var network = new IPAddress(ip.GetAddressBytes().Zip(mask.GetAddressBytes(), (a, b) => (byte)(a & b)).ToArray());
        return new CidrRange(network, prefix);
    }

    public bool Contains(IPAddress address)
    {
        if (address.AddressFamily != NetworkAddress.AddressFamily) return false;
        var addrBytes = address.GetAddressBytes();
        var netBytes = NetworkAddress.GetAddressBytes();
        var mask = CreateMask(address.AddressFamily, PrefixLength).GetAddressBytes();
        return addrBytes.Zip(netBytes, (a, n) => (a & mask[Array.IndexOf(addrBytes, a)]) == n).All(x => x);
    }

    private static IPAddress CreateMask(AddressFamily family, int prefix)
    {
        var bytes = new byte[family == AddressFamily.InterNetwork ? 4 : 16];
        for (int i = 0; i < prefix; i++) bytes[i / 8] |= (byte)(0x80 >> (i % 8));
        return new IPAddress(bytes);
    }

    public override string ToString() => $"{NetworkAddress}/{PrefixLength}";
}
