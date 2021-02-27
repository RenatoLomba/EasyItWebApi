using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.DTOs.AppointmentDTOs;
using Domain.DTOs.AvailableDateDTOs;
using Domain.DTOs.AvailableHourDTOs;
using Domain.DTOs.ExpertDTOs;
using Domain.DTOs.PhotoDTOs;
using Domain.DTOs.ServiceDTOs;
using Domain.DTOs.TestimonialDTOs;
using Domain.DTOs.UserDTOs;
using Domain.Entities;

namespace CrossCutting.AutoMapperMappings
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UserEntity, UserDTOSimpleResult>().ReverseMap();
            CreateMap<UserEntity, UserDTOCompleteResult>().ReverseMap();
            CreateMap<UserEntity, UserDTOSignResult>().ReverseMap();

            CreateMap<ExpertEntity, ExpertDTOSimpleResult>().ReverseMap();
            CreateMap<ExpertEntity, ExpertDTOCompleteResult>().ReverseMap();

            CreateMap<ServiceEntity, ServiceDTOSimpleResult>().ReverseMap();
            CreateMap<ServiceEntity, ServiceDTOCompleteResult>().ReverseMap();
            CreateMap<ServiceEntity, ServiceDTOSearchResult>().ReverseMap();

            CreateMap<PhotoEntity, PhotoDTOSimpleResult>().ReverseMap();

            CreateMap<TestimonialEntity, TestimonialDTOSimpleResult>().ReverseMap();
            CreateMap<TestimonialEntity, TestimonialDTOCompleteResult>().ReverseMap();

            CreateMap<AvailableDateEntity, AvailableDateDTOSimpleResult>().ReverseMap();

            CreateMap<AvailableHourEntity, AvailableHourDTOSimpleResult>().ReverseMap();

            CreateMap<AppointmentEntity, AppointmentDTOSimpleResult>().ReverseMap();
        }
    }
}
