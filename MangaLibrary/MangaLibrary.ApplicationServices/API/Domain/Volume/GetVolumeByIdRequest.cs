using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Volume
{
    public class GetVolumeByIdRequest:IRequest<GetVolumeByIdResponse>
    {
        public Guid Id { get; set; }

        public Guid MangaId { get; set; }
    }
}
