using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Volume
{
    public class UpdateVolumeRequest : IRequest<UpdateVolumeResponse>
    {
        [IgnoreDataMember]
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Arc { get; set; }
        [IgnoreDataMember]
        public Guid MangaId { get; set; }
    }
}
