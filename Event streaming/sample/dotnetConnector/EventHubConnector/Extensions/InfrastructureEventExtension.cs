using ProconTel.EventHub.Connector.Contracts.gRPC;
using ProconTel.EventHub.Connector.Contracts.REST;
using System.Collections.Generic;

namespace ProconTel.EventHub.Connector.Contracts.Extensions
{
  public static class InfrastructureEventExtension
  {
    public static InfrastructureEvent Describe(this InfrastructureEvent @event, List<ChannelDTO> procontelApi)
    {
      if (@event.ContainerActivated != null)
        @event.ContainerActivated.ContainerName = NamesTranslator.GetContainerName(procontelApi, @event.ContainerActivated.ContainerId);
      else if (@event.ContainerDeactivated != null)
        @event.ContainerDeactivated.ContainerName = NamesTranslator.GetContainerName(procontelApi, @event.ContainerDeactivated.ContainerId);
      else if (@event.CyclicReport != null)
        @event.CyclicReport.ContainerName = NamesTranslator.GetContainerName(procontelApi, @event.CyclicReport.ContainerId);
      else if (@event.EndpointActivated != null)
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.EndpointActivated.Endpoint);
      else if (@event.EndpointDeactivated != null)
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.EndpointDeactivated.Endpoint);
      else if (@event.EndpointConnected != null)
      {
        @event.EndpointConnected.ConnectedContainerName = NamesTranslator.GetContainerName(procontelApi, @event.EndpointConnected.ConnectedContainerId);
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.EndpointConnected.Endpoint);
      }
      else if (@event.EndpointDisconnected != null)
      {
        @event.EndpointDisconnected.DisconnectedContainerName = NamesTranslator.GetContainerName(procontelApi, @event.EndpointDisconnected.DisconnectedContainerId);
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.EndpointDisconnected.Endpoint);
      }
      else if (@event.WarningReported != null)
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.WarningReported.Endpoint);
      else if (@event.WarningCleared != null)
        NamesTranslator.SetEndpointIdentity(procontelApi, @event.WarningCleared.Endpoint);

      return @event;
    }
  }
}
  
