using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            serviceCollection.AddScoped(typeof(IExpertRepository), typeof(ExpertRepository));
            serviceCollection.AddScoped(typeof(IServiceRepository), typeof(ServiceRepository));
            serviceCollection.AddScoped(typeof(IPhotoRepository), typeof(PhotoRepository));
            serviceCollection.AddScoped(typeof(ITestimonialRepository), typeof(TestimonialRepository));
            serviceCollection.AddScoped(typeof(IAvailableDateRepository), typeof(AvailableDateRepository));
            serviceCollection.AddScoped(typeof(IAvailableHourRepository), typeof(AvailableHourRepository));
            serviceCollection.AddScoped(typeof(IAppointmentRepository), typeof(AppointmentRepository));
        }
    }
}
