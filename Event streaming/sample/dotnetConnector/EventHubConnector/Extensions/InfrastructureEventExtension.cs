using ProconTel.EventHub.Connector.Contracts.gRPC;
using ProconTel.EventHub.Connector.Contracts.REST;
using System.Collections.Generic;

namespace ProconTel.EventHub.Connector.Contracts.Extensions
{
  public static class InfrastructureEventExtension
  {
    public static InfrastructureEvent Describe(this InfrastructureEvent @event, List<ChannelDTO> procontelApi)
    {
      switch (@event.EventTypeCase)
      {
        case InfrastructureEventCase.ContainerActivated:
          @event.ContainerActivated.ContainerName = NamesTranslator.GetContainerName(procontelApi, @event.ContainerActivated.ContainerId);
          break;
        case InfrastructureEventCase.ContainerDeactivated:
          @event.ContainerDeactivated.ContainerName = NamesTranslator.GetContainerName(procontelApi, @event.ContainerDeactivated.ContainerId);
          break;
        case InfrastructureEventCase.CyclicReport:
          @event.CyclicReport.ContainerName = NamesTranslator.GetContainerName(procontelApi, @event.CyclicReport.ContainerId);
          break;
        case InfrastructureEventCase.EndpointActivated:
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.EndpointActivated.Endpoint);
          break;
        case InfrastructureEventCase.EndpointDeactivated:
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.EndpointDeactivated.Endpoint);
          break;
        case InfrastructureEventCase.EndpointConnected:
          @event.EndpointConnected.ConnectedContainerName = NamesTranslator.GetContainerName(procontelApi, @event.EndpointConnected.ConnectedContainerId);
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.EndpointConnected.Endpoint);
          break;
        case InfrastructureEventCase.EndpointDisconnected:
          @event.EndpointDisconnected.DisconnectedContainerName = NamesTranslator.GetContainerName(procontelApi, @event.EndpointDisconnected.DisconnectedContainerId);
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.EndpointDisconnected.Endpoint);
          break;
        case InfrastructureEventCase.WarningReported:
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.WarningReported.Endpoint);
          break;
        case InfrastructureEventCase.WarningCleared:
          NamesTranslator.SetEndpointIdentity(procontelApi, @event.WarningCleared.Endpoint);
          break;
      }

      return @event;
    }
  }
}
  
