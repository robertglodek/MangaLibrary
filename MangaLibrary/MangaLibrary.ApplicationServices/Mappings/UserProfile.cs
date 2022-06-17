﻿using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Mappings
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserRequest, User>()
                .ForMember(n => n.Email, n => n.MapFrom(s => s.Email))
                .ForMember(n => n.Nationality, n => n.MapFrom(s => s.Nationality))
                .ForMember(n => n.DateOfBirth, n => n.MapFrom(s => s.DateOfBirth))
                .ForMember(n => n.RoleId, n => n.MapFrom(s => s.RoleId));
        }
    }
}
