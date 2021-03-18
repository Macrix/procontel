using System;

namespace ProconTel.EventHub.Connector.Contracts.REST
{
  public class MessagePersistanceRuleDTO
  {
    public MessagePersistanceRuleDTO()
    {

    }
    public string MessageId { get; set; }

    public int QueueSize { get; set; }

    public TimeSpan Retention { get; set; }
  }
}
