namespace ProconTel.EventHub.Connector.Contracts.REST
{
  public enum RecoveryActionType
  {
    /// <summary>
    /// The problem is ignored.
    /// </summary>
    Ignore,

    /// <summary>
    /// Endpoint, pool or channel wil be dactivated.
    /// </summary>
    Deactivate,

    /// <summary>
    /// Endpoint, pool or channel will be restarted.
    /// </summary>
    Restart
  }
}
