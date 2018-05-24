using NUnit.Framework;
using PalindromeSearcher.Interface;
using PalindromeSearcher.Tools;

namespace PalindromeSearcherTest.Tools
{
    [TestFixture]
    public class PalindromeCheckerTest
    {
        private IPalindromeChecker checker;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            checker = new PalindromeChecker();
        }

        [Test]
        public void GIVEN_an_emptystring_WHEN_IsPalindrome_is_called_THEN_should_return_false()
        {
            //Arrange
            var input = "";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(false, response);
        }

        [Test]
        public void GIVEN_a_null_WHEN_IsPalindrome_is_called_THEN_should_return_false()
        {
            //Act
            var response = checker.IsPalindrome(null);

            //Assert
            Assert.AreEqual(false, response);
        }

        [Test]
        public void GIVEN_a_spacestring_WHEN_IsPalindrome_is_called_THEN_should_return_false()
        {
            //Arrange
            var input = " ";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(false, response);
        }

        [Test]
        public void GIVEN_an_even_Palindrome_WHEN_IsPalindrome_is_called_THEN_should_return_true()
        {
            //Arrange
            var input = "abba";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(true, response);
        }

        [Test]
        public void GIVEN_an_odd_Palindrome_WHEN_IsPalindrome_is_called_THEN_should_return_true()
        {
            //Arrange
            var input = "aabaa";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(true, response);
        }

        [Test]
        public void GIVEN_an_even_Palindrome_wtih_numbers_WHEN_IsPalindrome_is_called_THEN_should_return_true()
        {
            //Arrange
            var input = "12abba21";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(true, response);
        }

        [Test]
        public void GIVEN_an_odd_Palindrome_with_numbers_WHEN_IsPalindrome_is_called_THEN_should_return_true()
        {
            //Arrange
            var input = "aa3b3aa";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(true, response);
        }

        [Test]
        public void GIVEN_a_non_Palindrome_WHEN_IsPalindrome_is_called_THEN_should_return_false()
        {
            //Arrange
            var input = "abc";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(false, response);
        }

        [Test]
        public void GIVEN_a_non_Palindrome_with_numbers_WHEN_IsPalindrome_is_called_THEN_should_return_false()
        {
            //Arrange
            var input = "abc2";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(false, response);
        }

        [Test]
        public void GIVEN_a_single_letter_WHEN_IsPalindrome_is_called_THEN_should_return_false()
        {
            //Arrange
            var input = "a";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(false, response);
        }

        [Test]
        public void GIVEN_a_single_number_WHEN_IsPalindrome_is_called_THEN_should_return_false()
        {
            //Arrange
            var input = "2";

            //Act
            var response = checker.IsPalindrome(input);

            //Assert
            Assert.AreEqual(false, response);
        }
    }
}
