using System;

namespace ProconTel.EventHub.Connector.Contracts.gRPC
{
  public class TrafficEvent
  {
    public string MessageId { get; set; }
    public string CorrelationId { get; set; }
    //public DateTime dateTimeStamp { get; set; }
    public MessageReceived MessageReceived { get; set; }
    public MessageEnqueued MessageEnqueued { get; set; }
    public MessageDelivered MessageDelivered { get; set; }
    public MessageProcessed MessageProcessed { get; set; }

  }

  public class MessageReceived
  {
    public EndpointIdentity Sender { get; set; }
    public string DestinationContainerId { get; set; }
    public int MessageSize { get; set; }

    public string DestinationContainerName { get; set; }
  }

  public class MessageEnqueued
  {
    public EndpointIdentity Queue { get; set; }
  }

  public class MessageDelivered
  {
    public EndpointIdentity Receiver { get; set; }
  }

  public class MessageProcessed
  {
    public EndpointIdentity Receiver { get; set; }
    public TimeSpan ProcessingDuration { get; set; }
  }
}
