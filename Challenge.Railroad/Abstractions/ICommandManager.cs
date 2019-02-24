using System.Collections.Generic;

namespace Challenge.Railroad.Abstractions
{
    public interface ICommandManager
    {
        /// <summary>
        /// Parses command input to command objects and returns
        /// </summary>
        /// <param name="commandInput">Command input</param>
        /// <returns></returns>
        IEnumerable<ICommand> Parse(string commandInput);
    }
}