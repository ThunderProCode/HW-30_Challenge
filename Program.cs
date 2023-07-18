using System;

// Delegate type for filtering conditions
public delegate bool FilterDelegate(int number);

public class Sieve
{
    private FilterDelegate filter;

    // Constructor taking a lambda expression as a parameter
    public Sieve(FilterDelegate filterMethod)
    {
        filter = filterMethod;
    }

    public bool IsGood(int number)
    {
        // Invoke the delegate (lambda expression) to perform the filtering
        return filter(number);
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose a filter:");
        Console.WriteLine("1. Even numbers");
        Console.WriteLine("2. Positive numbers");
        Console.WriteLine("3. Multiples of 10");
        Console.Write("Enter your choice (1, 2, or 3): ");
        string choice = Console.ReadLine();

        FilterDelegate selectedFilter;
        switch (choice)
        {
            case "1":
                selectedFilter = (number) => number % 2 == 0;
                break;
            case "2":
                selectedFilter = (number) => number > 0;
                break;
            case "3":
                selectedFilter = (number) => number % 10 == 0;
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting.");
                return;
        }

        Sieve sieve = new Sieve(selectedFilter);

        while (true)
        {
            Console.Write("Enter a number (or 'exit' to quit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;

            if (int.TryParse(input, out int number))
            {
                bool isGood = sieve.IsGood(number);
                Console.WriteLine(isGood ? "Good number!" : "Bad number!");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
