using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models.Creator;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Creator;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Creator
{

    public class GetCreatorByIdRequestHandler : IRequestHandler<GetCreatorByIdRequest, GetCreatorByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetCreatorByIdRequestHandler(IQueryExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetCreatorByIdResponse> Handle(GetCreatorByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourceQuery<MangaLibrary.DataAccess.Entities.Creator>() { Id = request.Id, PropertiesToInclude="Mangas" };
            var result = await _executor.Execute(query);
            if (result == null)
                return new GetCreatorByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Creator with id: {request.Id} doesn't exist")};
            return new GetCreatorByIdResponse() { Data = _mapper.Map<CreatorDetailsDTO>(result) };
        }
    }
}
