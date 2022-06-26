using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Role
{
    public class GetRoleByIdRequest:IRequest<GetRoleByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
