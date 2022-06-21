using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Models.Volume
{
    public class VolumeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Arc { get; set; }
    }
}
