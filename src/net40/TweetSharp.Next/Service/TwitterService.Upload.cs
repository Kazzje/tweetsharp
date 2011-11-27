using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hammock.Authentication.OAuth;
using Hammock.Web;

namespace TweetSharp
{
    public partial class TwitterService
    {
#if WINDOWS_PHONE
        
        //TODO: Autogenerate this method
        public virtual void SendTweetWithMedia(string status, bool possiblySensetive, System.IO.Stream[] imageStreams, Action<TwitterStatus, TwitterResponse> action)
        {
            //WithHammock(WebMethod.Post, action, imageStreams, "statuses/update_with_media", FormatAsString, "?status=", status, "&possibly_sensetive=", possiblySensetive);

            string path = ResolveUrlSegments("statuses/update_with_media", new List<object> {FormatAsString, "?status=", status, "&possibly_sensetive=", possiblySensetive});

            _client.Authority = Globals.UploadAPIAuthority;
            _client.VersionPath = "1";

            var request = PrepareHammockQuery(path);
            request.Method = WebMethod.Post;
            var oauthCreds = (OAuthCredentials) request.Credentials;
            oauthCreds.ParameterHandling = OAuthParameterHandling.UrlOrPostParameters;

            foreach (var imageStream in imageStreams)
            {
                request.AddFile("media[]", "img", imageStream);
            }

            WithHammockImpl(request, action);
        }

        public virtual void SendTweetWithMedia(string status, bool possiblySensetive, System.IO.Stream[] imageStreams, double lat, double @long, Action<TwitterStatus, TwitterResponse> action)
        {
            //WithHammock(WebMethod.Post, action, imageStreams, "statuses/update_with_media", FormatAsString, "?status=", status, "&possibly_sensetive=", possiblySensetive);

            string path = ResolveUrlSegments("statuses/update_with_media", new List<object> { FormatAsString, "?status=", status, "&possibly_sensetive=", possiblySensetive, "&lat=", lat, "&long=", @long });

            _client.Authority = Globals.UploadAPIAuthority;
            _client.VersionPath = "1";

            var request = PrepareHammockQuery(path);
            request.Method = WebMethod.Post;
            var oauthCreds = (OAuthCredentials)request.Credentials;
            oauthCreds.ParameterHandling = OAuthParameterHandling.UrlOrPostParameters;

            foreach (var imageStream in imageStreams)
            {
                request.AddFile("media[]", "img", imageStream);
            }

            WithHammockImpl(request, action);
        }
#endif
    }
}
