///TODO:
using System;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class NullCommand : Pandora.Design.Commands.ICommand
    {
        private static readonly ICommand _Value = new NullCommand();
        /// <summary>
        /// TODO:
        /// </summary>
        public static ICommand Value
        {
            get
            {
                return _Value;
            }
        }

        #region -- ICommand interface implementation ----------------------------------------------
        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Command execution routine.
        /// </summary>
        /// <remarks>
        /// For NullCommand implementation of <see cref="Pandora.Design.Commands.ICommand"/>
        /// interface, the body is empty, because it is doing nothing.
        /// </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////
        void ICommand.Execute()
        {

        }
        #endregion -------------------------------------------------------------------------------

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <remarks>
        /// Because this class acts a Singleton pattern and nobody can create additional instance
        /// except one in _Value field, the constructor is private.
        /// </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////
        private NullCommand()
        {
            
        }
    }
}
