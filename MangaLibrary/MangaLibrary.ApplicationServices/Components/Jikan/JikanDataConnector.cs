using MangaLibrary.ApplicationServices.Components.Jikan.Models;
using MangaLibrary.ApplicationServices.Components.Jikan.Models.Manga;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Components.Jikan
{
    public class JikanDataConnector : IJikanDataConnector
    {
        public JikanDataConnector(IConfiguration config)
        {
            this._baseUrl = config["JikanBaseUrl"];
            this._restClient= new RestClient(this._baseUrl);
        }
        private readonly RestClient _restClient;
        private readonly string _baseUrl;
        public async Task<JikanPagedResult<MangaJikan>> Search(int page, int limit, string q)
        {
            
            var request = new RestRequest("manga",Method.Get);
            request.AddParameter("page", page);
            request.AddParameter("q", q);
            request.AddParameter("limit", limit);

            var queryResult = await _restClient.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<JikanPagedResult<MangaJikan>>(queryResult.Content,new JsonSerializerSettings() 
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
            return result;
        }
    }
}
