using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Character
{
    public class UpdateCharacterRequest:IRequest<UpdateCharacterResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
    }
}
