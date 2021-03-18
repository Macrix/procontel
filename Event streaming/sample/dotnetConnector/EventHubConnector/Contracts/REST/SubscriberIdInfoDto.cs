namespace ProconTel.EventHub.Connector.Contracts.REST
{
  public class SubscriberIdInfoDto
  {
    public SubscriberIdInfoDto()
    {

    }
    /// <summary>
    /// Gets id of provider.
    /// </summary>
    public string ProviderId { get; set; }

    /// <summary>
    /// Gets the content id.
    /// </summary>
    public string ContentId { get; set; }

    /// <summary>
    /// Gets the buffer size.
    /// </summary>
    public int BufferSize { get; set; }

    /// <summary>
    /// Gets information whether oldest content should be rejected.
    /// </summary>
    public bool RejectOldest { get; set; }

    /// <summary>
    /// Gets information whether missed content should be requested at provider.
    /// </summary>
    public bool RequestMissedContentAtProvider { get; set; }
  }
}
