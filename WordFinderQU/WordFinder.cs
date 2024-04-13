using System.Runtime.InteropServices;
using System.Text;

namespace WordFinderQU
{
    public class WordFinder
    {
        private int X;
        private int Y;
        private IEnumerable<string> MatrixX;
        private IEnumerable<string> MatrixY;

        public WordFinder(IEnumerable<string> matrix)
        {
            X = matrix.Any()? matrix.First().Length : 0;
            Y = matrix.Count();
            MatrixX = matrix;
            MatrixY = GetVerticalWords(matrix);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var result = new List<string>();

            var spanX = CollectionsMarshal.AsSpan<string>(MatrixX.ToList());
            var spanY = CollectionsMarshal.AsSpan<string>(MatrixY.ToList());
            var wordstreamX = PreProcess(wordstream, X);
            var wordstreamY = PreProcess(wordstream, Y);

            var spanWSx = CollectionsMarshal.AsSpan<string>(wordstreamX.ToList());
            var spanWSy = CollectionsMarshal.AsSpan<string>(wordstreamY.ToList());

            var resH = WordFinderByDimention(spanWSx, spanX);
            var resV = WordFinderByDimention(spanWSy, spanY);

            result.AddRange(resH);
            result.AddRange(resV);

            return GetTopTen(result);
        }

        #region Private

        /// <summary>
        /// Find words from wordstream, found in array
        /// </summary>
        /// <param name="wordstream"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        private List<string> WordFinderByDimention(ReadOnlySpan<string> wordstream, ReadOnlySpan<string> array)
        {
            var result = new List<string>();
            SearchCoincidences(result, wordstream, array);
            return result;
        }

       /// <summary>
       /// Return vertical words, top to bottom 
       /// </summary>
       /// <param name="currentMatrix"></param>
       /// <returns></returns>
        private IEnumerable<string> GetVerticalWords(IEnumerable<string> currentMatrix)
        {
            List<string> vertical = new List<string>();

            for (int i = 0; i <= currentMatrix.Count() - 1; i++)
            {
                var sb = new StringBuilder();
                currentMatrix.ToList().ForEach(delegate (string horizontalWord)
                {
                    sb.Append(horizontalWord.ElementAt(i));
                });

                vertical.Add(sb.ToString());
            }

            return vertical;
        }

        /// <summary>
        /// Removes repeated words and words longer than any matrix dimension
        /// </summary>
        /// <param name="wordstream"></param>
        /// <param name="dimension"></param>
        /// <returns>Return distinct elements and remove elements with length longer than Dimension</returns>
        private IEnumerable<string> PreProcess(IEnumerable<string> wordstream, int dimension)
        {
            return wordstream.Distinct().Where(ws => ws.Length <= dimension);
        }

        /// <summary>
        /// Return the top ten repeated, sorted descending by ranking and ascending alphabetical
        /// </summary>
        /// <param name="foundWords"></param>
        /// <returns></returns>
        private IEnumerable<string> GetTopTen(IEnumerable<string> foundWords)
        {
            var groupedFound = foundWords.GroupBy(x => x);
            var ordered = groupedFound.OrderByDescending(g => g.Count()).ThenBy(g => g.Key);
            return ordered.Select(g => g.Key).Take(10);

        }

        /// <summary>
        /// Appends to the result collection, words from wordstream found in listToMatch 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="wordstream"></param>
        /// <param name="listToMatch"></param>
        private void SearchCoincidences(List<string> result, ReadOnlySpan<string> wordstream, ReadOnlySpan<string> listToMatch)
        {
            for (int i = 0; i < wordstream.Length; i++)
            {
                SearchIn(result, wordstream[i], listToMatch);
            }

        }

        /// <summary>
        /// Adds wordToSearch into result collection, only if it's found in listToMatch
        /// </summary>
        /// <param name="result"></param>
        /// <param name="wordToSearch"></param>
        /// <param name="listToMatch"></param>
        private void SearchIn(List<string> result, string wordToSearch, ReadOnlySpan<string> listToMatch)
        {
            for (int i = 0; i < listToMatch.Length; i++)
            {
                if (listToMatch[i].Contains(wordToSearch))
                    result.Add(wordToSearch);
            }

        }

        #endregion

    }
}
