namespace Classes.Indexers;

public class Sentence
{
    string[] words = "The quick brown fox".Split();

    // Indexer definition
    public string this[int wordNum]
    {
        get { return words[wordNum]; }
        set { words[wordNum] = value; }
    }

    // Indexer for System.Index
    public string this[Index index] => words[index];

    // Indexer for System.Range
    public string[] this[Range range] => words[range];
}
