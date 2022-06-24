using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Manga
{
    public class UpdateMangaRequest:IRequest<UpdateMangaResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public string Heroes { get; set; }
        public string Status { get; set; }
        public bool AnimeAdaptation { get; set; }
        public Guid DemographicId { get; set; }
        public IEnumerable<Guid> CreatorsIds { get; set; }
        public IEnumerable<Guid> GenresIds { get; set; }
    }
}
