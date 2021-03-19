using ProconTel.EventHub.Connector.Contracts.gRPC;
using System;

namespace ProconTel.EventHub.Connector.Contracts.Extensions
{
  public static class TimeConversionExtension
  {
    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private const long BclSecondsAtUnixEpoch = 62135596800;
    internal const long UnixSecondsAtBclMaxValue = 253402300799;
    internal const long UnixSecondsAtBclMinValue = -BclSecondsAtUnixEpoch;
    internal const int MaxNanos = NanosecondsPerSecond - 1;
    public const int NanosecondsPerSecond = 1000000000;
    public const int NanosecondsPerTick = 100;

    private static bool IsNormalized(long seconds, int nanoseconds) =>
        nanoseconds >= 0 &&
        nanoseconds <= MaxNanos &&
        seconds >= UnixSecondsAtBclMinValue &&
        seconds <= UnixSecondsAtBclMaxValue;

    public static DateTime ToDateTime(this Timestamp timestamp)
    {
      if (!IsNormalized(timestamp.Seconds, timestamp.Nanos))
        throw new InvalidOperationException($"Timestamp contains invalid values: Seconds={timestamp.Seconds}; Nanos={timestamp.Nanos}");
      return UnixEpoch.AddSeconds(timestamp.Seconds).AddTicks(timestamp.Nanos / NanosecondsPerTick);
    }

    public static TimeSpan ToTimeSpan(this Duration duration)
    {
      if (!IsNormalized(duration.Seconds, duration.Nanos))
          throw new InvalidOperationException("Duration was not a valid normalized duration");
      long ticks = duration.Seconds * TimeSpan.TicksPerSecond + duration.Nanos / NanosecondsPerTick;
      return TimeSpan.FromTicks(ticks);
    }
  }
}
