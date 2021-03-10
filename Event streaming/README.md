# Event Streaming

## Introduction

What is ProconTEL streaming.


## What you can find here?

Documentation contains information about available events and defines scenarios in which events are published. Description of each event contains definition of event data structure and usage scenario written in BDD (behavioral driven design).

## Common definitions

List of common definitions which are used when defining events.

### Standard endpoints

ProconTEL comes with pre-installed set of endpoints which are called _Standard Endpoints_. In this document only a subset of all pre-installed endpoints is refered to as _Standard Endpoints_ and these are:
- _Database Telegram Writer_,
- _Telegram Cache_,
- _Mailslot Telegram Handler_,
- _TCP Telegram Handler_,
- _UDP Telegram Handler_.

All comes from one library `ProconTel.CommunicationCenter.StandardEndpoints` and uses legacy content processing methods.

### Endpoint Identity

Allows to uniquely identify ProconTEL endpoint. 

```csharp
public class EndpointIdentity
{
    public string ContainerId { get; set; }
    public string EndpointId { get; set; }
}
```

## Events definition

Below you can find all available events.

### Message received
Event `MessageReceived` is published when message is received by channel.

Event content:
```csharp
public string DestinationContainerId { get; set; }
public EndpointIdentity Sender { get; set; }
public string MessageId { get; set; }
public Guid CorrelationId { get; set; }
public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
public int MessageSize { get; set; }
```

Usage scenarios:

```gherkin
Scenario: message received from channel
Given sender is in channel
 When message is received by channel
 Then event is published
```

```gherkin
Scenario: message received from pool
Given sender is in pool
  And sender has an active and connected avatar in channel
 When message is received by channel
 Then event is published
```

```gherkin
Scenario: message not received from pool 
Given sender is in pool
  And sender has no active or connected avatar in channel
 When message is not received by channel
 Then event is not published
```

### Message enqueued
Event `MessageEnqueued` is published when message is added to endpoint internal queue.

Event content:
```csharp
public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
public string MessageId { get; set; }
public Guid CorrelationId { get; set; }
public EndpointIdentity Queue { get; set; }
```

Usage scenarios:

```gherkin
Scenario: message enqueued by endpoints` queue in channel
Given receiver is an endpoint in channel
 When message enqueued by endpoints` queue 
 Then event is published
```

```gherkin
Scenario: message enqueued by endpoints` queue in pool
Given receiver is an endpoint in pool
  And receiver has an active and connected avatar in channel
 When message is received by pool
 Then event is published
```

```gherkin
Scenario: message enqueued by standard endpoints` queue in channel
Given receiver is a standard endpoint in channel
 When message enqueued by endpoints` queue 
 Then event is published
```

```gherkin
Scenario: message enqueued by standard endpoints` queue in pool
Given receiver is a standard endpoint in pool
  And receiver has an active and connected avatar in channel
 When message is received by pool
 Then event is published
```

### Message delivered
Event `MessageDelivered` is published when endpoint is about to start processing message.

Event content:
```csharp
public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
public string MessageId { get; set; }
public Guid CorrelationId { get; set; }
public EndpointIdentity Receiver { get; set; }
```

Usage scenarios:

```gherkin
Scenario: message delivered to endpoint in channel
Given receiver is an endpoint in channel
 When message is received by endpoint 
 Then event is published
```

```gherkin
Scenario: message delivered to endpoint in pool
Given receiver is an endpoint in pool
  And receiver has an active and connected avatar in channel
 When message is received by endpoint
 Then event is published
```

```gherkin
Scenario: message delivered to standard endpoint in channel
Given receiver is a standard endpoint in channel
 When message is received by endpoint 
 Then event is published
```

```gherkin
Scenario: message delivered to standard endpoint in pool
Given receiver is a standard endpoint in pool
  And receiver has an active and connected avatar in channel
 When message is received by pool
 Then event is published
```

### Message processed
Event `MessageProcessed` is published when endpoint finished processing message.

Event content:
```csharp

```

Usage scenarios:

```gherkin
Scenario: 
Given 
 When 
 Then 
```