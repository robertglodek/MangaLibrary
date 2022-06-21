using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models.Creator;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Creator
{
    public class AddCreatorRequestHandler : IRequestHandler<AddCreatorRequest, AddCreatorResponse>
    {
        private readonly ICommandExecutor _executor;
        private readonly IMapper _mapper;

        public AddCreatorRequestHandler(ICommandExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<AddCreatorResponse> Handle(AddCreatorRequest request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Creator>(request);
            var command = new AddResourceCommand<MangaLibrary.DataAccess.Entities.Creator>() { Parameter = item };
            var result = await _executor.Execute(command);
            return new AddCreatorResponse() { Data = _mapper.Map<CreatorDTO>(result) };
        }
    }
}
