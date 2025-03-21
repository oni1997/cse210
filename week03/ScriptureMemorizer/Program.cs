using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLoader loader = new ScriptureLoader();
        
        Console.Clear();
        Console.WriteLine("Scripture Memorizer Program");
        Console.WriteLine("==========================");
        Console.WriteLine("1. Practice with a random scripture");
        Console.WriteLine("2. Select from scripture library");
        Console.WriteLine("3. Exit");
        Console.Write("\nEnter your choice (1-3): ");
        
        string choice = Console.ReadLine();
        
        if (choice == "1")
        {
            Scripture scripture = loader.GetRandomScripture();
            PracticeScripture(scripture);
        }
        else if (choice == "2")
        {
            SelectScripture(loader);
        }
        else
        {
            Console.WriteLine("Thank you for using the Scripture Memorizer. Goodbye!");
            return;
        }
    }
    
    static void PracticeScripture(Scripture scripture)
    {
        string input = "";
        while (input.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");

            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All words are hidden. Press any key to exit.");
            Console.ReadKey();
        }
    }
    
    static void SelectScripture(ScriptureLoader loader)
    {
        List<Scripture> scriptures = loader.GetAllScriptures();
        
        Console.Clear();
        Console.WriteLine("Scripture Library");
        Console.WriteLine("================");
        
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayText().Split(' ')[0]}");
        }
        
        Console.Write("\nSelect a scripture (1-" + scriptures.Count + "): ");
        if (int.TryParse(Console.ReadLine(), out int selection) && selection >= 1 && selection <= scriptures.Count)
        {
            PracticeScripture(scriptures[selection - 1]);
        }
        else
        {
            Console.WriteLine("Invalid selection. Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}