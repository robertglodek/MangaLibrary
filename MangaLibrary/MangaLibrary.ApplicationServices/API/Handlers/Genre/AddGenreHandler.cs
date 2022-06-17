using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Genre;
using MangaLibrary.DataAccess.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Genre
{
    public class AddGenreHandler : IRequestHandler<AddGenreRequest, AddGenreResponse>
    {
        private readonly ICommandExecutor _executor;
        private readonly IMapper _mapper;

        public AddGenreHandler(ICommandExecutor executor,IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<AddGenreResponse> Handle(AddGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<MangaLibrary.DataAccess.Entities.Genre>(request);
            var command = new AddGenreCommand() { Parameter = genre };
            var result= await _executor.Execute(command);
            return new AddGenreResponse() { Data = result.Value };
        }
    }
}
