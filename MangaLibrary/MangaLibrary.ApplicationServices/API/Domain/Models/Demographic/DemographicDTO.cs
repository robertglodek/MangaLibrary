using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Models.Demographic
{
    public class DemographicDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
