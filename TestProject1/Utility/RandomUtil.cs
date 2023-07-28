using Aquality.Selenium.Elements.Interfaces;

namespace Aquality.Selenium.Template.Utilities
{
    public class RandomUtil
    {
        private static Random random = new Random();

        public static int GetRandomIndex(int collectionCount)
        {
            return random.Next(collectionCount);
        }

        public static string GenerateEmailPrefix()
        {
            const int RND_LENGTH = 8;
            return RandomStringUtils.Random(RND_LENGTH, true, true);
        }

        public static string GenerateMailBox()
        {
            const int MIN_LENGTH = 2;
            const int MAX_LENGTH = 5;
            return RandomStringUtils.RandomAlphabetic(MIN_LENGTH, MAX_LENGTH);
        }

        public static string GenerateCustomPassword(string email)
        {
            CharGenerator cyrilicLetter = CyrillicCharacterData.LowerCase;
            CharGenerator alphabeticalChars = EnglishCharacterData.Alphabetical;
            CharGenerator upperCaseChars = EnglishCharacterData.UpperCase;
            CharGenerator digitChars = EnglishCharacterData.Digit;

            List<char> passwordChars = new List<char>();

            char[] cyrillicChars = cyrilicLetter.GetCharacters();
            passwordChars.Add(cyrillicChars[random.Next(cyrillicChars.Length)]);

            char[] uppercaseChars = upperCaseChars.GetCharacters();
            passwordChars.Add(uppercaseChars[random.Next(uppercaseChars.Length)]);

            char[] digitCharsArr = digitChars.GetCharacters();
            passwordChars.Add(digitCharsArr[random.Next(digitCharsArr.Length)]);

            passwordChars.Add(email[random.Next(email.Length)]);

            for (int i = passwordChars.Count; i < 10; i++)
            {
                CharGenerator randomCharGenerator = GetRandomCharGenerator(alphabeticalChars, cyrilicLetter);
                char[] randomChars = randomCharGenerator.GetCharacters();
                passwordChars.Add(randomChars[random.Next(randomChars.Length)]);
            }

            passwordChars.Shuffle();

            return new string(passwordChars.ToArray());
        }

        private static CharGenerator GetRandomCharGenerator(params CharGenerator[] charGenerators)
        {
            return charGenerators[random.Next(charGenerators.Length)];
        }
    }

    public static class RandomStringUtils
    {
        private static readonly Random randomUtils = new Random();

        public static string Random(int length, bool useLetters, bool useNumbers)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[randomUtils.Next(s.Length)]).ToArray());
        }

        public static string RandomAlphabetic(int minLength, int maxLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int length = randomUtils.Next(minLength, maxLength + 1);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[randomUtils.Next(s.Length)]).ToArray());
        }
    }

}
