﻿using ProconTel.EventHub.Connector.Contracts.Extensions;
using System;

namespace ProconTel.EventHub.Connector.Contracts.gRPC
{
  public class InfrastructureEvent
  {
    public InfrastructureEventCase EventTypeCase { get; set; }
    public Timestamp DateTimeStamp { get; set; }
    public EndpointActivated EndpointActivated { get; set; }
    public EndpointDeactivated EndpointDeactivated { get; set; }
    public EndpointConnected EndpointConnected { get; set; }
    public EndpointDisconnected EndpointDisconnected { get; set; }
    public WarningReported WarningReported { get; set; }
    public WarningCleared WarningCleared { get; set; }
    public ContainerActivated ContainerActivated { get; set; }
    public ContainerDeactivated ContainerDeactivated { get; set; }
    public CyclicReport CyclicReport { get; set; }

    public override string ToString()
      => $"{DateTimeStamp.ToDateTime():G} {EventTypeCase}";
  }

  public enum InfrastructureEventCase
  {
    EndpointActivated = 2,
    EndpointDeactivated = 3,
    EndpointConnected = 4,
    EndpointDisconnected = 5,
    WarningReported = 9,
    WarningCleared = 10,
    ContainerActivated = 11,
    ContainerDeactivated = 12,
    CyclicReport = 13
  }

  public class EndpointActivated
  {
    public EndpointIdentity Endpoint { get; set; }
  }

  public class EndpointDeactivated
  {
    public EndpointIdentity Endpoint { get; set; }
  }

  public class EndpointConnected
  {
    public EndpointIdentity Endpoint { get; set; }
    public string ConnectedContainerId { get; set; }

    public string ConnectedContainerName { get; set; }
  }

  public class EndpointDisconnected
  {
    public EndpointIdentity Endpoint { get; set; }
    public string DisconnectedContainerId { get; set; }

    public string DisconnectedContainerName { get; set; }
  }

  public class WarningReported
  {
    public EndpointIdentity Endpoint { get; set; }
    public int WarningId { get; set; }
    public string WarningMessage { get; set; }
  }

  public class WarningCleared
  {
    public EndpointIdentity Endpoint { get; set; }
    public int WarningId { get; set; }
  }

  public class ContainerActivated
  {
    public string ContainerId { get; set; }

    public string ContainerName { get; set; }
  }

  public class ContainerDeactivated
  {
    public string ContainerId { get; set; }

    public string ContainerName { get; set; }
  }

  public class CyclicReport
  {
    public string ContainerId { get; set; }
    public long MemoryUsage { get; set; }
    public float CpuLoad { get; set; }
    public int ThreadsCount { get; set; }

    public string ContainerName { get; set; }
  }
}
