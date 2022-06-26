using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Entities
{
    public class Character : EntityBase
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public List<Manga> Mangas {get;set;}
    }
}
