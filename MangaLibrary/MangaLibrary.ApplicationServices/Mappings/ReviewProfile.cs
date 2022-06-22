using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MangaLibrary.ApplicationServices.API.Domain.Models.Review;
using MangaLibrary.ApplicationServices.API.Domain.Review;
using MangaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Mappings
{
    public class ReviewProfile:Profile
    {
        public ReviewProfile()
        {
            CreateMap<AddReviewRequest, Review>()
               .ForMember(n => n.MangaId, y => y.MapFrom(s => s.MangaId))
               .ForMember(n => n.AuthorId, y => y.MapFrom(s => s.AuthorId))
               .ForMember(n => n.Rating, y => y.MapFrom(s => s.Rating))
               .ForMember(n => n.Content, y => y.MapFrom(s => s.Content));


            CreateMap<UpdateReviewRequest, Review>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.MangaId, y => y.MapFrom(s => s.MangaId))
               .ForMember(n => n.AuthorId, y => y.MapFrom(s => s.AuthorId))
               .ForMember(n => n.Rating, y => y.MapFrom(s => s.Rating))
               .ForMember(n => n.Content, y => y.MapFrom(s => s.Content));

            CreateMap<Review, ReviewDTO>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.PublishDate, y => y.MapFrom(s => s.PublishDate))
               .ForMember(n => n.Rating, y => y.MapFrom(s => s.Rating))
               .ForMember(n => n.Content, y => y.MapFrom(s => s.Content));

            CreateMap<Review, ReviewDetailsDTO>()
             .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
             .ForMember(n => n.PublishDate, y => y.MapFrom(s => s.PublishDate))
             .ForMember(n => n.Rating, y => y.MapFrom(s => s.Rating))
             .ForMember(n => n.Author, y => y.MapFrom(s => s.Author))
             .ForMember(n => n.Content, y => y.MapFrom(s => s.Content));
        }
    }
}
