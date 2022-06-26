using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Creator
{
    public class AddCharacterRequest:IRequest<AddCharacterResponse>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
    }
}
