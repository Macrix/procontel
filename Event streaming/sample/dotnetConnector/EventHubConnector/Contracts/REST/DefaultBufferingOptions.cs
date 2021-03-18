using System;

namespace ProconTel.EventHub.Connector.Contracts.REST
{
  [Serializable]
  public class DefaultBufferingOptions
  {
    public DefaultBufferingOptions()
    {
      BufferSize = 1000;
      RejectNewest = true;
      RequestMissedContentAtProvider = false;
    }
    public DefaultBufferingOptions(int bufferSize, bool requestMissedContentAtProvider, bool deleteOldest)
    {
      BufferSize = bufferSize;
      RequestMissedContentAtProvider = requestMissedContentAtProvider;
      RejectNewest = deleteOldest;
    }
    public int BufferSize { get; set; }
    public bool RequestMissedContentAtProvider { get; set; }
    public bool RejectNewest { get; set; }
  }
}
