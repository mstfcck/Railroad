using Challenge.Railroad.Abstractions;
using Challenge.Railroad.Receiver;
using System;
using System.Collections.Generic;

namespace Challenge.Railroad
{
    public class CommandInvoker : ICommandInvoker
    {
        private readonly IDictionary<CommandType, Action<ICommand>> _setCommandType;
        private readonly IRailroadCompanyReceiver _railroadCompanyReceiver;
        private IEnumerable<ICommand> _commands;

        public CommandInvoker(IRailroadCompanyReceiver railroadCompanyReceiver)
        {
            _railroadCompanyReceiver = railroadCompanyReceiver;

            _setCommandType = new Dictionary<CommandType, Action<ICommand>>
            {
                {CommandType.RouteCommand, SetRouteCommand},
                {CommandType.QueryCommand, SetQueryCommand}
            };
        }

        /// <inheritdoc />
        public void SetCommands(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }

        /// <inheritdoc />
        public void InvokeAll()
        {
            foreach (var command in _commands)
            {
                SetReceiver(command);
                command.Execute();
            }
        }

        #region Privates

        /// <summary>
        /// Invokes the command and sets the receiver
        /// </summary>
        /// <param name="command"></param>
        private void SetReceiver(ICommand command)
        {
            _setCommandType[command.GetCommandType()].Invoke(command);
        }

        private void SetRouteCommand(ICommand command)
        {
            var routeCommand = (IRouteCommand)command;
            routeCommand.SetReceiver(_railroadCompanyReceiver);
        }

        private void SetQueryCommand(ICommand command)
        {
            var queryCommand = (IQueryCommand)command;
            queryCommand.SetReceiver(_railroadCompanyReceiver);
        }

        #endregion
    }
}
