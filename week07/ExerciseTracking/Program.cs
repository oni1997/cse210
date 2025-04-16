using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create one of each activity type
        activities.Add(new Running(new DateTime(2023, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2023, 11, 3), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2023, 11, 3), 30, 20));

        // Display the summary for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
