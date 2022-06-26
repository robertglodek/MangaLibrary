using MangaLibrary.ApplicationServices.Components.Jikan.Models.Manga;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Components.Jikan.Models
{
    public class JikanPagedResult<T>
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        public List<T> Result { get; set; }
    }
}
