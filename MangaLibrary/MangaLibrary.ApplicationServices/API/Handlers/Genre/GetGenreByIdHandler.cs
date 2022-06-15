using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
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
    public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdRequest, GetGenreByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetGenreByIdHandler(IQueryExecutor executor,IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetGenreByIdResponse> Handle(GetGenreByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGenreQuery() { Id=request.Id };
            var result = await _executor.Execute(query);
            if(result==null)
            {
                return new GetGenreByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound) };
            }

            var response = new GetGenreByIdResponse()
            {
                Data = _mapper.Map<GenreDTO>(result)
            };
            return response;
        }
    }


}
