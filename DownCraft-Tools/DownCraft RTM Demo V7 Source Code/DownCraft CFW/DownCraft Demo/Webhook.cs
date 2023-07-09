using System.IO;
using System.Net;
using System.Net.Http;

/*
 * Created this for making it easier to use
 */
namespace ForNiegil
{
    class Webhook
    {
        private HttpClient Client;
        private string Url; //Url of the webhook

        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; } //make sure that this is "" and not null if you don't wanna have it use a profile picture

        public Webhook(string webhookUrl)
        {
            Client = new HttpClient();
            Url = webhookUrl;
        }

        //method for sending the message (if file is null (which it is by default) no file will be included)
        public bool SendMessage(string content, string file = null)
        {
            MultipartFormDataContent data = new MultipartFormDataContent();
            data.Add(new StringContent(Name), "username");
            data.Add(new StringContent(ProfilePictureUrl), "avatar_url");
            data.Add(new StringContent(content), "content");

            if (file != null)
            {
                //throws exception if file doesn't exist
                if (!File.Exists(file))
                    throw new FileNotFoundException();

                byte[] bytes = File.ReadAllBytes(file);

                data.Add(new ByteArrayContent(bytes), "file", "modcraft.txt");
            }

            var resp = Client.PostAsync(Url, data).Result;

            return resp.StatusCode == HttpStatusCode.NoContent;
        }
    }
}