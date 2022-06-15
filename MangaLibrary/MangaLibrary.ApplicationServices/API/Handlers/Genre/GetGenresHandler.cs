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
    public class GetGenresHandler : IRequestHandler<GetGenresRequest, GetGenresResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetGenresHandler(IMapper mapper,IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetGenresResponse> Handle(GetGenresRequest request, CancellationToken cancellationToken)
        {

            throw new Exception("Some");
            var query = new GetGenresQuery();
            var result = await _executor.Execute(query);
            var response = new GetGenresResponse()
            {
                Data = _mapper.Map<List<GenreDTO>>(result)
            };
            return response;
        }
    }
}
