using Autofac;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Domain.Repositories.Concrete;

namespace AwesomeToDo.Domain.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CardRepository>().As<ICardRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ToDoRepository>().As<IToDoRepository>().InstancePerLifetimeScope();
        }
    }
}
