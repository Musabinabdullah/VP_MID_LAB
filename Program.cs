using System;
using System.Collections.Generic;

namespace StudentClubApp
{
    
    public class StudentClub
    {
        private List<Society> societies;

        public StudentClub()
        {
            societies = new List<Society>();
            InitializeSocieties();
        }

       
        private void InitializeSocieties()
        {
            societies.Add(new FundedSociety("Techbit", "Mehmood", 600));
            societies.Add(new FundedSociety("Literary", "Naveena", 500));
            societies.Add(new FundedSociety("Sports", "Ali", 500));
            societies.Add(new NonFundedSociety("Media", "Moiz"));
        }

       
        public void RegisterSociety()
        {
            Console.Write("Enter society name: ");
            string name = Console.ReadLine();
            Console.Write("Enter contact person: ");
            string contact = Console.ReadLine();
            societies.Add(new NonFundedSociety(name, contact));
            Console.WriteLine("Society registered successfully.");
        }

       
        public void DispenseFunds()
        {
            foreach (var society in societies)
            {
                if (society is FundedSociety fundedSociety)
                {
                    Console.WriteLine($"{fundedSociety.Name} has received ${fundedSociety.FundingAmount}.");
                }
            }
        }

        
        public void RegisterEvent()
        {
            Console.Write("Enter society name: ");
            string name = Console.ReadLine();
            Society society = FindSocietyByName(name);
            if (society != null)
            {
                Console.Write("Enter event name: ");
                string eventName = Console.ReadLine();
                society.AddActivity(eventName);
                Console.WriteLine("Event registered successfully.");
            }
            else
            {
                Console.WriteLine("Society not found.");
            }
        }

        public void DisplaySocieties()
        {
            foreach (var society in societies)
            {
                Console.WriteLine($"Society: {society.Name}, Contact: {society.Contact}, Funding: {(society is FundedSociety fundedSociety ? fundedSociety.FundingAmount.ToString() : "None")}");
            }
        }

        public void DisplayEvents()
        {
            Console.Write("Enter society name: ");
            string name = Console.ReadLine();
            Society society = FindSocietyByName(name);
            if (society != null)
            {
                society.ListEvents();
            }
            else
            {
                Console.WriteLine("Society not found.");
            }
        }

       
        private Society FindSocietyByName(string name)
        {
            return societies.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }

   
    public class Society
    {
        public string Name { get; }
        public string Contact { get; }
        private List<string> activities;

        public Society(string name, string contact)
        {
            Name = name;
            Contact = contact;
            activities = new List<string>();
        }

      
        public void AddActivity(string activity)
        {
            activities.Add(activity);
        }

      
        public void ListEvents()
        {
            Console.WriteLine($"Events for {Name}:");
            foreach (var activity in activities)
            {
                Console.WriteLine(activity);
            }
        }
    }

  
    public class FundedSociety : Society
    {
        public double FundingAmount { get; }

        public FundedSociety(string name, string contact, double fundingAmount) : base(name, contact)
        {
            FundingAmount = fundingAmount;
        }
    }

   
    public class NonFundedSociety : Society
    {
        public NonFundedSociety(string name, string contact) : base(name, contact) { }
    }

    public class ClubRole
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string ContactInfo { get; set; }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            StudentClub studentClub = new StudentClub();
            int choice;

            do
            {
                Console.WriteLine("1. Register a new society");
                Console.WriteLine("2. Allocate funding to societies");
                Console.WriteLine("3. Register an event for a society");
                Console.WriteLine("4. Display Society Funding Information");
                Console.WriteLine("5. Display events for society");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        studentClub.RegisterSociety();
                        break;
                    case 2:
                        studentClub.DispenseFunds();
                        break;
                    case 3:
                        studentClub.RegisterEvent();
                        break;
                    case 4:
                        studentClub.DisplaySocieties();
                        break;
                    case 5:
                        studentClub.DisplayEvents();
                        break;
                }
            } while (choice != 6);
        }
    }
}
