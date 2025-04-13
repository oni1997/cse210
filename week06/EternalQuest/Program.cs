using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int totalPoints = 0;

        while (true)
        {
            Console.WriteLine($"\nYou have {totalPoints} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nThe types of Goals are:");
                    Console.WriteLine("  1. Simple Goal");
                    Console.WriteLine("  2. Eternal Goal");
                    Console.WriteLine("  3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    
                    string goalType = Console.ReadLine();
                    Console.Write("What is the name of your goal? ");
                    string name = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    int points = int.Parse(Console.ReadLine());

                    switch (goalType)
                    {
                        case "1":
                            goals.Add(new SimpleGoal(name, description, points));
                            break;
                        case "2":
                            goals.Add(new EternalGoal(name, description, points));
                            break;
                        case "3":
                            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                            int target = int.Parse(Console.ReadLine());
                            Console.Write("What is the bonus for accomplishing it that many times? ");
                            int bonus = int.Parse(Console.ReadLine());
                            goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                            break;
                    }
                    break;

                case "2":
                    Console.WriteLine("\nThe goals are:");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].GetDisplayString()}");
                    }
                    break;

                case "3":
                    Console.Write("\nWhat is the filename for the goal file? ");
                    string saveFilename = Console.ReadLine();
                    SaveGoals(goals, totalPoints, saveFilename);
                    break;

                case "4":
                    Console.Write("\nWhat is the filename for the goal file? ");
                    string loadFilename = Console.ReadLine();
                    (goals, totalPoints) = LoadGoals(loadFilename);
                    break;

                case "5":
                    if (goals.Count == 0)
                    {
                        Console.WriteLine("\nNo goals available to record.");
                        break;
                    }
                    
                    Console.WriteLine("\nThe goals are:");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
                    }
                    Console.Write("Which goal did you accomplish? ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    
                    if (goalIndex >= 0 && goalIndex < goals.Count)
                    {
                        int earnedPoints = goals[goalIndex].RecordEvent();
                        totalPoints += earnedPoints;
                        Console.WriteLine($"\nCongratulations! You have earned {earnedPoints} points!");
                    }
                    break;

                case "6":
                    return;
            }
        }
    }

    private static void SaveGoals(List<Goal> goals, int totalPoints, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    private static (List<Goal>, int) LoadGoals(string filename)
    {
        List<Goal> goals = new List<Goal>();
        int totalPoints = 0;

        try
        {
            string[] lines = File.ReadAllLines(filename);
            totalPoints = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] data = parts[1].Split("|");

                switch (type)
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])));
                        if (bool.Parse(data[3])) goals[^1].RecordEvent();
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal goal = new ChecklistGoal(
                            data[0], data[1], int.Parse(data[2]), 
                            int.Parse(data[3]), int.Parse(data[4]));
                        for (int j = 0; j < int.Parse(data[5]); j++)
                            goal.RecordEvent();
                        goals.Add(goal);
                        break;
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }

        return (goals, totalPoints);
    }
}
