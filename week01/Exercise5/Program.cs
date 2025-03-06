using System;

class Program
{
    // function that returns the program welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // function that returns the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    // function that returns the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = Convert.ToInt32(Console.ReadLine());
        return userNumber;
    }

    // function that returns the square of the user's number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // function that displays the result
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }

    static void Main(string[] args)
    {
        // call the functions to run the program
        DisplayWelcome();
        
        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        
        int squaredNumber = SquareNumber(favoriteNumber);
        // display the result
        DisplayResult(name, squaredNumber);
    }
}
