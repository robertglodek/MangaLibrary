using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Components.Jikan.Models
{
    public class Pagination
    {
        [JsonProperty("last_visible_page")]
        public int LastVisiblePage { get; set; }
        [JsonProperty("has_next_page")]
        public string HasNextPage { get; set; }
        [JsonProperty("items")]
        public Items Items { get; set; }    
    }
}
