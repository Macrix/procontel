using Microsoft.AspNetCore.SignalR.Client;
using ProconTel.EventHub.Connector.Contracts.Extensions;
using ProconTel.EventHub.Connector.Contracts.gRPC;
using ProconTel.EventHub.Connector.Contracts.REST;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProconTel.EventHub.Connector
{
  public class EventHubConnector
  {
    public const string InfrastructureEventMethodName = "infrastructureEventReceived";
    public const string TrafficEventMethodName = "trafficEventReceived";
    
    private readonly string _restApiAddress;
    private readonly HubConnection _hubConnection;

    private List<ChannelDTO> _containers;

    public EventHubConnector(string eventHubAddress, string restApiAddress)
    {
      _restApiAddress = restApiAddress;
      _hubConnection = 
        new HubConnectionBuilder()
          .WithUrl(eventHubAddress)
          .WithAutomaticReconnect()
          .Build();
    }

    public event Action<InfrastructureEvent> InfrastructureEventReceived;
    public event Action<TrafficEvent> TrafficEventReceived;

    public Task StartAsync()
    {
      Subscribe();

      return _hubConnection.StartAsync();
    }

    public Task StopAsync()
      => _hubConnection.StopAsync();

    private void Subscribe()
    {
      _containers = GetContainerData(_restApiAddress);

      _hubConnection.On<InfrastructureEvent>(InfrastructureEventMethodName, rawEvent =>
      {
        var describedEvent = rawEvent.Describe(_containers);

        InfrastructureEventReceived?.Invoke(describedEvent);
      });

      _hubConnection.On<TrafficEvent>(TrafficEventMethodName, rawEvent =>
      {
        var describedEvent = rawEvent.Describe(_containers);

        TrafficEventReceived?.Invoke(describedEvent);
      });
    }

    private List<ChannelDTO> GetContainerData(string restApiAddress)
    {
      var connection = new RestClient(restApiAddress);
      var response = connection.Get<List<ChannelDTO>>(new RestRequest("ChannelManagerWeb/GetContainers"));
      return response.Data;
    }
  }
}
