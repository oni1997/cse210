using System;

class Program
{
    static void Main(string[] args)
    {
        // create a random number generator
        Random randomGenerator = new Random();
        string playAgain;

        do
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guess;
            int attempts = 0;

            Console.WriteLine("Welcome to 'Guess My Number'!");
            
            do
            {
                Console.Write("Enter your guess: ");
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.Write("Invalid input. Please enter a number: ");
                }
                // increment the number of attempts
                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed it in {attempts} attempts.");
                }
            // loop until the user guesses the correct number
            } while (guess != magicNumber);

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower();
        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}