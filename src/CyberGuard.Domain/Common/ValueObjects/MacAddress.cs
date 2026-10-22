namespace CyberGuard.Domain.Common.ValueObjects;

public readonly record struct MacAddress
{
    public string Value { get; }

    private MacAddress(string value) => Value = value.ToLowerInvariant();

    public static MacAddress Parse(string input)
    {
        var cleaned = input.Replace(":", "").Replace("-", "").Replace(".", "").ToLowerInvariant();
        if (cleaned.Length != 12 || !cleaned.All(c => "0123456789abcdef".Contains(c)))
            throw new ArgumentException($"Invalid MAC address: {input}", nameof(input));
        var formatted = string.Join(":", Enumerable.Range(0, 6).Select(i => cleaned.Substring(i * 2, 2)));
        return new MacAddress(formatted);
    }

    public static implicit operator string(MacAddress mac) => mac.Value;
    public override string ToString() => Value;
}
