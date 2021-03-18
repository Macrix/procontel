using ProconTel.EventHub.Connector.Contracts.gRPC;
using ProconTel.EventHub.Connector.Contracts.REST;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProconTel.EventHub.Connector.Contracts.Extensions
{
  internal static class NamesTranslator
  {
    public static void SetEndpointIdentity(List<ChannelDTO> procontelApi, EndpointIdentity endpointIdentity)
    {
      endpointIdentity.ContainerName = GetContainerName(procontelApi, endpointIdentity.ContainerId);
      endpointIdentity.EndpointName = GetEndpointName(procontelApi, endpointIdentity.ContainerId, endpointIdentity.EndpointId);
    }

    public static string GetContainerName(List<ChannelDTO> procontelApi, string containerId)
      => String.IsNullOrEmpty(containerId)
          ? string.Empty
          : procontelApi.First(x => x.ContainerId == containerId).Name;

    public static string GetEndpointName(List<ChannelDTO> procontelApi, string containerId, string endpointId)
      => String.IsNullOrEmpty(containerId)
          ? procontelApi.SelectMany(x => x.Endpoints).First(z => z.Id == endpointId).CustomId
          : procontelApi.First(x => x.ContainerId == containerId).Endpoints.First(z => z.Id == endpointId).CustomId;
  }
}
  
