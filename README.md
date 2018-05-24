# Palindrome Searcher

The PalindromeSearcher is a console application written in C#
that finds the 3 longest unique palindromes in a supplied string.
It will output the palindrome together with the start index and length,
result will be printed out in the console in descending order of length

The solution consists of 2 projects with 2 relevant test projects: ConsoleApp and PalindromeSearcher

ConsoleApp calls the PalindromeSearcher to find unique palindromes in a string and print out the result to the console.

PalindromeSearcher contains Interfaces and model.
Most of the logics are in the PalindromeFinder.
The PalindromeSearcher also has two classes: PalindromeChecker and StringFormatter
which check if the string is a single Palindrome and format the string
they can be used in other projects if required (possibly place in another project for share use).

## Assumption:

Palindrome can only consists of alphabet letters and numbers
Should not be case sensitivity for palindrome. ie, upper case and lower case letter is treated the same.

## How to run:

1. Open the PalindromeSearcher.sln with Visual Studio (Preferably VS2017)
2. Right click on the Solution and restore Nuget Packages
3. Right click on the ConsoleApp project and set as startup project
4. Input string and the max number of longest unique palindromes can be changed in the ConsoleApp - Program
5. Build and start running the ConsoleApp by clicking the Start button on F5 on the keyboard
6. Result should then be printed out in the console