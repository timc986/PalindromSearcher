using NUnit.Framework;
using ConsoleApp;

namespace ConsoleAppTest
{
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void WHEN_consoleapp_program_is_called_THEN_should_throw_no_exception()
        {
            //Assert
            Assert.DoesNotThrow( () => Program.Main());
        }
    }
}
