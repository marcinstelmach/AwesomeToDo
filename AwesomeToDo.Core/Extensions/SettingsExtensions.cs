using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AwesomeToDo.Core.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var configurationValue = new T();

            var section = typeof(T).Name.Replace("Settings", string.Empty);
            configuration.GetSection(section).Bind(configurationValue);
            return configurationValue;
        }
    }
}
