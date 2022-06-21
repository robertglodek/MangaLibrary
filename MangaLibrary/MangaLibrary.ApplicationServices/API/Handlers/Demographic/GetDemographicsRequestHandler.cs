using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MangaLibrary.ApplicationServices.API.Domain.Models.Demographic;
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
    public class GetDemographicsRequestHandler : IRequestHandler<GetDemographicsRequest, GetDemographicsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetDemographicsRequestHandler(IMapper mapper, IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetDemographicsResponse> Handle(GetDemographicsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourcesQuery<MangaLibrary.DataAccess.Entities.Demographic>();
            var result = await _executor.Execute(query);
            return new GetDemographicsResponse() { Data = _mapper.Map<List<DemographicDTO>>(result) };
        }
    }
}
