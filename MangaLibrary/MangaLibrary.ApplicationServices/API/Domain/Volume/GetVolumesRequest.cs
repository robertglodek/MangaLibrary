using MangaLibrary.DataAccess.CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Volume
{
    public class GetVolumesRequest:IRequest<GetVolumesResponse>
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        [IgnoreDataMember]
        public Guid MangaId { get; set; }
    }
}
