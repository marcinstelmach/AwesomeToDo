using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AutoMapper;
using AwesomeToDo.Infrastructure.Mappers;

namespace AwesomeToDo.Infrastructure.Modules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).As<IMapper>().SingleInstance();
        }
    }
}
