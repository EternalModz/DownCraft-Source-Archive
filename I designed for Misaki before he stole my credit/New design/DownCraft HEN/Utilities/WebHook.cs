using System.IO;
using System.Net;
using System.Net.Http;

namespace Flagsec
{
    class Webhook
    {
        private HttpClient Client;
        private string Url;

        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }

        public Webhook(string webhookUrl)
        {
            Client = new HttpClient();
            Url = webhookUrl;
        }

        public bool SendMessage(string content, string file = null)
        {
            MultipartFormDataContent data = new MultipartFormDataContent();
            data.Add(new StringContent(Name), "username");
            data.Add(new StringContent(ProfilePictureUrl), "avatar_url");
            data.Add(new StringContent(content), "content");

            if (file != null)
            {
                if (!File.Exists(file))
                    throw new FileNotFoundException();

                byte[] bytes = File.ReadAllBytes(file);

                data.Add(new ByteArrayContent(bytes), "file", "get.txt"); //change "file" to "file.(extention) if you wish to download as ext
            }

            var resp = Client.PostAsync(Url, data).Result;

            return resp.StatusCode == HttpStatusCode.NoContent;
        }
    }
}