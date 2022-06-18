using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Creator
{
    public class DeleteCreatorRequest:IRequest<DeleteCreatorResponse>
    {
        public Guid Id { get; set; }
    }
}
