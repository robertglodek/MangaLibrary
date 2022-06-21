using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Demographic
{
    public class AddDemographicRequest:IRequest<AddDemographicResponse>
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
