using ProconTel.EventHub.Connector.Contracts.gRPC;
using ProconTel.EventHub.Connector.Contracts.REST;
using System.Collections.Generic;

namespace ProconTel.EventHub.Connector.Contracts.Extensions
{
  public static class TrafficEventExtension
  {
    public static TrafficEvent Describe(this TrafficEvent @event, List<ChannelDTO> procontelApi)
    {
      switch (@event.EventTypeCase)
      {
        case TrafficEventCase.MessageReceived:
          @event.MessageReceived.DestinationContainerName = NamesTranslator.GetContainerName(procontelApi, @event.MessageReceived.DestinationContainerId);
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.MessageReceived.Sender);
          break;
        case TrafficEventCase.MessageEnqueued:
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.MessageEnqueued.Queue);
          break;
        case TrafficEventCase.MessageDelivered:
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.MessageDelivered.Receiver);
          break;
        case TrafficEventCase.MessageProcessed:
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.MessageProcessed.Receiver);
          break;
      }
      return @event;
    }
  }
}
  
