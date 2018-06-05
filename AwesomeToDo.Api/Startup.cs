using System;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AwesomeToDo.Api.Middleware;
using AwesomeToDo.Core.Extensions;
using AwesomeToDo.Core.Modules;
using AwesomeToDo.Core.Settings;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Data.Concrete;
using AwesomeToDo.Domain.Modules;
using AwesomeToDo.Infrastructure.Modules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;

namespace AwesomeToDo.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        public IContainer Container { get; private set; }


        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
            Configuration = configuration;
        }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();

            services.AddDbContext<EfContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSettings<DatabaseSettings>().ConnectionString);
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IDbContext>(provider => provider.GetService<EfContext>());

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "Awesome ToDo", Version = "v1" }));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtSettings = Configuration.GetSettings<JwtSettings>();

                    options.RequireHttpsMetadata = false;
                    options.Configuration = new OpenIdConnectConfiguration();
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        ValidateLifetime = true
                    };
                });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule(new SettingsModule(Configuration));
            builder.RegisterModule<CommandModule>();
            builder.RegisterInstance(LogManager.GetCurrentClassLogger()).As<NLog.ILogger>();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);

        }

        public void Configure(IApplicationBuilder app, IApplicationLifetime appLifetime, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            HostingEnvironment.ConfigureNLog($"nlog.{HostingEnvironment.EnvironmentName}.config");


            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Awesome ToDo API v1"));

            app.UseCors(cors =>
            {
                cors.AllowAnyOrigin();
                cors.AllowAnyMethod();
                cors.AllowAnyHeader();
            });

            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            app.UseAuthentication();
            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
