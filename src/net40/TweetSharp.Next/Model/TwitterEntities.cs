using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    /*
     <entities>
        <user_mentions>
            <user_mention end="12" start="3">
                <id>972651</id>
                <screen_name>mashable</screen_name>
                <name>Pete Cashmore</name>
            </user_mention>
            <user_mention end="22" start="13">
                <id>13058772</id>
                <screen_name>LinkedIn</screen_name>
                <name>LinkedIn</name>
            </user_mention>
        </user_mentions>
        <urls>
            <url end="83" start="63">
            <url>http://bit.ly/bkB7cA</url>
            </url>
        </urls>
        <hashtags>
            <hashtag end="93" start="84">
            <text>linkedin</text>
            </hashtag>
            <hashtag end="101" start="94">
            <text>tweets</text>
            </hashtag>
            <hashtag end="110" start="102">
            <text>twitter</text>
            </hashtag>
        </hashtags>
        </entities>
     */

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterEntities : IEnumerable<TwitterEntity>
    {
        [JsonProperty("user_mentions")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual IList<TwitterMention> Mentions { get; set; }

        [JsonProperty("hashtags")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual IList<TwitterHashTag> HashTags { get; set; }

        [JsonProperty("urls")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual IList<TwitterUrl> Urls { get; set; }

        [JsonProperty("media")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual IList<TwitterMedia> Media { get; set; }

        public TwitterEntities()
        {
            Initialize();
        }

        private void Initialize()
        {
            Mentions = new List<TwitterMention>(0);
            HashTags = new List<TwitterHashTag>(0);
            Urls = new List<TwitterUrl>(0);
            Media = new List<TwitterMedia>();
        }

        public IEnumerable<TwitterEntity> Coalesce()
        {
#if !WINDOWS_PHONE
            var entities = new List<TwitterEntity>(Mentions.Count() + HashTags.Count() + Urls.Count() + Media.Count());
            entities.AddRange((IEnumerable<TwitterEntity>)Mentions);
            entities.AddRange((IEnumerable<TwitterEntity>)HashTags);
            entities.AddRange((IEnumerable<TwitterEntity>)Urls);
            //entities.AddRange((IEnumerable<TwitterEntity>)Media);
            entities.Sort();
#else
            var entities = new List<TwitterEntity>(Mentions.Count() + HashTags.Count() + Urls.Count() + Media.Count());
            entities.AddRange(Mentions.Cast<TwitterEntity>());
            entities.AddRange(HashTags.Cast<TwitterEntity>());
            entities.AddRange(Urls.Cast<TwitterEntity>());
            //entities.AddRange(Media.Cast<TwitterEntity>());
            entities.Sort();
#endif

            return entities;
        }

        public IEnumerator<TwitterEntity> GetEnumerator()
        {
            return Coalesce().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class TwitterEntity : IComparable<TwitterEntity>, IComparer<TwitterEntity>
    {
        [JsonProperty("indices")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual IList<int> Indices
        {
            get;
            set;
        }

        [JsonProperty("entity_type")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterEntityType Type { get; protected set; }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int StartIndex { get { return Indices.Count > 0 ? Indices[0] : -1; } }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int EndIndex { get { return Indices.Count > 1 ? Indices[1] : -1; } }

        public virtual int CompareTo(TwitterEntity other)
        {
            return StartIndex.CompareTo(other.StartIndex);
        }

        public virtual int Compare(TwitterEntity x, TwitterEntity y)
        {
            return x.StartIndex.CompareTo(y.StartIndex);
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterUrl : TwitterEntity
    {
        [JsonProperty("url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Value { get; set; }

        [JsonProperty("expanded_url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string ExpandedValue { get; set; }

        public TwitterUrl()
        {
            Initialize();
        }

        private void Initialize()
        {
            Type = TwitterEntityType.Url;
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterMention : TwitterEntity
    {
        [JsonProperty("id")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual long Id { get; set; }

        [JsonProperty("screen_name")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string ScreenName { get; set; }

        [JsonProperty("name")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Name { get; set; }

        public TwitterMention()
        {
            Type = TwitterEntityType.Mention;
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterHashTag : TwitterEntity
    {
        [JsonProperty("text")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Text { get; set; }

        public TwitterHashTag()
        {
            Initialize();
        }

        private void Initialize()
        {
            Type = TwitterEntityType.HashTag;
        }
    }


#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterMedia : TwitterEntity
    {
        [JsonProperty("id")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual long Id { get; set; }

        [JsonProperty("media_url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string MediaUrl { get; set; }

        [JsonProperty("media_url_https")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string MediaUrlHttps { get; set; }

        [JsonProperty("url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Url { get; set; }

        [JsonProperty("display_url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string DisplayUrl { get; set; }

        [JsonProperty("expanded_url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string ExpandedUrl { get; set; }

        private string _type;

        [JsonProperty("type")]
#if !Smartphone && !NET20
        [DataMember]
#endif
            public virtual string MediaType
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        [JsonProperty("sizes")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterMediaSizes Sizes { get; set; }
            
        public TwitterMedia()
        {
            Initialize();
        }

        private void Initialize()
        {
            Type = TwitterEntityType.Media;
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterMediaSizes
    {
        [JsonProperty("large")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public TwitterMediaSize Large { get; set; }

        [JsonProperty("medium")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public TwitterMediaSize Medium { get; set; }

        [JsonProperty("small")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public TwitterMediaSize Small { get; set; }

        [JsonProperty("thumb")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public TwitterMediaSize Thumb { get; set; }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterMediaSize
    {
        [JsonProperty("w")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public int Width { get; set; }

        [JsonProperty("h")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public int Height { get; set; }

        [JsonProperty("resize")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public string Resize { get; set; }
    }
}
