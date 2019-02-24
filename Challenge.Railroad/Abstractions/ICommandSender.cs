namespace Challenge.Railroad.Abstractions
{
    public interface ICommandSender
    {
        /// <summary>
        /// Parses the command input to command objects and executes all
        /// </summary>
        /// <param name="commandInput"></param>
        void Execute(string commandInput);
    }
}