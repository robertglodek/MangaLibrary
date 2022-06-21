using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Volume;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
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
   

    public class GetVolumeByIdRequestHandler : IRequestHandler<GetVolumeByIdRequest, GetVolumeByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetVolumeByIdRequestHandler(IQueryExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetVolumeByIdResponse> Handle(GetVolumeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourceQuery<MangaLibrary.DataAccess.Entities.Volume>() { Id = request.Id };
            var result = await _executor.Execute(query);
            if (result == null)
                return new GetVolumeByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Volume with id: {request.Id} doesn't exist") };
            return new GetVolumeByIdResponse() { Data = _mapper.Map<VolumeDTO>(result) };
        }
    }
}
