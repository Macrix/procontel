namespace ProconTel.EventHub.Connector.Contracts.gRPC
{
  public class EndpointIdentity
  {
    public string ContainerId { get; set; }
    public string EndpointId { get; set; }

    public string ContainerName { get; set; }
    public string EndpointName { get; set; }
  }
}
