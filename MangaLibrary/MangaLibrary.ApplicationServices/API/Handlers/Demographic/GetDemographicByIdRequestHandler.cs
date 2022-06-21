using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MangaLibrary.ApplicationServices.API.Domain.Models.Demographic;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MangaLibrary.DataAccess.CQRS.Queries.Genre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Demographic
{
    public class GetDemographicByIdRequestHandler : IRequestHandler<GetDemographicByIdRequest, GetDemographicByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetDemographicByIdRequestHandler(IQueryExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetDemographicByIdResponse> Handle(GetDemographicByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourceQuery<MangaLibrary.DataAccess.Entities.Demographic>() { Id = request.Id };
            var result = await _executor.Execute(query);
            if (result == null)
                return new GetDemographicByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Demographic with id: {request.Id} doesn't exist") };
            return new GetDemographicByIdResponse() { Data = _mapper.Map<DemographicDTO>(result) };
        }
    }
}
