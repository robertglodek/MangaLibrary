using MangaLibrary.ApplicationServices.API.Domain.Models;
using MangaLibrary.DataAccess.CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.User
{
    public class GetUsersRequest:IRequest<GetUsersResponse>
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
