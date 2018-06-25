using Autofac;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;
using AwesomeToDo.Infrastructure.Services.Concrete.Commands;
using AwesomeToDo.Infrastructure.Services.Concrete.Queries;

namespace AwesomeToDo.Infrastructure.Modules
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserQueryService>().As<IUserQueryService>().InstancePerLifetimeScope();
            builder.RegisterType<UserCommandService>().As<IUserCommandService>().InstancePerLifetimeScope();

            builder.RegisterType<CardCommandService>().As<ICardCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<CardQueryService>().As<ICardQueryService>().InstancePerLifetimeScope();
        }
    }
}
