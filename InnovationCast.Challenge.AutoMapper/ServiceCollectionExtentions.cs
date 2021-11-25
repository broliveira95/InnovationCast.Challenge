using AutoMapper;
using InnovationCast.Challenge.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InnovationCast.Challenge.AutoMapper
{
    public static class ServiceCollectionExtentions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommentsProfile());
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
