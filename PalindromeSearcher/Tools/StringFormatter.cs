using PalindromeSearcher.Interface;
using System;
using System.Text.RegularExpressions;

namespace PalindromeSearcher.Tools
{
    public class StringFormatter: IStringFormatter
    {
        //can change this to an extension method if required
        public string FormatString(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            //only allows alphabets and numbers
            var regexPattern = "[^a-zA-Z0-9]";            
            var alphaNumericOnly = Regex.Replace(input, regexPattern, String.Empty);

            //convert upper case letters to lower as Palindome should not be case sensitive
            var result = alphaNumericOnly.ToLower();

            return result;
        }
    }
}
