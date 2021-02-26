using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Entities;
using Services.Models;

namespace CrossCutting.AutoMapperMappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
            CreateMap<ExpertModel, ExpertEntity>().ReverseMap();
            CreateMap<ServiceModel, ServiceEntity>().ReverseMap();
            CreateMap<PhotoModel, PhotoEntity>().ReverseMap();
            CreateMap<TestimonialModel, TestimonialEntity>().ReverseMap();
            CreateMap<AvailableDateModel, AvailableDateEntity>().ReverseMap();
            CreateMap<AvailableHourModel, AvailableHourEntity>().ReverseMap();
            CreateMap<AppointmentModel, AppointmentEntity>().ReverseMap();
        }
    }
}
