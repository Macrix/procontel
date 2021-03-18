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

    public static DateTime GoogleTimestampToDateTime(this System.Text.Json.JsonElement json, string dateTimeStamp)
    {
      var timestampProperty = json.GetProperty(dateTimeStamp);
      var seconds = timestampProperty.GetProperty("seconds").GetInt64();
      var nanos = timestampProperty.GetProperty("nanos").GetInt32();

      if (!IsNormalized(seconds, nanos))
        throw new InvalidOperationException($"Timestamp contains invalid values: Seconds={seconds}; Nanos={nanos}");
      return UnixEpoch.AddSeconds(seconds).AddTicks(nanos / NanosecondsPerTick);
    }

    public static TimeSpan GoogleDurationToTimeSpan(this System.Text.Json.JsonElement json, string duration)
    {
      var durationProperty = json.GetProperty(duration);
      var seconds = durationProperty.GetProperty("seconds").GetInt64();
      var nanos = durationProperty.GetProperty("nanos").GetInt32();

      if (!IsNormalized(seconds, nanos))
          throw new InvalidOperationException("Duration was not a valid normalized duration");
      long ticks = seconds * TimeSpan.TicksPerSecond + nanos / NanosecondsPerTick;
      return TimeSpan.FromTicks(ticks);
    }
  }
}
