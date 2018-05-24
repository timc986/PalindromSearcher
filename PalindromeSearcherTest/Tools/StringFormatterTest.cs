using NUnit.Framework;
using PalindromeSearcher.Interface;
using PalindromeSearcher.Tools;

namespace PalindromeSearcherTest.Tools
{
    [TestFixture]
    public class StringCleanerTest
    {
        private IStringFormatter formatter;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            formatter = new StringFormatter();
        }

        [Test]
        public void GIVEN_empty_string_WHEN_CleanString_is_called_THEN_should_return_empty_string()
        {
            //Arrange
            var input = "";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual(input, response);
        }

        [Test]
        public void GIVEN_space_string_WHEN_CleanString_is_called_THEN_should_return_empty_string()
        {
            //Arrange
            var input = " ";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("", response);
        }

        [Test]
        public void GIVEN_null_WHEN_CleanString_is_called_THEN_should_return_empty_string()
        {
            //Act
            var response = formatter.FormatString(null);

            //Assert
            Assert.AreEqual("", response);
        }

        [Test]
        public void GIVEN_uppercase_letters_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters()
        {
            //Arrange
            var input = "ABCDE";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde", response);
        }

        [Test]
        public void GIVEN_lowercase_letters_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters()
        {
            //Arrange
            var input = "abcde";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde", response);
        }

        [Test]
        public void GIVEN_lowercase_letters_with_space_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_no_space()
        {
            //Arrange
            var input = " a bc     de ";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde", response);
        }

        [Test]
        public void GIVEN_uppercase_letters_with_space_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_no_space()
        {
            //Arrange
            var input = " A BC     DE ";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde", response);
        }

        [Test]
        public void GIVEN_lowercase_letters_with_symbols_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_no_symbols()
        {
            //Arrange
            var input = "abcde!@#$%^&*()_+.";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde", response);
        }

        [Test]
        public void GIVEN_uppercase_letters_with_symbols_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_no_symbols()
        {
            //Arrange
            var input = "ABCDE!@#$%^&*()_+.";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde", response);
        }

        [Test]
        public void GIVEN_lowercase_letters_with_symbols_with_space_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_no_symbols_no_space()
        {
            //Arrange
            var input = "a bc de!@#$%  ^&* ()_+.";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde", response);
        }

        [Test]
        public void GIVEN_uppercase_letters_with_symbols_with_space_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_no_symbols_no_space()
        {
            //Arrange
            var input = "A BC DE!@#$%  ^&* ()_+.";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde", response);
        }

        [Test]
        public void GIVEN_numbers_WHEN_CleanString_is_called_THEN_should_return_numbers()
        {
            //Arrange
            var input = "12345";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual(input, response);
        }

        [Test]
        public void GIVEN_numbers_with_space_WHEN_CleanString_is_called_THEN_should_return_numbers_with_no_space()
        {
            //Arrange
            var input = " 12 34 5 ";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("12345", response);
        }

        [Test]
        public void GIVEN_numbers_with_symbols_WHEN_CleanString_is_called_THEN_should_return_numbers_with_no_symbols()
        {
            //Arrange
            var input = "12345!@#$%^&*()_+.";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("12345", response);
        }

        [Test]
        public void GIVEN_numbers_with_symbols_with_space_WHEN_CleanString_is_called_THEN_should_return_numbers_with_no_symbols_no_space()
        {
            //Arrange
            var input = "12 34 5 !@#$ %^&* () _+.";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("12345", response);
        }

        [Test]
        public void GIVEN_lowercase_letters_with_numbers_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_numbers()
        {
            //Arrange
            var input = "abcde12345";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual(input, response);
        }

        [Test]
        public void GIVEN_uppercase_letters_with_numbers_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_numbers()
        {
            //Arrange
            var input = "ABCDE12345";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde12345", response);
        }

        [Test]
        public void GIVEN_lowercase_letters_with_numbers_with_space_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_numbers_with_no_space()
        {
            //Arrange
            var input = "a bc de12 3 4 5";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde12345", response);
        }

        [Test]
        public void GIVEN_uppercase_letters_with_numbers_with_space_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_numbers_with_no_space()
        {
            //Arrange
            var input = "A BC DE12 3 4 5";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde12345", response);
        }

        [Test]
        public void GIVEN_lowercase_letters_with_numbers_with_symbols_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_numbers_with_no_symbols()
        {
            //Arrange
            var input = "abcde12345!@#$%^&*()_+.";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde12345", response);
        }

        [Test]
        public void GIVEN_uppercase_letters_with_numbers_with_symbols_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_numbers_with_no_symbols()
        {
            //Arrange
            var input = "ABCDE12345!@#$%^&*()_+.";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde12345", response);
        }

        [Test]
        public void GIVEN_lowercase_letters_with_numbers_with_symbols_with_space_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_numbers_with_no_symbols_no_space()
        {
            //Arrange
            var input = " ab cd e1 23 45!@#$ %^&*( )_ +. ";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde12345", response);
        }

        [Test]
        public void GIVEN_uppercase_letters_with_numbers_with_symbols_with_space_WHEN_CleanString_is_called_THEN_should_return_lowercase_letters_with_numbers_with_no_symbols_no_space()
        {
            //Arrange
            var input = " AB CD E1 23 45!@#$ %^&*( )_ +. ";

            //Act
            var response = formatter.FormatString(input);

            //Assert
            Assert.AreEqual("abcde12345", response);
        }
    }
}
