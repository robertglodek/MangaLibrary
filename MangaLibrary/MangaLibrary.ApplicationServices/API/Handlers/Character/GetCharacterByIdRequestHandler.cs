using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Character;
using MangaLibrary.ApplicationServices.API.Domain.Models.Character;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Character
{
    public class GetCharacterByIdRequestHandler : IRequestHandler<GetCharacterByIdRequest, GetCharacterByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetCharacterByIdRequestHandler(IQueryExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetCharacterByIdResponse> Handle(GetCharacterByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourceQuery<MangaLibrary.DataAccess.Entities.Creator>() { Id = request.Id, PropertiesToInclude = "Mangas" };
            var result = await _executor.Execute(query);
            if (result == null)
                return new GetCharacterByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Character with id: {request.Id} doesn't exist") };
            return new GetCharacterByIdResponse() { Data = _mapper.Map<CharacterDetailsDTO>(result) };
        }
    }
}
