///TODO:
using System;
using Moq;
using NUnit.Framework;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class CommandExceptionTest
    {
        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Constructor_WithCommandAndException()
        {
            var command = new Mock<ICommand>();
            var innerException = new Exception();

            CommandException exception = new CommandException(command.Object, innerException);
            Assert.AreSame(exception.InnerException, innerException);
            Assert.AreSame(exception.Command, command.Object);
        }
    }
}
