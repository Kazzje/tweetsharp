using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Hammock.Model;
using Newtonsoft.Json;

namespace TweetSharp
{
#if !SILVERLIGHT
    /// <summary>
    /// Represents a private <see cref="TwitterStatus" /> between two users.
    /// </summary>
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterConfiguration : PropertyChangedBase, ITwitterModel
    {
        private int _maxMediaPerUpload;
        private int _shortUrlLength;
        private int _shortUrlLengthHttps;
        private int _lengthReservedPerMedia;
        private int _photoSizeLimit;

        /*
         * {
         *      "max_media_per_upload":1,
         *      "short_url_length":20,
         *      "short_url_length_https":21,
         *      "characters_reserved_per_media":21,
         *      "photo_size_limit":3145728,
         *      "photo_sizes":{"small":{"h":480,"resize":"fit","w":340},"large":{"h":2048,"resize":"fit","w":1024},"medium":{"h":1200,"resize":"fit","w":600},"thumb":{"h":150,"resize":"crop","w":150}},
         *      "non_username_paths":["about","account","accounts","activity","all","announcements","anywhere","api_rules","api_terms","apirules","apps","auth","badges","blog","business","buttons","contacts","devices","direct_messages","download","downloads","edit_announcements","faq","favorites","find_sources","find_users","followers","following","friend_request","friendrequest","friends","goodies","help","home","im_account","inbox","invitations","invite","jobs","list","login","logout","me","mentions","messages","mockview","newtwitter","notifications","nudge","oauth","phoenix_search","positions","privacy","public_timeline","related_tweets","replies","retweeted_of_mine","retweets","retweets_by_others","rules","saved_searches","search","sent","settings","share","signup","signin","similar_to","statistics","terms","tos","translate","trends","tweetbutton","twttr","update_discoverability","users","welcome","who_to_follow","widgets","zendesk_auth","media_signup"]}
         */
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int MaxMediaPerUpload
        {
            get { return _maxMediaPerUpload; }
            set
            {
                if (_maxMediaPerUpload == value)
                {
                    return;
                }

                _maxMediaPerUpload = value;
                OnPropertyChanged("MaxMediaPerUpload");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int ShortUrlLength
        {
            get { return _shortUrlLength; }
            set
            {
                if (_shortUrlLength == value)
                {
                    return;
                }

                _shortUrlLength = value;
                OnPropertyChanged("ShortUrlLength");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int ShortUrlLengthHttps
        {
            get { return _shortUrlLengthHttps; }
            set
            {
                if (_shortUrlLengthHttps == value)
                {
                    return;
                }

                _shortUrlLengthHttps = value;
                OnPropertyChanged("ShortUrlLengthHttps");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int CharactersReservedPerMedia
        {
            get { return _lengthReservedPerMedia; }
            set
            {
                if (_lengthReservedPerMedia == value)
                {
                    return;
                }

                _lengthReservedPerMedia = value;
                OnPropertyChanged("CharactersReservedPerMedia");
            }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int PhotoSizeLimit
        {
            get { return _photoSizeLimit; }
            set
            {
                if (_photoSizeLimit == value)
                {
                    return;
                }

                _photoSizeLimit = value;
                OnPropertyChanged("PhotoSizeLimit");
            }
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
