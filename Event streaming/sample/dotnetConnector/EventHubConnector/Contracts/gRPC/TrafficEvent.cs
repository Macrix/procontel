using ProconTel.EventHub.Connector.Contracts.Extensions;
using System;

namespace ProconTel.EventHub.Connector.Contracts.gRPC
{
  public class TrafficEvent
  {
    public TrafficEventCase EventTypeCase { get; set; }
    public string MessageId { get; set; }
    public string CorrelationId { get; set; }
    public Timestamp DateTimeStamp { get; set; }
    //public DateTime DateTimeStamp { get; set; }
    public MessageReceived MessageReceived { get; set; }
    public MessageEnqueued MessageEnqueued { get; set; }
    public MessageDelivered MessageDelivered { get; set; }
    public MessageProcessed MessageProcessed { get; set; }

    public override string ToString()
      => $"{DateTimeStamp.ToDateTime():G} {EventTypeCase}";
  }

  public enum TrafficEventCase
  {
    MessageReceived = 4,
    MessageEnqueued = 5,
    MessageDelivered = 6,
    MessageProcessed = 7
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
    public Duration ProcessingDuration { get; set; }
  }
}
