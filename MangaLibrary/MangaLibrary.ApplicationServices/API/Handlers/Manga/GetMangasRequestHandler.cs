using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.Domain.Models.Manga;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Manga;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Manga
{
    public class GetMangasRequestHandler : IRequestHandler<GetMangasRequest, GetMangasResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetMangasRequestHandler(IMapper mapper, IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetMangasResponse> Handle(GetMangasRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetMangasQuery>(request);
            var result = await _executor.Execute(query);
            return new GetMangasResponse()
            {
                Data = new Domain.PagedResult<MangaDetailsDTO>(_mapper.Map<List<MangaDetailsDTO>>(result.Items)
                , result.TotalItemsCount
                , request.PageSize
                , request.PageNumber)
            };
        }
    }
}
