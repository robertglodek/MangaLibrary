using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Character;
using MangaLibrary.ApplicationServices.API.Domain.Models.Character;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
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
    public class UpdateCharacterRequestHandler : IRequestHandler<UpdateCharacterRequest, UpdateCharacterResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public UpdateCharacterRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<UpdateCharacterResponse> Handle(UpdateCharacterRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Character>() { Id = request.Id });
            if (item == null)
                return new UpdateCharacterResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Character with id: {request.Id} doesn't exist") };
            var command = new UpdateResourceCommand<MangaLibrary.DataAccess.Entities.Character>() { Parameter = _mapper.Map(request, item) };
            var result = await _commandExecutor.Execute(command);
            return new UpdateCharacterResponse() { Data = _mapper.Map<CharacterDTO>(result) };
        }
    }
}
