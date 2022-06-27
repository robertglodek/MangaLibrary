using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.User;
using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.DataAccess.CQRS.Queries.User;
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

            CreateMap<UpdateUserRequest, User>()
                .ForMember(n => n.FirstName, n => n.MapFrom(s => s.FirstName))
                .ForMember(n => n.LastName, n => n.MapFrom(s => s.LastName))
                .ForMember(n => n.Nationality, n => n.MapFrom(s => s.Nationality))
                .ForMember(n => n.DateOfBirth, n => n.MapFrom(s => s.DateOfBirth));

            CreateMap<User, UserDTO>()
                .ForMember(n => n.Id, n => n.MapFrom(s => s.Id))
                .ForMember(n => n.Email, n => n.MapFrom(s => s.Email))
                .ForMember(n => n.FirstName, n => n.MapFrom(s => s.FirstName))
                .ForMember(n => n.DateOfBirth, n => n.MapFrom(s => s.DateOfBirth))
                .ForMember(n => n.LastName, n => n.MapFrom(s => s.LastName));

            CreateMap<User, UserDetailsDTO>()
                .ForMember(n => n.Id, n => n.MapFrom(s => s.Id))
                .ForMember(n => n.Email, n => n.MapFrom(s => s.Email))
                .ForMember(n => n.Nationality, n => n.MapFrom(s => s.Nationality))
                .ForMember(n => n.DateOfBirth, n => n.MapFrom(s => s.DateOfBirth))
                .ForMember(n => n.Role, n => n.MapFrom(s => s.Role.Name));


            CreateMap<GetUsersRequest, GetUsersQuery>();
        }
    }
}
