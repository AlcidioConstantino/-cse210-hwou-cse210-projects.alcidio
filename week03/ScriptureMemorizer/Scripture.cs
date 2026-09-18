public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        // EXCEEDS REQUIREMENT: Only hide words that are not already hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide; i++)
        {
            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string referenceString = _reference.GetDisplayText();
        string wordsString = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{referenceString} {wordsString}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public int GetVisibleWordCount()
    {
        return _words.Count(word => !word.IsHidden());
    }

    public int GetWordCount()
    {
        return _words.Count;
    }
}
