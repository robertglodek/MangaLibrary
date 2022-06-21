using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Volume;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
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
        private readonly ICommandExecutor _executor;
        private readonly IMapper _mapper;

        public AddVolumeRequestHandler(ICommandExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<AddVolumeResponse> Handle(AddVolumeRequest request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Volume>(request);
            var command = new AddResourceCommand<MangaLibrary.DataAccess.Entities.Volume>() { Parameter = item };
            var result = await _executor.Execute(command);
            return new AddVolumeResponse() { Data = _mapper.Map<VolumeDTO>(result) };
        }
    }
}
