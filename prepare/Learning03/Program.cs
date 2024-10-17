using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Console.WriteLine(one.GetFraction());
        Console.WriteLine(one.GetDecimal());

        Fraction two = new Fraction(5);
        Console.WriteLine(two.GetFraction());
        Console.WriteLine(two.GetDecimal());

        Fraction three = new Fraction(3, 4);
        Console.WriteLine(three.GetFraction());
        Console.WriteLine(three.GetDecimal());

        Fraction four = new Fraction(1, 3);
        Console.WriteLine(four.GetFraction());
        Console.WriteLine(four.GetDecimal());
    }
}
