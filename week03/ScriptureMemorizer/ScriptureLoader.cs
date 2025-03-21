using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLoader
{
    private List<Scripture> _scriptureLibrary;

    public ScriptureLoader()
    {
        _scriptureLibrary = new List<Scripture>();
        LoadDefaultScriptures();
        LoadScripturesFromFile();
    }

    // Get a random scripture from the library
    public Scripture GetRandomScripture()
    {
        if (_scriptureLibrary.Count == 0)
        {
            Reference fallbackRef = new Reference("John", 3, 16);
            return new Scripture(fallbackRef, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        }

        Random random = new Random();
        int index = random.Next(_scriptureLibrary.Count);
        return _scriptureLibrary[index];
    }

    public List<Scripture> GetAllScriptures()
    {
        return _scriptureLibrary;
    }

    private void LoadDefaultScriptures()
    {
        Reference johnReference = new Reference("John", 3, 16);
        Scripture johnScripture = new Scripture(johnReference, 
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        _scriptureLibrary.Add(johnScripture);

        Reference proverbsReference = new Reference("Proverbs", 3, 5, 6);
        Scripture proverbsScripture = new Scripture(proverbsReference, 
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        _scriptureLibrary.Add(proverbsScripture);

        Reference malachiReference = new Reference("Malachi", 3, 10);
        Scripture malachiScripture = new Scripture(malachiReference, 
            "Bring ye all the tithes into the storehouse, that there may be meat in mine house, and prove me now herewith, saith the Lord of hosts, if I will not open you the windows of heaven, and pour you out a blessing, that there shall not be room enough to receive it.");
        _scriptureLibrary.Add(malachiScripture);
    }

    // Load scriptures from a file
    private void LoadScripturesFromFile()
    {
        try
        {
            string filePath = "scriptures.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 2)
                {
                    if (i + 1 < lines.Length)
                    {
                        string referenceText = lines[i].Trim();
                        string scriptureText = lines[i + 1].Trim();

                        if (!string.IsNullOrEmpty(referenceText) && !string.IsNullOrEmpty(scriptureText))
                        {
                            try
                            {
                                // Parse reference text
                                Reference reference = ParseReference(referenceText);
                                Scripture scripture = new Scripture(reference, scriptureText);
                                _scriptureLibrary.Add(scripture);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error parsing scripture at line {i+1}: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures from file: {ex.Message}");
        }
    }

    // Parse a reference string (e.g., "John 3:16" or "Proverbs 3:5-6")
    private Reference ParseReference(string referenceText)
    {
        string[] parts = referenceText.Split(' ');
        
        string chapterVerse = parts[parts.Length - 1];
        
        string book = referenceText.Substring(0, referenceText.Length - chapterVerse.Length - 1);
        
        string[] chapterVerseParts = chapterVerse.Split(':');
        int chapter = int.Parse(chapterVerseParts[0]);
        
        if (chapterVerseParts[1].Contains("-"))
        {
            string[] verseParts = chapterVerseParts[1].Split('-');
            int startVerse = int.Parse(verseParts[0]);
            int endVerse = int.Parse(verseParts[1]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            int verse = int.Parse(chapterVerseParts[1]);
            return new Reference(book, chapter, verse);
        }
    }
}