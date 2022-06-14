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
        public string Publisher { get; set; }
        public string Demographic { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Volume> Volumes { get; set; }
        public IEnumerable<Genre> Genres { get; set; }  
        public IEnumerable<Creator> Creators { get; set; }  
        public IEnumerable<Review> Reviews { get; set; }     
    }
}
