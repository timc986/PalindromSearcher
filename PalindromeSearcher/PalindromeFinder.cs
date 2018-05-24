using PalindromeSearcher.Interface;
using PalindromeSearcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PalindromeSearcher
{
    public class PalindromeFinder: IPalindromeFinder
    {
        private IStringFormatter stringFormatter;
        private IPalindromeChecker palindromeChecker;

        public PalindromeFinder(IStringFormatter StringFormatter, IPalindromeChecker PalindromeChecker)
        {
            stringFormatter = StringFormatter;
            palindromeChecker = PalindromeChecker;
        }

        public List<PalindromeResult> FindPalindromes(string input, int max)
        {
            List<PalindromeResult> result = new List<PalindromeResult>();

             // only allows alphabets and numbers and remove case sensitivity
             input = stringFormatter.FormatString(input);

            //continue only if the input fits the basic requirement to be a palindrome
            //and if the max number of longest unique palindromes is more than zero
            if (input.Length > 1 && max > 0)
            {             
                //Search for palindrome begins from the longest possible length
                result = SearchAlgorithm(input, max, result);
            }

            return result;
        }

        private List<PalindromeResult> SearchAlgorithm(string input, int max, List<PalindromeResult> result)
        {
            //loop down for search length
            for (int i = input.Length; i > 1; i--)
            {
                //loop up for starting index
                for (int j = 0; j <= input.Length - i; j++)
                {
                    //specific section
                    var subString = input.Substring(j, i);

                    //check if the selected string is a palindrome
                    if (palindromeChecker.IsPalindrome(subString))
                    {
                        //check if the new found palindrome is inside another existing palindrome
                        //alternatively can store the index and range of all the previously found palindromes in an array and skip them the nex time
                        //using LINQ though improves readability and do not need to save the index to another array
                        if (!result.Any(r => (r.Index < j || j == 0) && (r.Index + r.Length) > j))
                        {
                            var distinctResultLengths = result.Select(r => r.Length).Distinct();

                            //only add to result if the result has not exceed the max number of longest unique palindromes want to get 
                            //or there are nultiples palindromes with same length
                            if (distinctResultLengths.Count() <= max)
                            {
                                //add to result list if its an unique palindrome
                                result.Add(new PalindromeResult
                                {
                                    Text = subString,
                                    Index = j,
                                    Length = i
                                });
                            }
                        }
                    }
                }

                //return results if the results list already reaches the max number of top longest unique palindromes want to get to improve speed
                if (result.Select(r => r.Length).Distinct().Count() == max)
                {
                    break;
                }
            }

            return result;
        }
    }
}
