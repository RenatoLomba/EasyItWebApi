using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.AppServicesInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.AppServices;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ISignService, SignService>();
            serviceCollection.AddTransient<IExpertService, ExpertService>();
            serviceCollection.AddTransient<IServiceService, ServiceService>();
            serviceCollection.AddTransient<IPhotoService, PhotoService>();
            serviceCollection.AddTransient<ITestimonialService, TestimonialService>();
            serviceCollection.AddTransient<IAvailableDateService, AvailableDateService>();
            serviceCollection.AddTransient<IAppointmentService, AppointmentService>();
        }
    }
}
