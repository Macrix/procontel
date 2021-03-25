# .NET5 connector to ProconTEL Event Streaming

Sample console application written in .NET5 to show how to connect with _ProconTEL Event Streaming_ and how to consume events. Solution contains 2 projects:

* SampleApp - console application
* EventHubConnector - wrapper for SignalR connection to _ProconTEL Event Streaming_ hub and transforms raw events into full citizen C# classes

## Building & running

In order to build use following command:

```shell
dotnet build
```

After that running is rather straightforward, however make sure you have configured _ProconTEL_ properly (see next section):
```shell
dotnet run --project SampleApp
```

## Configuration

Application is set to connect with _ProconTEL_ using default ports and addresses. In case these are changed adjust the application code accordingly.

File `%PTROOT%\Server\Serverconfig.xml`:
```xml
<ServerConfig>
  ...
  
  <EnableStatisticsMonitoring>true</EnableStatisticsMonitoring>
  <WebApiAddress>http://localhost:1010/api</WebApiAddress>

  ...
</ServerConfig>
```

File `%PTROOT%\Experimental\EventHub\appsettings.json`:

```json
{
  
  "Urls": "http://localhost:9500",

}
```
