using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using RestSharp;
using System.Collections.Specialized;

namespace LearnTensesApp
{
    class Word
    {

        public string TranslateWord(string word, string language)
        {
            ContainTranslate containTranslate = new ContainTranslate();
            using (var wb = new System.Net.WebClient())
            {
                var data = new NameValueCollection();
                data["text"] = word;
                data["lang"] = language;
                data["key"] = "xxxxxxxxxxx"; //use your key

                var response = wb.UploadValues("use link api from yandex", "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
                var result = JsonConvert.DeserializeObject<ContainTranslate>(responseInString);
                return result.text[0];
            }
        }

        public bool SpellCheckerWord(string word)
        {
            var client = new RestClient("use link API");
            var request = new RestRequest($"/check/?text={word}", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "add the header of API");
            request.AddHeader("X-RapidAPI-Key", "use your key");
            IRestResponse response = client.Execute(request);
            JsonObject obj = (JsonObject)SimpleJson.DeserializeObject(response.Content);
            string wordSuggestion = (string)obj["suggestion"];
            if (word == wordSuggestion)
                return true;
            else
                return false;
        }

        public string SuggestionWord(string word)
        {
            var client = new RestClient("add API link");
            var request = new RestRequest($"/check/?text={word}", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "add API header");
            request.AddHeader("X-RapidAPI-Key", "use your key");
            IRestResponse response = client.Execute(request);
            JsonObject obj = (JsonObject)SimpleJson.DeserializeObject(response.Content);
            string wordSuggestion = (string)obj["suggestion"];

            return wordSuggestion;
        }
    }
}

