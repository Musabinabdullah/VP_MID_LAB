using System;
using System.Collections.Generic;

public class Society
{
    public string Name
    {
        get;
        private set;
    }
    public string Contact
    {
        get;
        private set;
    }

    private double funding;

    private List<string> events = new List<string>();

    public Society(string name, string contact, double initialFunding)
    {
        Name = name;
        Contact = contact;
        funding = initialFunding;
    }

    public void AllocateFunding(double amount)
    {
        funding += amount;
        Console.WriteLine($"Funding of ${amount} allocated to {Name}. Total funding: ${funding}");
    }

    public void AddEvent(string eventName)
    {
        events.Add(eventName);
        Console.WriteLine($"Event '{eventName}' added to {Name}");
    }

    public void DisplayFunding() => Console.WriteLine($"Society: {Name}, Funding: ${funding}");

    public void DisplayEvents()
    {
        Console.WriteLine($"Events for {Name}:");
        foreach (var e in events)
            Console.WriteLine($"- {e}");
    }
}

public class Program
{
    private static List<Society> societies = new List<Society>
    {
        new Society("Techbits Society", "techbit.com", 600),
        new Society("Sports Society", "sports.com", 500),
        new Society("Literary Society", "literary.com", 500)
    };
    public static void Main()
    {
        while (true)
        {

            Console.WriteLine("\n    Student Club Management System  ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Register a new society         ");
            Console.WriteLine("2. Allocate funding to a society  ");
            Console.WriteLine("3. Register an event for a society");
            Console.WriteLine("4. Display society funding info   ");
            Console.WriteLine("5. Display events for a society   ");
            Console.WriteLine("6. Exit");
            Console.WriteLine("---------------------------------------");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterSociety();
                    break;
                case "2":
                    AllocateFunding();
                    break;
                case "3":
                    RegisterEvent();
                    break;
                case "4":
                    DisplayFundingInfo();
                    break;
                case "5":
                    DisplayEvents();
                    break;
                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    private static void RegisterSociety()
    {
        Console.Write("Enter society name: ");
        string name = Console.ReadLine();

        Console.Write("Enter contact info: ");
        string contact = Console.ReadLine();

        Console.Write("Enter initial funding: ");
        double initialFunding = double.TryParse(Console.ReadLine(), out double funding) ? funding : 0;

        societies.Add(new Society(name, contact, initialFunding));

        Console.WriteLine($"Society '{name}' registered.");
    }

    private static void AllocateFunding()
    {
        Console.Write("Enter society name: ");
        string name = Console.ReadLine();

        Society society = societies.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (society != null)
        {
            Console.Write("Enter funding amount: ");

            if (double.TryParse(Console.ReadLine(), out double amount))
                society.AllocateFunding(amount);
            else
                Console.WriteLine("Invalid amount.");
        }
        else
            Console.WriteLine("Society not found.");
    }

    private static void RegisterEvent()
    {
        Console.Write("Enter society name: ");

        string name = Console.ReadLine();

        Society society = societies.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (society != null)
        {
            Console.Write("Enter event name: ");
            string eventName = Console.ReadLine();

            society.AddEvent(eventName);
        }
        else
            Console.WriteLine("Society not found.");
    }

    private static void DisplayFundingInfo()
    {
        foreach (var society in societies)

            society.DisplayFunding();
    }

    private static void DisplayEvents()
    {
        Console.Write("Enter society name: ");

        string name = Console.ReadLine();

        Society society = societies.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (society != null)
        {
            society.DisplayEvents();
        }
        else
            Console.WriteLine("Society not found.");
    }
}

