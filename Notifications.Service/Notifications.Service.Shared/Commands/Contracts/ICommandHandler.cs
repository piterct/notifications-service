using System.Threading.Tasks;

namespace Notifications.Service.Shared.Commands.Contracts
{
    public interface  ICommandHandler<T> where T : ICommand
    {
        ValueTask<ICommandResult> Handle(T command);
    }
}
