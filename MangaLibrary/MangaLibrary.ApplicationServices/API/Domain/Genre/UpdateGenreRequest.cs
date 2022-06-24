using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Genre
{
    public class UpdateGenreRequest:IRequest<UpdateGenreResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
