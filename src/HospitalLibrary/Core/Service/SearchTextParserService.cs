using System.Text;
using Castle.Core.Internal;

namespace HospitalLibrary.Core.Service;

public class SearchTextParserService : ISearchTextParserService
{
    public List<string> ParseSearchText(string searchText)
    {
        searchText = searchText.Trim();
        var wordsAndPhrases = new List<string>();

        if (searchText.Contains('"'))
        {
            var i1 = searchText.IndexOf('"');
            if (i1 >= 0)
            {
                var i2 = searchText.IndexOf('"', i1 + 1);
                if (i2 >= 0)
                {
                    wordsAndPhrases.Add(searchText.Substring(i1 + 1, i2 - i1 - 1));
                    var leftSubstring = searchText.Substring(0, i1);
                    var rightSubstring = searchText.Substring(i2 + 1, searchText.Length - i2 - 1);
                    wordsAndPhrases.AddRange(leftSubstring.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
                    wordsAndPhrases.AddRange(rightSubstring.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
                    return wordsAndPhrases;
                }
            }
        }
        wordsAndPhrases.AddRange(searchText.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
        return wordsAndPhrases;
    }
}