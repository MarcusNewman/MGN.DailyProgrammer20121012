using System;

namespace MGN.AllPossibleDecodings
{
    //Consider the translation from letters to numbers a -> 1 through z -> 26. Every sequence of letters can be translated into a string of numbers this way,
    //with the numbers being mushed together. For instance hello -> 85121215. Unfortunately the reverse translation is not unique. 85121215 could map to hello,
    //but also to heaubo. Write a program that, given a string of digits, outputs every possible translation back to letters.
    //Sample input:
    //123
    //Sample output:
    //abc
    //aw
    //lc
    public class AllPossibleDecodings
    {
        public static string[] GetAllPossibleDecodings(String input)
        {
            var result = string.Empty;
            //lets get it to return abc first
            foreach(var letter in input.ToCharArray())
            {
                var value = Convert.ToInt32(letter);
                result += (char)(value + 97-49);
            }
            return new string[] { result };
            //return new string[] { "abc", "aw", "lc" };
            //return new string[] { "hello" };
        }
    }
}
