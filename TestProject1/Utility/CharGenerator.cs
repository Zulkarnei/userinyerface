namespace Aquality.Selenium.Template.Utilities
{
    public abstract class CharGenerator
    {
        public abstract char[] GetCharacters();
    }

    public class CyrillicCharacterData : CharGenerator
    {
        public static readonly CharGenerator LowerCase = new CyrillicCharacterData("абвгдеёжзийклмнопрстуфхцчшщъыьэюя");

        private readonly char[] characters;

        public CyrillicCharacterData(string characters)
        {
            this.characters = characters.ToCharArray();
        }

        public override char[] GetCharacters()
        {
            return characters;
        }
    }

    public class EnglishCharacterData : CharGenerator
    {
        public static readonly CharGenerator Alphabetical = new EnglishCharacterData("abcdefghijklmnopqrstuvwxyz");
        public static readonly CharGenerator UpperCase = new EnglishCharacterData("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        public static readonly CharGenerator Digit = new EnglishCharacterData("0123456789");

        private readonly char[] characters;

        public EnglishCharacterData(string characters)
        {
            this.characters = characters.ToCharArray();
        }

        public override char[] GetCharacters()
        {
            return characters;
        }
    }
}
