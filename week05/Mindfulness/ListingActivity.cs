using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<int> _usedPromptIndices;
    
    public ListingActivity() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        
        _usedPromptIndices = new List<int>();
    }
    
    private string GetRandomPrompt()
    {
        if (_usedPromptIndices.Count >= _prompts.Count)
        {
            _usedPromptIndices.Clear();
        }
        Random random = new Random();
        int index;
        do
        {
            index = random.Next(0, _prompts.Count);
        } while (_usedPromptIndices.Contains(index));
        _usedPromptIndices.Add(index);
        return _prompts[index];
    }
    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("You may begin in...");
        ShowCountDown(5);
        Console.WriteLine();
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        
        List<string> responses = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }
            
            // to check if we've reached the end time
            if (DateTime.Now >= endTime)
                break;
        }
        Console.WriteLine($"You listed {responses.Count} items!");
        DisplayEndingMessage();
    }
}