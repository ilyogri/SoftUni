namespace _04.Morse_Code_Upgraded
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var morseCodes = Console.ReadLine().Split('|');

            var resultMessage = string.Empty;

            foreach (var morseCode in morseCodes)
            {
                var onesSeq = morseCode.Split(new string[] { "0" }, StringSplitOptions.RemoveEmptyEntries);
                var zeroesSeq = morseCode.Split(new string[] { "1" }, StringSplitOptions.RemoveEmptyEntries);

                var onesCount = morseCode.Count(x => x == '1');
                var zeroesCount = morseCode.Count(x => x == '0');

                var equalDigitsCount = GetEqualDigitsCount(onesSeq, zeroesSeq);
                var currentLetter = (char)((onesCount * 5) + (zeroesCount * 3) + equalDigitsCount);

                resultMessage += currentLetter;
            }

            Console.WriteLine(resultMessage);
        }

        public static int GetEqualDigitsCount(string[] ones, string[] zeroes)
        {
            var sequenceEqualDigits = ones.Concat(zeroes);
            var equalDigitsCount = 0;

            foreach (var sequence in sequenceEqualDigits.Where(x => x.Length > 1))
            {
                equalDigitsCount += sequence.Length;
            }

            return equalDigitsCount;
        }
    }
}