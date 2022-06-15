using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Genre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Genre
{
    public class GetGenreHandler : IRequestHandler<GetGenreRequest, GetGenreResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetGenreHandler(IQueryExecutor executor,IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetGenreResponse> Handle(GetGenreRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGenreQuery() { Id=request.Id };
            var result = await _executor.Execute(query);
            var response = new GetGenreResponse()
            {
                Data = _mapper.Map<GenreDTO>(result)
            };
            return response;
        }
    }


}
