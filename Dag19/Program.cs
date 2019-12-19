using System;
using System.Collections.Generic;

namespace Dag19
{
    class Program
    {
        private static HashSet<int> _palindromes = new HashSet<int>();

        static void Main(string[] args)
        {
            long sumOfHiddenPalindromes = 0;

            for (int i = 1; i < 123454321; i++)
            {
                var numberArray = i.ToString().ToCharArray();
                Array.Reverse(numberArray);
                var reverseNumber = int.Parse(new string(numberArray));
                var newNum = i + reverseNumber;

                if (!IsPalindrome(i) && IsPalindrome(newNum))
                {
                    sumOfHiddenPalindromes += i;
                }
            }

            Console.WriteLine(sumOfHiddenPalindromes);
        }

        private static bool IsPalindrome(int newNum)
        {
            if (_palindromes.Contains(newNum))
            {
                return true;
            }

            var newNumString = newNum.ToString();

            for (int i = 0; i < newNumString.Length / 2; i++)
            {
                var n1 = newNumString[i];
                var n2 = newNumString[^(i + 1)];

                if (n1 != n2)
                {
                    return false;
                }
            }

            _palindromes.Add(newNum);

            return true;
        }
    }
}
