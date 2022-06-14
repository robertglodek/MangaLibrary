using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Entities
{
    public class Review:EntityBase
    {
        public string Content { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public Guid MangaId { get; set; }
        public Manga Manga { get; set; }
    }
}
