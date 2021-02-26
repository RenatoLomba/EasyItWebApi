using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureContext<T> where T : DbContext
    {
        public static void ConfigureDependenciesContext(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<T>(options => 
                options.UseMySql("Server=localhost;Port=3306;Database=dbEasyItTeste;Uid=root;Pwd=Redeye@18")
            );
        }
        public static void ConfigureDependenciesContextTest(IServiceCollection serviceCollection, string conexao)
        {
            serviceCollection.AddDbContext<T>(options => 
                options.UseMySql(conexao),
                ServiceLifetime.Transient
            );
        }
    }
}
