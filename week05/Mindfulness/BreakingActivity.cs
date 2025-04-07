using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }
    
    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        
        // to continue until the specified duration is reached
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();
            
            // to check if we've reached the end time
            if (DateTime.Now >= endTime)
                break;
                
            Console.Write("Now breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
    }
}