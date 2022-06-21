using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Entities
{
    public class Demographic:EntityBase
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public List<Manga> Mangas { get; set; }
    }
}
