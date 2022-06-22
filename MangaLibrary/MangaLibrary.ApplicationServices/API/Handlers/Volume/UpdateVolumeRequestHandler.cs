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
    public class UpdateVolumeRequestHandler : IRequestHandler<UpdateVolumeRequest, UpdateVolumeResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public UpdateVolumeRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<UpdateVolumeResponse> Handle(UpdateVolumeRequest request, CancellationToken cancellationToken)
        {
            var mangaExists = await _queryExecutor.Execute(new ResourceExistsQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.MangaId });
            if (!mangaExists)
                return new UpdateVolumeResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Manga with id: {request.MangaId} doesn't exist") };

            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Volume>() { Id = request.Id });
            if (item == null)
                return new UpdateVolumeResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Volume with id: {request.Id} doesn't exist") };
            var command = new UpdateResourceCommand<MangaLibrary.DataAccess.Entities.Volume>() { Parameter = _mapper.Map(request, item) };
            var result = await _commandExecutor.Execute(command);
            return new UpdateVolumeResponse() { Data = _mapper.Map<VolumeDTO>(result) };

        }
    }
}
