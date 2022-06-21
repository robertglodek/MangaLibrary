using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Volume
{
    public class AddVolumeRequest : IRequest<AddVolumeResponse>
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid MangaId { get; set; }
        public string Description { get; set; }
        public string Arc { get; set; }
    }
}
