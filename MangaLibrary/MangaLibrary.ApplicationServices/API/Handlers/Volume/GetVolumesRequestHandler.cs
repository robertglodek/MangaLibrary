using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Volume;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Volume;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Volume
{
    public class GetVolumesRequestHandler : IRequestHandler<GetVolumesRequest, GetVolumesResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetVolumesRequestHandler(IMapper mapper, IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetVolumesResponse> Handle(GetVolumesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetVolumesQuery()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchPhrase = request.SearchPhrase,
                SortBy = request.SortBy,
                SortDirection = request.SortDirection
            };
            var result = await _executor.Execute(query);
            return new GetVolumesResponse()
            {
                Data = new Domain.PagedResult<VolumeDTO>(_mapper.Map<List<VolumeDTO>>(result.Items)
                , result.TotalItemsCount
                , request.PageSize
                , request.PageNumber)
            };
        }
    }
}
