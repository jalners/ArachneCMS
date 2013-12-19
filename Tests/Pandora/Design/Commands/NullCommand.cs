///TODO:
using System;
using System.Reflection;
using NUnit.Framework;

namespace Pandora.Design.Commands
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class NullCommandTest
    {
        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Value_ReturnsSameInstance()
        {
            var instance1 = NullCommand.Value;
            var instance2 = NullCommand.Value;
            Assert.AreSame(instance1, instance2);
        }

        /// <summary>
        /// TODO:
        /// </summary>
        [Test]
        public void Constructor_OnlyPrivate()
        {
            var constructors = typeof(NullCommand)
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            ;

            foreach (var constructor in constructors)
            {
                Assert.IsTrue(constructor.IsPrivate);
            }
        }
    }
}
