using System;
using Newtonsoft.Json;

namespace ConnectNow.Requests
{
    public class UpdateUserCoverImageRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "Username")]

        public string Username { get; }

        [JsonProperty(PropertyName = "CoverImage")]

        public String CoverImage { get; }

        [JsonProperty(PropertyName = "ImageExtension")]

        public string ImageExtension { get; }


        [JsonProperty(PropertyName = "Image")]

        public String Image { get; }
        



        public UpdateUserCoverImageRequest(string userkey, string coverImage,string img, string ext)
        {
            Username = userkey;
            CoverImage = coverImage;
            Image = img;
            ImageExtension = ext;
            AuthorizationKey = Configuration.AuthorizationKey;
        }
    }
}
