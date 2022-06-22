using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MangaLibrary.ApplicationServices.API.Domain.Models.Demographic;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Demographic
{
    public class AddDemographicRequestHandler : IRequestHandler<AddDemographicRequest, AddDemographicResponse>
    {
        private readonly ICommandExecutor _executor;
        private readonly IMapper _mapper;

        public AddDemographicRequestHandler(ICommandExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<AddDemographicResponse> Handle(AddDemographicRequest request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Demographic>(request);
            var command = new AddResourceCommand<MangaLibrary.DataAccess.Entities.Demographic>() { Parameter = item };
            var result = await _executor.Execute(command);
            return new AddDemographicResponse() { Data = _mapper.Map<DemographicDTO>(result) };
        }
    }



}
