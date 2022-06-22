using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models.Genre;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Genre
{
    public class GetGenresRequestHandler : IRequestHandler<GetGenresRequest, GetGenresResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetGenresRequestHandler(IMapper mapper,IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetGenresResponse> Handle(GetGenresRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourcesQuery<MangaLibrary.DataAccess.Entities.Genre>();
            var result = await _executor.Execute(query);
            return new GetGenresResponse() { Data = _mapper.Map<List<GenreDTO>>(result) };
        }
    }
}
