///TODO:
using System;
using NUnit.Framework;
using NSubstitute;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class CommandExecutionExceptionTest
    {
        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Ctor_WithCommandAndException_PropsEqual()
        {
            //TODO:DRY (CommandExceptionTest.Ctor_WithCommandAndException_PropsEqual)
            var command = Substitute.For<ICommand>();
            var innerException = new Exception();
            
            CommandExecutionException exception = new CommandExecutionException(command, innerException);
            Assert.AreSame(exception.InnerException, innerException);
            Assert.AreSame(exception.Command, command);
        }
    }
}
