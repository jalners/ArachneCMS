///TODO:
using System;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class CommandExecutionException : Pandora.Design.Commands.CommandException
    {
        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="command"></param>
        /// <param name="executionException"></param>
        public CommandExecutionException(ICommand command, Exception executionException)
            : base(command, executionException)
        {

        }
    }
}
