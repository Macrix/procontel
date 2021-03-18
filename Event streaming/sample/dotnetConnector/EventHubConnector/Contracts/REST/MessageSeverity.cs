namespace ProconTel.EventHub.Connector.Contracts.REST
{
  public enum MessageSeverity
  {
    /// <summary>
    /// Fatal (critical) error level.
    /// </summary>
    Fatal,
    /// <summary>
    /// Error level.
    /// </summary>
    Error,
    /// <summary>
    /// Warning level.
    /// </summary>
    Warning,
    /// <summary>
    /// Information level.
    /// </summary>
    Info,
    /// <summary>
    /// Debug level.
    /// </summary>
    Debug
  }
}
