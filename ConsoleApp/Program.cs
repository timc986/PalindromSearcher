using PalindromeSearcher;
using PalindromeSearcher.Interface;
using PalindromeSearcher.Tools;
using System;

namespace ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            IStringFormatter formatter;
            IPalindromeChecker checker;
            IPalindromeFinder finder;

            //in reality should use IOC like Unity but it might be overengineer for this console project
            formatter = new StringFormatter();
            checker = new PalindromeChecker();
            finder = new PalindromeFinder(formatter, checker);

            //set up the input and the max number of longest unique palindromes want to get 
            string inputString = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            int max = 4;

            //calls the PalindromeFinder to find palindromes inside a string
            var resultList = finder.FindPalindromes(inputString, max);

            //print out the palindromes if there is any
            foreach(var result in resultList)
            {
                Console.WriteLine("Text: {0}, Index: {1}, Length: {2}", result.Text, result.Index, result.Length);
            }
        }
    }
}
