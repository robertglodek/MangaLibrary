using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Creator
{
    public class UpdateCreatorRequest:IRequest<UpdateCreatorResponse>
    {
        [IgnoreDataMember]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Description { get; set; }
    }
}
