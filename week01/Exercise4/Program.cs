using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int userNumber = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            // Only add the number to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Check if the list is empty to prevent errors during calculations
        if (numbers.Count > 0)
        {
            // Part 1: Compute the sum
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The sum is: {sum}");

            // Part 2: Compute the average
            float average = ((float)sum) / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            // Part 3: Find the largest number
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge 1: Find the smallest positive number (closest to zero)
            int? smallestPositive = null;
            foreach (int number in numbers)
            {
                if (number > 0)
                {
                    if (smallestPositive == null || number < smallestPositive)
                    {
                        smallestPositive = number;
                    }
                }
            }

            if (smallestPositive != null)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch Challenge 2: Sort the numbers and display the list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}