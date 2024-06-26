 using MotoApp3.Repositories;
using MotoApp3.Entities;
using MotoApp3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {


        var carsRepository = new SqlRepository<Cars>(new MotoAppDbContext());
        var customerRepository = new SqlRepository<Customer>(new MotoAppDbContext());

        string input;
        do
        {
            Console.WriteLine("\nCustomer View");
            Console.WriteLine("1. Show Customers");
            Console.WriteLine("2. Add Customers");
            Console.WriteLine("3. Show Cars");
            Console.WriteLine("4. Add Cars");
            Console.WriteLine("\nPress q to quit");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    WriteAllToConsole(customerRepository);
                    break;
                case "2":
                    AddCustomers(customerRepository);
                    break;
                case "3":
                    WriteAllToConsole(carsRepository);
                    break;
                case "4":
                    AddCars(carsRepository);
                    break;
                default:
                    if (input != "q")
                        Console.WriteLine("Wrong input, Try again");
                    break;
            }
        } while (input != "q");
    }

    static void AddCars(IRepository<Cars> carsRepository)
    {
        Console.Write("Enter Car Model: ");
        string model = Console.ReadLine();
        Console.Write("Enter Car Country: ");
        string country = Console.ReadLine();
        Console.Write("Enter Car Year: ");
        if (!int.TryParse(Console.ReadLine(), out int year) || year < 0)
        {
            Console.WriteLine("Invalid Year, Please enter a valid year");
            return;
        }

        var newCar = new Cars
        {
            Model = model,
            Year = year,
            Country = country
        };
        carsRepository.Add(newCar);
        carsRepository.Save();
        Console.WriteLine("Car Added");
    }

    static void AddCustomers(IRepository<Customer> customerRepository)
    {
        Console.Write("Customer Name: ");
        string name = Console.ReadLine();
        Console.Write("Customer Surname: ");
        string surname = Console.ReadLine();
        Console.Write("Customer Age: ");
        if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
        {
            Console.WriteLine("Invalid Age, Please enter a valid age");
            return;
        }

        var newCustomer = new Customer { Name = name, Surname = surname, Age = age, };
        customerRepository.Add(newCustomer);
        customerRepository.Save();
        Console.WriteLine("Customer Added");
    }

    static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        if (items == null || !items.Any())
        {
            Console.WriteLine("No items found.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}

/*
var carsRepository = new SqlRepository<Cars>(new MotoAppDbContext());
var customerRepository = new SqlRepository<Customer>(new MotoAppDbContext());   
AddCars(carsRepository);
AddCustomers(customerRepository);
WriteAllToConsole(carsRepository);
string input;
do
{
    Console.WriteLine("\nCustomer View");
    Console.WriteLine("1. Show Customers");
    Console.WriteLine("2. Add Customers");
    Console.WriteLine("3. Show Cars");
    Console.WriteLine("4. Add Cars");
    Console.WriteLine("\n Press q to quit");

    input = Console.ReadLine();
    switch(input)
    {
        case "1":
            WriteAllToConsole (customerRepository);
            break;
        case "2":
            AddCustomers(customerRepository);
            break;
        case "3":
            WriteAllToConsole(customerRepository);
            break;
        case "4":
            AddCars(carsRepository);
            break;
        default:
            Console.WriteLine("Wrong input, Try again");
            break;
    }
} while (input != "q");
static void AddCars(IRepository<Cars> carsRepository)
{
    Console.Write("Enter Car Model:");
    string model = Console.ReadLine();
    Console.WriteLine("Enter Car country:");
    string country = Console.ReadLine();
    Console.WriteLine("Enter Car Year");
    if(!int.TryParse(Console.ReadLine(), out int year) || year < 0)
    {
        Console.WriteLine("Wrong Year, Put valid year again");
        return;
    }
    

    var newCar = new Cars 
    { 
        Model = model, 
        Year = year, 
        Country = country 
    };
    carsRepository.Add(newCar);
    Console.WriteLine("Car Added");
    carsRepository.Save();
}
static void AddCustomers(IRepository<Customer> customerRepository)
{
    Console.WriteLine("Enter:");
    Console.Write("Customer Name:");
    string name = Console.ReadLine();
    Console.WriteLine("Last Name:");
    string lastname = Console.ReadLine();

    var newCustomer = new Customer { Name = name, Surname = lastname };
    customerRepository.Add(newCustomer);
    Console.WriteLine("Client Added");
    customerRepository.Save();
}
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    
    var items = repository.GetAll();
    if (items == null)
    {
        Console.WriteLine("No Customers");
    }
    else
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}


*/