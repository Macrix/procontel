using ProconTel.EventHub.Connector;
using ProconTel.EventHub.Connector.Contracts.gRPC;
using System;
using System.Threading.Tasks;

namespace SampleApp
{
  class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("Hello World from EventHub connector!");

      var eventHubConnector = 
        new EventHubConnector(
          eventHubAddress: "http://localhost:9500/events",
          restApiAddress: "http://localhost:1010/api/");

      eventHubConnector.InfrastructureEventReceived += InfrastructureEventReceived;
      eventHubConnector.TrafficEventReceived += TrafficEventReceived;

      await eventHubConnector.StartAsync();

      Console.WriteLine("Press any key to stop application...");
      Console.ReadKey();

      await eventHubConnector.StopAsync();
    }

    private static void InfrastructureEventReceived(InfrastructureEvent infrastructureEvent)
    {
      Console.WriteLine(infrastructureEvent);
    }

    private static void TrafficEventReceived(TrafficEvent trafficEvent)
    {
      Console.WriteLine(trafficEvent);
    }
  }
}
