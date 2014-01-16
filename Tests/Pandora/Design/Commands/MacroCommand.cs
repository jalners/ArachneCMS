///TODO:
using System;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

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
        public void Commands_EmptyWhenCreated()
        {
            MacroCommand command = new MacroCommand();
            Assert.IsNotNull(command.Commands);
            Assert.IsEmpty(command.Commands);
        }

        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Add_ItemsAdded()
        {
            MacroCommand macro = new MacroCommand();
            ICommand command1 = Substitute.For<ICommand>(); 
            
            macro.Add(command1);
            Assert.AreEqual(macro.Commands.Count, 1);
            Assert.AreSame(command1, macro.Commands[0]);

            ICommand command2 = Substitute.For<ICommand>();
            macro.Add(command2);
            Assert.AreEqual(macro.Commands.Count, 2);
            Assert.AreSame(command2, macro.Commands[1]);
        }

        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Add_NullCommand_Exception()
        {
            MacroCommand macro = new MacroCommand();
            Assert.Catch<ArgumentException>(() => macro.Add(null));
        }

        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Execute_ProperExecutionSequence()
        {
            string result = string.Empty;

            var command1 = Substitute.For<ICommand>();
            command1.When(command => command.Execute()).Do((info) => result += "1");

            var command2 = Substitute.For<ICommand>();
            command2.When(command => command.Execute()).Do((info) => result += "2");

            var command3 = Substitute.For<ICommand>();
            command3.When(command => command.Execute()).Do((info) => result += "3");

            IMacroCommand macroCommand = new MacroCommand()
            {
                command1,
                command2,
                command3
            };

            macroCommand.Execute();
            Assert.AreEqual(result, "123");
        }

        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Execute_CommndRaisedException()
        {
            string result = string.Empty;
            Exception exception = new Exception();

            var command1 = Substitute.For<ICommand>();
            command1.When(command => command.Execute()).Do((info) => result += "1");

            var command2 = Substitute.For<ICommand>();
            command2.When(command => command.Execute()).Do((info) =>
            {
                throw new CommandExecutionException(command2, exception);
            });

            var command3 = Substitute.For<ICommand>();
            command3.When(command => command.Execute()).Do((info) => result += "3");

            ICommand macro = new MacroCommand()
            {
                command1,
                command2,
                command3
            };

            Assert.Throws<CommandExecutionException>(() => macro.Execute());
            Assert.AreEqual(result, "1");
        }
    }
}
