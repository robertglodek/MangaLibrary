using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models.Creator;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Creator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Creator
{

    public class GetCreatorsRequestHandler : IRequestHandler<GetCreatorsRequest, GetCreatorsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetCreatorsRequestHandler(IMapper mapper, IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetCreatorsResponse> Handle(GetCreatorsRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetCreatorsQuery>(request);
            var result = await _executor.Execute(query);
            return new GetCreatorsResponse()
            {
                Data = new Domain.PagedResult<CreatorDTO>(_mapper.Map<List<CreatorDTO>>(result.Items)
                , result.TotalItemsCount
                , request.PageSize
                , request.PageNumber)
            };
        }
    }
}
