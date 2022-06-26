using MangaLibrary.ApplicationServices.API.Domain.Models.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Creator
{
    public class GetCreatorsResponse:ResponseBase<PagedResult<CreatorDTO>>
    {
    }
}
