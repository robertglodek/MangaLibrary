using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Entities
{
    public class Genre:EntityBase
    {
        public string Name { get; set; }
        public List<Manga> Mangas { get; set; }
    }
}
