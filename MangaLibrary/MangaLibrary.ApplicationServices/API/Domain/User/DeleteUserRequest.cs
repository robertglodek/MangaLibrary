using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.User
{
    public class DeleteUserRequest:IRequest<DeleteUserResponse>
    {
        public Guid Id { get; set; }
    }
}
