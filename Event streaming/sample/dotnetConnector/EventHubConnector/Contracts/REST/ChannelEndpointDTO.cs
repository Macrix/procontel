using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProconTel.EventHub.Connector.Contracts.REST
{
  /// <summary>
  /// Participant's transfer object.
  /// </summary>
  public class ChannelEndpointDTO
  {
    public ChannelEndpointDTO()
    {

    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance represents endpoint which is run in isolated mode.
    /// </summary>
    public bool IsIsolated { get; set; }

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>The id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the custom id.
    /// </summary>
    /// <value>The custom id.</value>
    public string CustomId { get; set; }

    /// <summary>
    /// Gets or sets the caption.
    /// </summary>
    /// <value>The caption.</value>
    public string Caption { get; set; }

    /// <summary>
    /// Gets or sets the full name.
    /// </summary>
    /// <value>The full name.</value>
    public string EndpointPluginQualifiedName { get; set; }

    /// <summary>
    /// Gets or sets the display name.
    /// </summary>
    /// <value>The display name.</value>
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [supports provider role].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [supports provider role]; otherwise, <c>false</c>.
    /// </value>
    public bool SupportsProviderRole { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [supports subscriber role].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [supports subscriber role]; otherwise, <c>false</c>.
    /// </value>
    public bool SupportsSubscriberRole { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [acts as provider].
    /// </summary>
    /// <value><c>true</c> if [acts as provider]; otherwise, <c>false</c>.</value>
    public bool ActsAsProvider { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [acts as subscriber].
    /// </summary>
    /// <value><c>true</c> if [acts as subscriber]; otherwise, <c>false</c>.</value>
    public bool ActsAsSubscriber { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether endpoint represented by current instance is disabled.
    /// </summary>
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets value indicating whether endpoint is defined in endpoint pool.
    /// </summary>
    public bool IsRemoteEndpoint { get; set; }

    /// <summary>
    /// Gets or sets location of remote avatar.
    /// </summary>
    public string RemoteAvatarLocation { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether real endpoint of the avatar is located on remote machine. Applicable only to avatars (when <see cref="IsRemoteEndpoint"/> is set).
    /// </summary>
    public bool IsEndpointLocatedOnRemoteMachine { get; set; }

    /// <summary>
    /// Gets or sets subscribers accepted by this endpoint.
    /// </summary>
    public List<SubscriberIdInfoDto> Subscribers { get; set; }

    /// <summary>
    /// Gets or sets the excluded from providing IDs.
    /// </summary>
    public List<string> ExcludeProvidingIds { get; set; }

    /// <summary>
    /// Gets or sets flag indicating whether used subscriber ids are to be used as excluded from subscription so that all others are handled by default.
    /// </summary>
    public bool SubscriberIdsAreExcluded { get; set; }

    /// <summary>
    /// Gets or sets the default buffering options. Used only if the subscriber IDs are excluded.
    /// </summary>
    public DefaultBufferingOptions DefaultBufferingOptions { get; set; }

    /// <summary>
    /// Gets or sets delay used to startup the endpoint after all dependent endpoints are started.
    /// </summary>
    public int StartupDelay { get; set; }

    /// <summary>
    /// Gets or sets dependent endpoints inside channel.
    /// </summary>
    public List<string> StartupDependentEndpoints { get; set; }

    /// <summary>
    /// Gets or sets the type of the recovery action which is taken while a non-isolated endpoint failes.
    /// </summary>
    public RecoveryActionType RecoveryActionType { get; set; }

    /// <summary>
    /// Gets or sets the endpoint the delay of the endpoint restart if <see cref="RecoveryActionType"/> "Restart" is selected.
    /// </summary>
    public int EndpointFailureRestartDelay { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether avatar is allowed to send content.
    /// </summary>
    /// <value>
    ///   <c>true</c> if avatar is allowed to send content; otherwise, <c>false</c>.
    /// </value>
    public bool AllowSendingContent { get; set; }

    /// <summary>
    /// Gets a value indicating whether  the endpoint represents by the current instance is an authentication endpoint.
    /// </summary>
    public bool IsAuthenticationEndpoint { get; set; }

    /// <summary>
    /// Gets a value indicating whether  the endpoint represents by the current instance is an authorization endpoint.
    /// </summary>
    public bool IsAuthorizationEndpoint { get; set; }

    /// <summary>
    /// Gets the name of the endpoint container. The property may not be available in every service method.
    /// </summary>
    public string ContainerName { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? StopTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the endpoint is using custom subscriber configuration or is using a standard dialog available in the communication console.
    /// </summary>
    public bool UseCustomSubscriberConfiguration { get; set; }

    /// <summary>
    /// Gets the endpoint messages persistence rules.
    /// </summary>
    public List<MessagePersistanceRuleDTO> MessagePersistanceRules { get; set; }
  }
}
