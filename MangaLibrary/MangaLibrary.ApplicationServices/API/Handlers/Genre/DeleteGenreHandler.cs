using MangaLibrary.ApplicationServices.API.Domain.Genre;
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
    public class DeleteGenreHandler : IRequestHandler<DeleteGenreRequest, DeleteGenreResponse>
    {
        private readonly ICommandExecutor _executor;
 

        public DeleteGenreHandler(ICommandExecutor executor)
        {
            _executor = executor;
           
        }
        public async Task<DeleteGenreResponse> Handle(DeleteGenreRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteGenreCommand() { Parameter= request.Id };
            var result=await _executor.Execute(command);
            var response = new DeleteGenreResponse() { Data = result };
            return response;
        }
    }
}
