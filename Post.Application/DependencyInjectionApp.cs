using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Post.Application.Common.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application
{
    public static class DependencyInjectionApp
    {
        public static IServiceCollection AddApplicationLayerService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(c => 
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                c.AddBehavior(typeof(IPipelineBehavior<,>),typeof(ValidationBehaviour<,>));
            });
            return services;
        }
    }
}
