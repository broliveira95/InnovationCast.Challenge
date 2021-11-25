using InnovationCast.Challenge.Repository.Impl;
using InnovationCast.Challenge.Repository.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationCast.Challenge.Repository
{
    public static class ServiceCollectionExtentions
    {
        public static void AddInnovationCastRepository(this IServiceCollection services, RepositorySettings repositorySettings = null)
        {
            services.AddSingleton(repositorySettings ?? new RepositorySettings());

            services.AddScoped<ICommentsRepository, CommentsRepository>();
        }
    }
}
