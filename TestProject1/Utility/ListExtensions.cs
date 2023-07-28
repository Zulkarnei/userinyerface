namespace Aquality.Selenium.Template.Utilities
{
    public static class ListExtensions
    {
        private static readonly Random Random = new Random();

        public static void Shuffle(this List<char> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                char value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
