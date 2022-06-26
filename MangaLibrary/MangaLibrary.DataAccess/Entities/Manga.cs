using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Entities
{
    public class Manga:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public string Image { get; set; }
        public List<Character> Characters { get; set; }
        public string Status { get; set; }
        public bool AnimeAdaptation { get; set; }
        public Guid DemographicId { get; set; }
        public Demographic Demographic { get; set; }
        public List<Volume> Volumes { get; set; }
        public List<Genre> Genres { get; set; }  
        public List<Creator> Creators { get; set; }  
        public List<Review> Reviews { get; set; }     
    }
}
