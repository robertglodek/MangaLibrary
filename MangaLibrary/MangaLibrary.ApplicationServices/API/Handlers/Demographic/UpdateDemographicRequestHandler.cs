using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MangaLibrary.ApplicationServices.API.Domain.Models.Demographic;
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

namespace MangaLibrary.ApplicationServices.API.Handlers.Demographic
{
    public class UpdateDemographicRequestHandler : IRequestHandler<UpdateDemographicRequest, UpdateDemographicResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public UpdateDemographicRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<UpdateDemographicResponse> Handle(UpdateDemographicRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Demographic>() { Id = request.Id });
            if (item == null)
                return new UpdateDemographicResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Demographic with id: {request.Id} doesn't exist") };
            var command = new UpdateResourceCommand<MangaLibrary.DataAccess.Entities.Demographic>() { Parameter = _mapper.Map(request, item) };
            var result = await _commandExecutor.Execute(command);
            return new UpdateDemographicResponse() { Data = _mapper.Map<DemographicDTO>(result) };
        }
    }
}
