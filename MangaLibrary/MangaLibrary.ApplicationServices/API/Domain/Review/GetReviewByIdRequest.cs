using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Review
{
    public class GetReviewByIdRequest:IRequest<GetReviewByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
