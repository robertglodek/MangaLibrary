using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Genre
{
    public class UpdateGenreRequest:IRequest<UpdateGenreResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
