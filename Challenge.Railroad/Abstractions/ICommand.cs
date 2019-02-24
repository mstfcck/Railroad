using Challenge.Railroad.Receiver;

namespace Challenge.Railroad.Abstractions
{
    public interface ICommand
    {
        CommandType GetCommandType();
        void Execute();
    }
}
