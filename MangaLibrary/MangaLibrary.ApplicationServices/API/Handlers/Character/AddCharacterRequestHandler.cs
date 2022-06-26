using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models.Character;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Character
{
    public class AddCharacterRequestHandler : IRequestHandler<AddCharacterRequest, AddCharacterResponse>
    {
        private readonly ICommandExecutor _executor;
        private readonly IMapper _mapper;

        public AddCharacterRequestHandler(ICommandExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<AddCharacterResponse> Handle(AddCharacterRequest request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Character>(request);
            var command = new AddResourceCommand<MangaLibrary.DataAccess.Entities.Character>() { Parameter = item };
            var result = await _executor.Execute(command);
            return new AddCharacterResponse() { Data = _mapper.Map<CharacterDTO>(result) };
        }
    }
}
