using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Demographic
{
    public class DeleteDemographicRequest:IRequest<DeleteDemographicResponse>
    {
        public Guid Id { get; set; }
    }
}
