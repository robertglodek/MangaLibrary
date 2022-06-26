using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Character;
using MangaLibrary.ApplicationServices.API.Domain.Models.Character;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Character;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Character
{
    public class GetCharactersRequestHandler : IRequestHandler<GetCharactersRequest, GetCharactersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetCharactersRequestHandler(IMapper mapper, IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetCharactersResponse> Handle(GetCharactersRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetCharactersQuery>(request);
            var result = await _executor.Execute(query);
            return new GetCharactersResponse()
            {
                Data = new Domain.PagedResult<CharacterDTO>(_mapper.Map<List<CharacterDTO>>(result.Items)
                , result.TotalItemsCount
                , request.PageSize
                , request.PageNumber)
            };
        }
    }
}
