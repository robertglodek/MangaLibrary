using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Manga
{
    public class GetMangaByIdRequest:IRequest<GetMangaByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
