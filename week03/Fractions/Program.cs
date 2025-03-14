using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        Console.WriteLine("\nTesting getters and setters:");
        Fraction fraction5 = new Fraction();
        
        Console.WriteLine($"Initial values: {fraction5.GetFractionString()}");
        
        fraction5.SetNumerator(6);
        fraction5.SetDenominator(8);
        
        Console.WriteLine($"New numerator: {fraction5.GetNumerator()}");
        Console.WriteLine($"New denominator: {fraction5.GetDenominator()}");
        Console.WriteLine($"New fraction: {fraction5.GetFractionString()}");
        Console.WriteLine($"Decimal value: {fraction5.GetDecimalValue()}");
    }
}