using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Models
{
    public class MangaDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Demographic { get; set; }
    }
}
