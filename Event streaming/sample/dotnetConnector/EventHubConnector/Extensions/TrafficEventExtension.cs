using ProconTel.EventHub.Connector.Contracts.gRPC;
using ProconTel.EventHub.Connector.Contracts.REST;
using System.Collections.Generic;

namespace ProconTel.EventHub.Connector.Contracts.Extensions
{
  public static class TrafficEventExtension
  {
    public static TrafficEvent Describe(this TrafficEvent @event, List<ChannelDTO> procontelApi)
    {
      if (@event.MessageReceived != null)
      {
        @event.MessageReceived.DestinationContainerName = NamesTranslator.GetContainerName(procontelApi, @event.MessageReceived.DestinationContainerId);
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.MessageReceived.Sender);
      }
      else if (@event.MessageEnqueued != null)
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.MessageEnqueued.Queue);
      else if (@event.MessageDelivered != null)
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.MessageDelivered.Receiver);
      else if (@event.MessageProcessed != null)
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.MessageProcessed.Receiver);

      return @event;
    }
  }
}
  
