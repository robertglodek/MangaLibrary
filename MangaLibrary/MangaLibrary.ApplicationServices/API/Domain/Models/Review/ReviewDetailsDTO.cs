using MangaLibrary.ApplicationServices.API.Domain.Models.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models.Manga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Models.Review
{
    public class ReviewDetailsDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public CreatorDTO Author { get; set; }
    }
}
