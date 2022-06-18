using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Genre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Genre
{
    public class UpdateGenreRequestHandler : IRequestHandler<UpdateGenreRequest, UpdateGenreResponse>
    {
        private readonly ICommandExecutor _executor;
        private readonly IMapper _mapper;

        public UpdateGenreRequestHandler(ICommandExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<UpdateGenreResponse> Handle(UpdateGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<MangaLibrary.DataAccess.Entities.Genre>(request);
            var command = new UpdateGenreCommand() { Parameter = genre };
            var result = await _executor.Execute(command);
            if (!result.IsSuccess)
                return new UpdateGenreResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, result.ErrorMessage) };
            return new UpdateGenreResponse() { Data=result.Value };
           
        }
    }
}
