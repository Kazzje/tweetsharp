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
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterError : ITwitterModel
    {
        [JsonProperty("code")]
        public virtual int Code { get; set; }

        [JsonProperty("message")]
        public virtual string Message { get; set; }

        [JsonProperty("error")]
        public virtual string Error { get; set; }

        [JsonProperty("request")]
        public virtual string Request { get; set; }

        public string ErrorMessage
        {
            get { return string.IsNullOrEmpty(Message) ? Error : Message; }
        }

        public override string ToString()
        {
            return Message;
        }

#if !Smartphone && !NET20
        /// <summary>
        /// The source content used to deserialize the model entity instance.
        /// Can be XML or JSON, depending on the endpoint used.
        /// </summary>
        [DataMember]
#endif
        public virtual string RawSource { get; set; }
    }
}