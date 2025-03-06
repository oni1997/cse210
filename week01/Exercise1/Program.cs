using System;

class Program
{
    static void Main(string[] args)
    {
        //input user for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        //input user for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        //print the name and surname
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
