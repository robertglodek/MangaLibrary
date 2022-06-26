using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.Components.Jikan;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Manga
{

    public class GetMangaExternalRequestHandler : IRequestHandler<GetMangasExternalRequest, GetMangasExternalResponse>
    {
        private readonly IJikanDataConnector _connector;

        public GetMangaExternalRequestHandler(IJikanDataConnector connector)
        {
            _connector = connector;
        }
        public async Task<GetMangasExternalResponse> Handle(GetMangasExternalRequest request, CancellationToken cancellationToken)
        {
            var result = await _connector.Search(request.Page, request.Limit, request.SearchQuery);
            return new GetMangasExternalResponse() { Data=result };  
        }
    }
}
