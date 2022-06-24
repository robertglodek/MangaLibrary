using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Demographic
{
    public class UpdateDemographicRequest:IRequest<UpdateDemographicResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
