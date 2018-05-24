using NUnit.Framework;
using PalindromeSearcher.Interface;
using PalindromeSearcher.Tools;
using PalindromeSearcher;
using System.Linq;

namespace PalindromeSearcherTest
{
    [TestFixture]
    public class PalindromesFinderTest
    {
        private IStringFormatter formatter;
        private IPalindromeChecker checker;
        private IPalindromeFinder finder;

        [SetUp]
        public void SetUp()
        {
            //nothing to be mocked with as there is no external service such as data source or web api calling

            //Arrange
            formatter = new StringFormatter();
            checker = new PalindromeChecker();
            finder = new PalindromeFinder(formatter, checker);
        }

        [Test]
        public void GIVEN_an_emptystring_WHEN_FindPalindromes_is_called_THEN_should_return_no_result()
        {
            //Arrange
            string input = "";
            int max = 3;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.AreEqual(0, response.Count);
        }

        [Test]
        public void GIVEN_an_spacestring_WHEN_FindPalindromes_is_called_THEN_should_return_no_result()
        {
            //Arrange
            string input = " ";
            int max = 3;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.AreEqual(0, response.Count);
        }

        [Test]
        public void GIVEN_a_null_input_WHEN_FindPalindromes_is_called_THEN_should_return_no_result()
        {
            //Arrange
            int max = 3;

            //Act
            var response = finder.FindPalindromes(null, max);

            //Assert
            Assert.AreEqual(0, response.Count);
        }

        [Test]
        public void GIVEN_a_letter_WHEN_FindPalindromes_is_called_THEN_should_return_no_result()
        {
            //Arrange
            string input = "a";
            int max = 3;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.AreEqual(0, response.Count);
        }

        [Test]
        public void GIVEN_max_is_zero_WHEN_FindPalindromes_is_called_THEN_should_return_no_result()
        {
            //Arrange
            string input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            int max = 0;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.AreEqual(0, response.Count);
        }

        [Test]
        public void GIVEN_a_valid_input_WHEN_FindPalindromes_is_called_THEN_should_return_result()
        {
            //Arrange
            string input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            int max = 3;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.IsNotNull(response);
            Assert.NotZero(response.Count);
        }

        [Test]
        public void GIVEN_a_palindrome_WHEN_FindPalindromes_is_called_THEN_should_return_one_result()
        {
            //Arrange
            string input = "aabbaa";
            int max = 3;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Count);
        }

        [Test]
        public void GIVEN_a_palindrome_WHEN_FindPalindromes_is_called_THEN_should_return_one_result_with_text_index_length()
        {
            //Arrange
            string input = "aabbaa";
            int max = 3;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(input, response.First().Text);
            Assert.AreEqual(0, response.First().Index);
            Assert.AreEqual(input.Length, response.First().Length);
        }

        [Test]
        public void GIVEN_multiple_palindromes_WHEN_FindPalindromes_is_called_THEN_should_return_result_within_the_max()
        {
            //Arrange
            string input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            int max = 3;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.LessOrEqual(response.Select(r => r.Length).Distinct().Count(), max);
        }

        [Test]
        public void GIVEN_multiple_palindromes_with_same_length_WHEN_FindPalindromes_is_called_THEN_should_return_multiple_results_with_same_length_and_within_the_max()
        {
            //Arrange
            string input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            int max = 4;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.Less(max, response.Count());
            Assert.LessOrEqual(response.Select(r => r.Length).Distinct().Count(), max);
            Assert.AreEqual(1, response.GroupBy(g => g.Length).Where(w => w.Count() > 1).Count());
        }

        [Test]
        public void GIVEN_a_long_palindrome_WHEN_FindPalindromes_is_called_THEN_should_return_one_unique_result()
        {
            //Arrange
            string input = "hijkllkjih";
            int max = 3;

            //Act
            var response = finder.FindPalindromes(input, max);

            //Assert
            Assert.AreEqual(1, response.Count);
        }
    }
}
