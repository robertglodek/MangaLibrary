using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Volume;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
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

namespace MangaLibrary.ApplicationServices.API.Handlers.Volume
{
    public class AddVolumeRequestHandler : IRequestHandler<AddVolumeRequest, AddVolumeResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public AddVolumeRequestHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        public async Task<AddVolumeResponse> Handle(AddVolumeRequest request, CancellationToken cancellationToken)
        {
            var mangaExists = await _queryExecutor.Execute(new ResourceExistsQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.MangaId });
            if (!mangaExists)
                return new AddVolumeResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Manga with id: {request.MangaId} doesn't exist") };

            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Volume>(request);
            var command = new AddResourceCommand<MangaLibrary.DataAccess.Entities.Volume>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new AddVolumeResponse() { Data = _mapper.Map<VolumeDTO>(result) };
        }
    }
}
