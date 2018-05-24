using PalindromeSearcher.Model;
using System.Collections.Generic;

namespace PalindromeSearcher.Interface
{
    public interface IPalindromeFinder
    {
        List<PalindromeResult> FindPalindromes(string input, int max);
    }
}
