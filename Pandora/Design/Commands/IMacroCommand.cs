///TODO:
using System;
using System.Collections.Generic;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public interface IMacroCommand : Pandora.Design.Commands.ICommand
    {
        /// <summary>
        /// TODO:
        /// </summary>
        IList<ICommand> Commands
        {
            get;
        }
    }
}
