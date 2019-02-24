using Challenge.Railroad.Abstractions;

namespace Challenge.Railroad
{
    public class CommandSender : ICommandSender
    {
        private readonly ICommandInvoker _commandInvoker;
        private readonly ICommandManager _commandManager;

        public CommandSender(ICommandInvoker commandInvoker, ICommandManager commandManager)
        {
            _commandInvoker = commandInvoker;
            _commandManager = commandManager;
        }

        public void Execute(string commandInput)
        {
            var commands = _commandManager.Parse(commandInput);
            _commandInvoker.SetCommands(commands);
            _commandInvoker.InvokeAll();
        }
    }
}
