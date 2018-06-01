using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AwesomeToDo.Core.Extensions;
using AwesomeToDo.Core.Modules;
using AwesomeToDo.Core.Settings;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Data.Concrete;
using AwesomeToDo.Domain.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeToDo.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        public IContainer Container { get; private set; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<EfContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSettings<DatabaseSettings>().ConnectionString);
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IDbContext>(provider => provider.GetService<EfContext>());

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule(new SettingsModule(Configuration));

            Container = builder.Build();
            return new AutofacServiceProvider(Container);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
