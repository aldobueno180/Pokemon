using Newtonsoft.Json.Linq;
using Pokemon.Core.Repositories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.EntityFrameworkCore.Repositories
{
    public class ShakespeareWebAppRepository : IShakespeareWebAppRepository
    {
        public async Task<string> TranslateText(string text)
        {
            try
            {
                RestClient client = new RestClient("https://api.funtranslations.com/translate/");
                RestRequest request = new RestRequest("/shakespeare.json", Method.GET);
                request.AddParameter("text", text);
                request.RequestFormat = DataFormat.Json;
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    JObject json = JObject.Parse(response.Content);
                    var translated = json.SelectToken("contents.translated");
                    return translated.ToString();
                }
                else
                {
                    throw new Exception("Shakespeare server no response");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
    }
}
