using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AwesomeToDo.Core.Extensions;
using AwesomeToDo.Core.Settings;
using Microsoft.Extensions.Configuration;

namespace AwesomeToDo.Core.Modules
{
    public class SettingsModule : Module
    {
        private readonly IConfiguration configuration;

        public SettingsModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(configuration.GetSettings<DatabaseSettings>()).SingleInstance();
            builder.RegisterInstance(configuration.GetSettings<JwtSettings>()).SingleInstance();
        }
    }
}
