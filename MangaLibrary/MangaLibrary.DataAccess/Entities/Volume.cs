using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Entities
{
    public class Volume:EntityBase
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public Guid MangaId { get; set; }
        public Manga Manga { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
    }
}
