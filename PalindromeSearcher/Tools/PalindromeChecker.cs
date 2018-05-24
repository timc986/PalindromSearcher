using PalindromeSearcher.Interface;

namespace PalindromeSearcher.Tools
{
    public class PalindromeChecker: IPalindromeChecker
    {
        public bool IsPalindrome(string input)
        {
            //returns false if the input does not fit the basic requirement to be a palindrome
            if (string.IsNullOrWhiteSpace(input) || input.Length <= 1)
            {
                return false;
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
