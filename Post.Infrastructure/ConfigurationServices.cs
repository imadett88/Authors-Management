using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Infrastructure
{
    public static  class ConfigurationServices
    {
        public static IServiceCollection AddInfrastructureLayerService(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
