﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Character
{
    public class GetCharacterByIdRequest:IRequest<GetCharacterByIdResponse>
    {
        public Guid Id { get; set; }
    }
}