using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Review
{
    public class UpdateReviewRequest : IRequest<UpdateReviewResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        [JsonIgnore]
        public Guid AuthorId { get; set; }
        [JsonIgnore]
        public Guid MangaId { get; set; }
    }
}
