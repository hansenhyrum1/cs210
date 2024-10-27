using System;
using System.Collections.Concurrent;
using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Alma", 34, 32);
        Scripture scripture =  new Scripture(reference, "For behold, this life is the time for men to prepare to meet God; yea, behold the day of this life is the day for men to perform their labors.");

        int run = 1;

        while (run == 1)
        {
            Console.Clear();
            Console.WriteLine(scripture.Display());
            Console.WriteLine("Press enter to hide words, type quit to exit.");
            string input = Console.ReadLine();
            

            if (input == "quit" || input == "Quit")
            {
                run = 0;
            }
            else
            {
                scripture.HideRandomWords();
                if (scripture.HiddenWordCount() == scripture.WordCount())
                {
                    Console.WriteLine("Good job");
                    run = 0;
                }
            }
        }
    }
}
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (var word in text.Split(" "))
        {
            _words.Add(new Word(word));
        }
    }

    private Random random = new Random();

    public void HideRandomWords()
    {
        
        int hiddenCount = 0;
        
        while (hiddenCount < 3 && hiddenCount + HiddenWordCount() < WordCount())
        {
            int index = random.Next(_words.Count);
            if (! _words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public int WordCount()
    {
        return _words.Count;
    }

    public int HiddenWordCount()
    {
        int hiddenCount = 0;
        foreach (var word in _words)
        {
            if (word.IsHidden()) hiddenCount++;
        }
        return hiddenCount;
    }

    public string Display()
    {
        string result = $"{_reference.Display()}: ";
        foreach (var word in _words)
        {
            result += word.Display() + " ";
        }
        return result.Trim();
    }
}

class Word
{
    private string _originalText;
    private string _displayText;
    private bool _hiddenSate;

    public Word(string text)
    {
        _originalText = text;
        _displayText =  text;
        _hiddenSate = false;
    }

    public void Hide()
    {
        _displayText = "_____";
        _hiddenSate = true;
    }

    public bool IsHidden()
    {
        return _hiddenSate;
    }

    public string Display()
    {
        return _displayText;
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string Display()
    {
        return _endVerse == 0
            ? $"{_book} {_chapter}:{_verse}"
            : $"{_book} {_chapter}:{_verse}-{_endVerse}";

    }
}