using Railroad.Receiver;

namespace Railroad.Abstractions
{
    public interface ICommand
    {
        CommandType GetCommandType();
        void Execute();
    }
}
