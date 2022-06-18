using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.DataAccess.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Creator
{
    public class AddCreatorRequestHandler : IRequestHandler<AddCreatorRequest, AddCreatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _executor;

        public AddCreatorRequestHandler(IMapper mapper,ICommandExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public Task<AddCreatorResponse> Handle(AddCreatorRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
