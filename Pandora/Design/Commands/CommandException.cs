///TODO:
using System;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class CommandException : System.Exception
    {
        private ICommand _Command = null;
        /// <summary>
        /// TODO:
        /// </summary>
        public ICommand Command
        {
            get
            {
                return _Command;
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="command"></param>
        /// <param name="innerException"></param>
        public CommandException(ICommand command, Exception innerException)
            : base(null, innerException)
        {
            _Command = command;
        }
    }
}
