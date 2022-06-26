using MangaLibrary.ApplicationServices.Components.Jikan.Models;
using MangaLibrary.ApplicationServices.Components.Jikan.Models.Manga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Components.Jikan
{
    public interface IJikanDataConnector
    {
        Task<JikanPagedResult<MangaJikan>> Search(int page, int limit, string q); 
    }
}
