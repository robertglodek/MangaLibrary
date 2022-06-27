using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Components.Jikan.Models.Manga
{
    public class MangaJikan
    {
        [JsonProperty("mal_id")]
        public int Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("publishing")]
        public string Publishing { get; set; }
        [JsonProperty("score")]
        public double Score { get; set; }
        [JsonProperty("scored_by")]
        public int ScoredBy { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("members")]
        public int Members { get; set; }
        [JsonProperty("favorites")]
        public int Favorites { get; set; }
        [JsonProperty("popularity")]
        public int Popularity { get; set; }
        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }
    }
}
