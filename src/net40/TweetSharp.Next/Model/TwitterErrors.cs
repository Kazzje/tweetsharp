using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
#if !SILVERLIGHT
    /// <summary>
    /// Represents an error received from the Twitter API.
    /// </summary>
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
    [DebuggerDisplay("{ErrorMessage} ({Request})")]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterErrors
    {
        [JsonProperty("errors")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterError[] Errors { get; set; }
    }
}
