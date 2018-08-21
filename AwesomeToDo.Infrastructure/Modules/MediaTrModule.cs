using System.Reflection;
using Autofac;
using MediatR;
using Module = Autofac.Module;

namespace AwesomeToDo.Infrastructure.Modules
{
    public class MediatRModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(ctx =>
            {
                var context = ctx.Resolve<IComponentContext>();
                return t => context.Resolve(t);
            }).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(this.GetType().Assembly)
                .Where(s => s.Name.EndsWith("Handler"))
                .AsImplementedInterfaces();
        }
    }
}
