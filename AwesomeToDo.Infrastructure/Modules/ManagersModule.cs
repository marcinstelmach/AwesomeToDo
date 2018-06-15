using Autofac;
using AwesomeToDo.Infrastructure.Managers.Abstract;
using AwesomeToDo.Infrastructure.Managers.Concrete;

namespace AwesomeToDo.Infrastructure.Modules
{
    public class ManagersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EncryptionManager>().As<IEncryptionManager>().InstancePerLifetimeScope();
            builder.RegisterType<TokenManager>().As<ITokenManager>().InstancePerLifetimeScope();
        }
    }
}
