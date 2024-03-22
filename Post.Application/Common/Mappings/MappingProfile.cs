using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            MappingsFormAssembly(Assembly.GetExecutingAssembly());
        }

        private void MappingsFormAssembly(Assembly assembly)
        {
            var mapMng = typeof(IMapFrom<>);

            var mappingMethodeName = nameof(IMapFrom<object>.Mapping);

            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapMng;

            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            var argumentTypes = new Type[] { typeof(Profile) };

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(mappingMethodeName);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] { this });
                }
                else
                {
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if (interfaces.Count > 0)
                    {
                        foreach (var inter in interfaces)
                        {
                            var interfaceMethoInfo = inter.GetMethod(mappingMethodeName, argumentTypes);

                            interfaceMethoInfo?.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }

        }
    }
}