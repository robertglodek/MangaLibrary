using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.Domain.Models.Manga;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Manga
{
    public class GetMangaByIdRequestHandler : IRequestHandler<GetMangaByIdRequest, GetMangaByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetMangaByIdRequestHandler(IQueryExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetMangaByIdResponse> Handle(GetMangaByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourceQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.Id, PropertiesToInclude= "Genres,Demographic,Creators,Characters,Reviews" };
            var result = await _executor.Execute(query);
            if (result == null)
                return new GetMangaByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Genre with id: {request.Id} doesn't exist") };
            return new GetMangaByIdResponse() { Data = _mapper.Map<MangaDetailsDTO>(result) };
        }
    }
}
