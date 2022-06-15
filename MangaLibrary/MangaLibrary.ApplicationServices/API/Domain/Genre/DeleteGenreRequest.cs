using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Genre
{
    public class DeleteGenreRequest:IRequest<DeleteGenreResponse>
    {
        public Guid Id { get; set; }
    }
}
