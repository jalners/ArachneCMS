///TODO:
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class MacroCommandTest
    {
        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Commands_CreateEmptyCollection()
        {
            MacroCommand command = new MacroCommand();
            Assert.IsNotNull(command.Commands);
            Assert.IsEmpty(command.Commands);
        }

        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Execute_CheckProperExecution()
        {
            int sum = 0;

            var mockCommand1 = new Mock<ICommand>();
            mockCommand1.Setup(command => command.Execute()).Callback(() => sum += 1);
            
            var mockCommand2 = new Mock<ICommand>();
            mockCommand2.Setup(command => command.Execute()).Callback(() => sum += 2);
            
            var mockCommand3 = new Mock<ICommand>();
            mockCommand3.Setup(command => command.Execute()).Callback(() => sum += 3);

            IMacroCommand macroCommand = new MacroCommand()
            {
                mockCommand1.Object,
                mockCommand2.Object,
                mockCommand3.Object
            };

            Assert.AreEqual(macroCommand.Commands.Count, 3);

            macroCommand.Execute();
            Assert.AreEqual(sum, 6);
        }

        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Execute_CheckFailedExecution()
        {
            int sum = 0;
            Exception exception = new Exception();

            var mockCommand1 = new Mock<ICommand>();
            mockCommand1.Setup(command => command.Execute()).Callback(() => sum += 1);
            
            var mockCommand2 = new Mock<ICommand>();
            mockCommand2.Setup(command => command.Execute()).Callback(() =>
            {
                throw new CommandExecutionException(mockCommand2.Object, exception);
            });
            
            var mockCommand3 = new Mock<ICommand>();
            mockCommand3.Setup(command => command.Execute()).Callback(() => sum += 3);

            ICommand macroCommand = new MacroCommand()
            {
                mockCommand1.Object,
                mockCommand2.Object,
                mockCommand3.Object
            };

            Assert.Throws<CommandExecutionException>(() => macroCommand.Execute());
            Assert.AreEqual(sum, 1);
        }
    }
}
