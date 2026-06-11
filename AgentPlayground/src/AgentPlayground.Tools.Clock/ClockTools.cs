using System.ComponentModel;

namespace AgentPlayground.Tools.Clock;

public sealed class ClockTools
{
    [Description("Gets the current date and time in UTC, formatted as an ISO 8601 string.")]
    public string GetCurrentUtcTime() => DateTimeOffset.UtcNow.ToString("O");
}
