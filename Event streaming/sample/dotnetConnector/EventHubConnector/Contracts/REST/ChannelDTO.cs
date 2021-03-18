using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProconTel.EventHub.Connector.Contracts.REST
{
  /// <summary>
  /// Channel's transfer object.
  /// </summary>
  public class ChannelDTO
  {

    public ChannelDTO()
    {

    }

    /// <summary>
    /// Gets or sets the ID of the container (set by the ProconTEL server, otherwise ignored).
    /// </summary>
    public string ContainerId { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [automatic startup].
    /// </summary>
    /// <value><c>true</c> if [automatic startup]; otherwise, <c>false</c>.</value>
    public bool AutomaticStartup { get; set; }

    /// <summary>
    /// Gets or sets the name of the workspace.
    /// </summary>
    /// <value>The name of the workspace.</value>
    public string WorkspaceName { get; set; }

    /// <summary>
    /// Gets or sets the providers.
    /// </summary>
    /// <value>The providers.</value>
    public List<ChannelEndpointDTO> Endpoints { get; set; }

    /// <summary>
    /// Gets or sets value whether this channel is an endpoint pool.
    /// </summary>
    public bool IsEndPointPool { get; set; }

    /// <summary>
    /// Gets or sets delay used to startup the channel after all dependent channels are started.
    /// </summary>
    public int StartupDelay { get; set; }

    /// <summary>
    /// Gets or sets dependent channels.
    /// </summary>
    public List<string> StartupDependentChannels { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether database logging is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if database logging is enabled; otherwise, <c>false</c>.
    /// </value>
    public bool EnableDatabaseLogging { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether redirection from standard output to the logger is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if the redirection is enabled; otherwise, <c>false</c>.
    /// </value>
    public bool RedirectStdOut { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether redirection from standard error to the logger is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if the redirection is enabled; otherwise, <c>false</c>.
    /// </value>
    public bool RedirectStdErr { get; set; }

    /// <summary>
    /// Gets or sets the database logging connection string.
    /// </summary>
    /// <value>The database logging connection string.</value>
    public string DatabaseLoggingConnectionString { get; set; }

    /// <summary>
    /// Gets or sets the name of the table used in database logging.
    /// </summary>
    /// <value>The name of the table used in database logging.</value>
    public string DatabaseLoggingTableName { get; set; }

    /// <summary>
    /// Gets or sets the type of the database logging database.
    /// </summary>
    /// <value>The type of the database logging database.</value>
    public string DatabaseLoggingDbType { get; set; }

    /// <summary>
    /// Gets or sets the database logging buffer size.
    /// </summary>
    /// <value>The database logging buffer size.</value>
    public int DatabaseLoggingBufferSize { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether logging to file is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if logging to file is enabled; otherwise, <c>false</c>.
    /// </value>
    public bool EnableFileLogging { get; set; }

    /// <summary>
    /// Gets or sets the logging level.
    /// </summary>
    /// <value>The logging level.</value>
    public MessageSeverity LoggingSeverity { get; set; }

    /// <summary>
    /// Gets or sets the user name under which service will be run./>
    /// is used as default.
    /// </summary>
    public string ServiceUsername { get; set; }

    /// <summary>
    /// Gets or sets the password for user under which service will be run.
    /// </summary>
    public string ServicePassword { get; set; }

    /// <summary>
    /// Gets or sets the channel specific collection of environment variables.
    /// </summary>
    public string EnvironmentVariables { get; set; }

    /// <summary>
    /// Gets or sets the type of the recovery action which is taken while a non-isolated endpoint fails.
    /// </summary>
    public RecoveryActionType RecoveryActionType { get; set; }

    /// <summary>
    /// Gets or sets the endpoint the delay of the endpoint restart if <see cref="RecoveryActionType"/> "Restart" is selected.
    /// </summary>
    public int EndpointFailureRestartDelay { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the channel/pool process should be restarted when unhandled failure occurs.
    /// </summary>
    public bool RestartProcessOnFailure { get; set; }

    /// <summary>
    /// Gets or sets the time after which to reset the failure count to zero if there are no failures, in seconds.
    /// </summary>
    public int ProcessFailureResetPeriod { get; set; }

    /// <summary>
    /// Gets or sets the number of subsequent restarts after failure.
    /// </summary>
    public int ProcessFailureRestartsCount { get; set; }

    /// <summary>
    /// Gets or sets the process restart delay.
    /// </summary>
    public int ProcessRestartDelay { get; set; }

    /// <summary>
    /// Gets or sets the process maximum allowed memory.
    /// </summary>
    public int MaximumMemoryWorkingSet { get; set; }

    /// <summary>
    /// Gets or sets the information whether the process must be restarted after the memory limit is reached.
    /// </summary>
    public bool RestartOnMemoryLimitExceeded { get; set; }

    /// <summary>
    /// Gets or sets the process restart delay after the memory limit was exceeded.
    /// </summary>
    public int MemoryExeceededRestartDelay { get; set; }

    /// <summary>
    /// Gets or sets the process priority.
    /// </summary>
    public ProcessPriorityClass ProcessPriority { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? StopTime { get; set; }

    /// <summary>
    /// Gets or sets the database file options.
    /// </summary>
    public int FileOptions { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of files to be stored.
    /// </summary>
    public int MaxNumberOfFiles { get; set; }

    /// <summary>
    /// Gets or sets the database file rolling policy type.
    /// </summary>
    public int RollingPolicy { get; set; }

    /// <summary>
    /// Gets or sets the maximum size of the database file expressed in bytes.
    /// </summary>
    public int MaxFileSize { get; set; }

    /// <summary>
    /// Gets or sets the file creation frequency value expressed in milliseconds.
    /// </summary>
    public int FileCreationFrequency { get; set; }
  }
}
