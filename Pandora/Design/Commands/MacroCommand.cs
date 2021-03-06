﻿///TODO:
using System;
using System.Collections;
using System.Collections.Generic;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class MacroCommand
        : Pandora.Design.Commands.IMacroCommand
        , System.Collections.Generic.IEnumerable<ICommand>
    {
        private IList<ICommand> _Commands = null;
        /// <summary>
        /// TODO:
        /// </summary>
        public IList<ICommand> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    _Commands = new List<ICommand>();
                }

                return _Commands;
            }
        }

        /// <summary>
        /// TODO:This is for collection initializer
        /// </summary>
        /// <param name="command"></param>
        public void Add(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentException("command");
            }

            this.Commands.Add(command);
        }

        #region -- IEnumerable interface implementation -------------------------------------------
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Commands.GetEnumerator();
        }

        IEnumerator<ICommand> IEnumerable<ICommand>.GetEnumerator()
        {
            return this.Commands.GetEnumerator();
        }
        #endregion -------------------------------------------------------------------------------

        #region -- ICommand interface implenentation ----------------------------------------------
        void ICommand.Execute()
        {
            ICommand lastCommand = null;

            try
            {
                foreach (ICommand command in this.Commands)
                {
                    lastCommand = command;
                    command.Execute();
                }
            }
            catch (Exception e)
            {
                throw new CommandExecutionException(lastCommand, e);
            }
        }
        #endregion -------------------------------------------------------------------------------
    }
}
