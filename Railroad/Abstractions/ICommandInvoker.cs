using System.Collections.Generic;

namespace Railroad.Abstractions
{
    public interface ICommandInvoker
    {
        /// <summary>
        /// Sets the commands
        /// </summary>
        /// <param name="commands"></param>
        void SetCommands(IEnumerable<ICommand> commands);

        /// <summary>
        /// Executes all commands
        /// </summary>
        void InvokeAll();
    }
}