using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.User
{
    public class UpdateUserRequest:IRequest<UpdateUserResponse>
    {
        [IgnoreDataMember]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
