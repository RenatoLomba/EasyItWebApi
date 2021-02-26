using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CrossCutting.AutoMapperMappings;
using CrossCutting.DependencyInjection;
using Data.Context;
using Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //INJEÇÃO DE DEPENDENCIA
            ConfigureContext<MyContext>.ConfigureDependenciesContext(services);
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            //AUTOMAPPER
            var mapperConfigurations = new AutoMapper.MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new DTOtoModelProfile());
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new EntityToDTOProfile());
            });
            IMapper mapper = mapperConfigurations.CreateMapper();
            services.AddSingleton(mapper);

            //CONFIGURAÇÕES DE SEGURANÇA
            var signingConfig = new SigningConfigurations();
            services.AddSingleton(signingConfig);
            var tokenConfig = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations")    
            ).Configure(tokenConfig);
            services.AddSingleton(tokenConfig);

            //AUTENTICAÇÃO
            services.AddAuthentication(authOptions => 
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions => 
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfig.Key;
                paramsValidation.ValidAudience = tokenConfig.Audience;
                paramsValidation.ValidIssuer = tokenConfig.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            //AUTORIZAÇÃO
            services.AddAuthorization(auth => 
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Version = "v1",
                    Title = "EasyIt - Serviços Rápidos e Fáceis de TI",
                    Description = "EasyIt é um projeto para o 3º semestre de Análise e Desenvolvimento de Sistemas da faculdade Eniac, que consiste " +
                    "em um aplicativo Mobile para localizar e agendar serviços dos mais diversos tipos dentro da área de Tecnologia e Informática. Esta é uma" +
                    "API criada para controlar os dados através da aplicação Front-End feita em React Native para dispositivos Mobile.",
                    TermsOfService = new Uri("https://www.eniac.com.br/"),
                    Contact = new OpenApiContact { 
                        Name = "Renato J. R. Lomba",
                        Email = "215202019@eniac.edu.br",
                        Url = new Uri("https://www.linkedin.com/in/renato-lomba-9321431a6/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("https://www.eniac.com.br/")
                    }
                });

                //BOTÃO DE AUTENTICAÇÃO SWAGGER
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                //REQUERIMENTO DE SEGURANÇA SWAGGER
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //CONFIGURAÇÃO DO SWAGGER
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyIt");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
