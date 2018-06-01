using Autofac;
using AwesomeToDo.Core.Extensions;
using AwesomeToDo.Core.Settings;
using Microsoft.Extensions.Configuration;

namespace AwesomeToDo.Core.Modules
{
    public class SettingsModule : Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<DatabaseSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
        }
    }
}