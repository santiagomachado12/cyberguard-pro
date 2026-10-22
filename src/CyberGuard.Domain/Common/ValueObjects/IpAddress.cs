namespace CyberGuard.Domain.Common.ValueObjects;

using System.Net;

public readonly record struct IpAddress
{
    public IPAddress Value { get; }

    private IpAddress(IPAddress value) => Value = value;

    public static IpAddress Parse(string input)
    {
        if (IPAddress.TryParse(input, out var ip))
            return new IpAddress(ip);
        throw new ArgumentException($"Invalid IP address: {input}", nameof(input));
    }

    public static implicit operator string(IpAddress ip) => ip.Value.ToString();
    public static implicit operator IPAddress(IpAddress ip) => ip.Value;
    public override string ToString() => Value.ToString();
}
