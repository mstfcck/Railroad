using Challenge.Railroad.Abstractions;
using Challenge.Railroad.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenge.Railroad
{
    public class CommandManager : ICommandManager
    {
        private readonly Func<Route, IRouteCommand> _funcRouteCommand;
        private readonly Func<Query, IQueryCommand> _funcQueryCommand;

        private readonly IDictionary<string, CommandType> _commandTypes;
        private readonly IDictionary<CommandType, Func<string, ICommand>> _commandParser;

        public CommandManager(Func<Route, IRouteCommand> surfaceCommandFunc, Func<Query, IQueryCommand> funcQueryCommand)
        {
            _funcRouteCommand = surfaceCommandFunc;
            _funcQueryCommand = funcQueryCommand;

            _commandTypes = new Dictionary<string, CommandType>
            {
                { @"^([A-Z]-[A-Z]:\d{0,2})$", CommandType.RouteCommand }, // ([A-Z]-[A-Z]:\d{0,2})
                { @"^(QUERY\([A-Z]-[A-Z]\))$", CommandType.QueryCommand }, // (QUERY\([A-Z]-[A-Z]\))
            };

            _commandParser = new Dictionary<CommandType, Func<string, ICommand>>
            {
                {CommandType.RouteCommand, ParseRouteCommand},
                {CommandType.QueryCommand, ParseQueryCommand},
            };
        }

        /// <inheritdoc />
        public IEnumerable<ICommand> Parse(string commandInput)
        {
            var commands = commandInput.Replace(" ", string.Empty).Split(',');
            var commandObjects = commands.Select(command => _commandParser[GetCommandType(command)].Invoke(command)).ToList();
            return commandObjects;
        }

        #region Privates

        /// <summary>
        /// Validates the command input and if it matches any command (regex pattern) it returns the command type
        /// </summary>
        /// <param name="commandInput"></param>
        /// <exception cref="Exception"></exception>
        /// <returns>
        /// <see cref="CommandType"/>
        /// </returns>
        private CommandType GetCommandType(string commandInput)
        {
            try
            {
                var commandType = _commandTypes.First(regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(commandInput));
                return commandType.Value;
            }
            catch (InvalidOperationException e)
            {
                throw new Exception($"String '{commandInput}' is not a valid command", e);
            }
        }

        /// <summary>
        /// Returns the route command
        /// </summary>
        /// <param name="commandInput"></param>
        /// <returns>
        /// </returns>
        private ICommand ParseRouteCommand(string commandInput)
        {
            // Sample command input: A-B:5

            var text = commandInput.Split(':'); // A-B, 5
            var points = text[0].Split('-'); // A, B
            var from = points[0]; // A
            var to = points[1]; // B
            var distance = int.Parse(text[1]); // 5

            var route = new Route(from, to, distance);

            var command = _funcRouteCommand(route);
            return command;
        }

        /// <summary>
        /// Returns the query command
        /// </summary>
        /// <param name="commandInput"></param>
        /// <returns>
        /// </returns>
        private ICommand ParseQueryCommand(string commandInput)
        {
            // Sample command input: QUERY(A-B)

            var text = commandInput.Substring(commandInput.IndexOf('(') + 1, 3); // A-B
            var points = text.Split('-'); // A, B
            var from = points[0]; // A
            var to = points[1]; // B

            var query = new Query(from, to);

            var command = _funcQueryCommand(query);
            return command;
        }

        #endregion
    }
}
