using MangaLibrary.ApplicationServices.Components.Jikan.Models;
using MangaLibrary.ApplicationServices.Components.Jikan.Models.Manga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Manga
{
    public class GetMangasExternalResponse:ResponseBase<JikanPagedResult<MangaJikan>>
    {
    }
}
