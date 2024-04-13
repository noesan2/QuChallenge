namespace WordFinderQU
{
    class Program()
    {
        static void Main()
        {
            var currentMatrix = new List<string>() { "abcac", "fgwio", "chill", "pqnsd", "uvdxy" };
            var wordFinder = new WordFinder(currentMatrix);

            var result = wordFinder.Find(new List<string>() { "cold", "wind", "snow", "chill"  });

            Console.WriteLine("Top 10 found words: ");
            foreach (var item in result)
            {
                Console.WriteLine(" - {0}",item);
            }
        }

    }
}