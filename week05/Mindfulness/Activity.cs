using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private static int _totalActivitiesPerformed = 0;
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }
    
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        _duration = duration;
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }
    
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        _totalActivitiesPerformed++;
        Console.WriteLine($"You have completed {_totalActivitiesPerformed} activities in this session.");
        Thread.Sleep(3000);
    }
    
    // this is the method to show spinner animation
    public void ShowSpinner(int seconds)
    {
        // it shows the array of spinner characters for a more elaborate animation
        string[] spinnerChars = { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        
        int i = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[i]);
            Thread.Sleep(100);
            Console.Write("\b");
            
            i++;
            if (i >= spinnerChars.Length)
            {
                i = 0;
            }
        }
    }
    
    // shows the countdown timer
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    
    // the getter for duration
    public int GetDuration()
    {
        return _duration;
    }
}