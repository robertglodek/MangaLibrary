using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Models
{
    public class CreatorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }
        public IEnumerable<MangaDTO> Mangas { get; set; }
    }
}
