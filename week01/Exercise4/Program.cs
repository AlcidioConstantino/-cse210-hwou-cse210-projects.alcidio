using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = 0;

        foreach (int item in numbers)
        {
            sum += item;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = (float)sum / numbers.Count;

        Console.WriteLine($"The average is: {average}");

        int largest = numbers[0];

        foreach (int item in numbers)
        {
            if (item > largest)
            {
                largest = item;
            }
        }

        Console.WriteLine($"The largest number is: {largest}");
    }
}