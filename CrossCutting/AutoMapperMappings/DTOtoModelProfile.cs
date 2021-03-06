using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.DTOs.AppointmentDTOs;
using Domain.DTOs.AvailableDateDTOs;
using Domain.DTOs.AvailableHourDTOs;
using Domain.DTOs.ExpertDTOs;
using Domain.DTOs.FavoritesDTOs;
using Domain.DTOs.PhotoDTOs;
using Domain.DTOs.ServiceDTOs;
using Domain.DTOs.TestimonialDTOs;
using Domain.DTOs.UserDTOs;
using Services.Models;

namespace CrossCutting.AutoMapperMappings
{
    public class DTOtoModelProfile : Profile
    {
        public DTOtoModelProfile()
        {
            CreateMap<UserDTOCreate, UserModel>().ReverseMap();
            CreateMap<UserDTOUpdate, UserModel>().ReverseMap();

            CreateMap<ExpertDTOCreate, ExpertModel>().ReverseMap();
            CreateMap<ExpertDTOUpdate, ExpertModel>().ReverseMap();

            CreateMap<ServiceDTOCreate, ServiceModel>().ReverseMap();

            CreateMap<PhotoDTOCreate, PhotoModel>().ReverseMap();

            CreateMap<TestimonialDTOCreate, TestimonialModel>().ReverseMap();

            CreateMap<AvailableDateDTOCreate, AvailableDateModel>().ReverseMap();
            CreateMap<AvailableHourDTOCreate, AvailableHourModel>().ReverseMap();

            CreateMap<AppointmentDTOCreate, AppointmentModel>().ReverseMap();

            CreateMap<FavoritesDTOCreate, FavoritesModel>().ReverseMap();
        }
    }
}
