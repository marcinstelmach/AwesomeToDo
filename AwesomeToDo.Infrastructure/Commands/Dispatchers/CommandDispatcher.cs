using System.Threading.Tasks;
using Autofac;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using NLog;

namespace AwesomeToDo.Infrastructure.Commands.Dispatchers
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext componentContext;
        private readonly ILogger logger;

        public CommandDispatcher(IComponentContext componentContext, ILogger logger)
        {
            this.componentContext = componentContext;
            this.logger = logger;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommandModel
        {
            logger.Trace($"Command has been run: {typeof(T)}");

            if (command == null)
            {
                throw new AwesomeToDoException(ErrorCode.EmptyCommand, typeof(T).Name);
            }

            var handler = componentContext.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);

        }
    }
}
