using MangaLibrary.ApplicationServices.API.Domain.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Review
{
    public class GetReviewsResponse:ResponseBase<PagedResult<ReviewDetailsDTO>>
    {
    }
}
