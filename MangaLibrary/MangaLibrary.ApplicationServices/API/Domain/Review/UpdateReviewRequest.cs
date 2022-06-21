using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Review
{
    public class UpdateReviewRequest : IRequest<UpdateReviewResponse>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public Guid AuthorId { get; set; }
        public Guid MangaId { get; set; }
    }
}
