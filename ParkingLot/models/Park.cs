using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace models
{
    public class ParkingLot(decimal initialPrice, decimal pricePerHour)
    {
        private readonly decimal initialPrice = initialPrice;
        private readonly decimal pricePerHour = pricePerHour;
        private readonly List<string> vehicles = [];

 public void AddVehicle()
{
    try
    {
        Console.Write("Type your license plate number: ");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input) || input.Length < 7 || input.Length > 8)
        {
            Console.WriteLine("Please enter a valid license plate number!\n");
        }
        else if (vehicles.Contains(input))
        {
            Console.WriteLine("Vehicle's license plate number already exists!\n");
        }
        else
        {
            vehicles.Add(input);
            Console.WriteLine("Vehicle added successfully!\n");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error while adding vehicle: " + e.Message + "\n");
    }
}

public void RemoveVehicle()
{
    try
    {
        Console.WriteLine("       ### VEHICLE CHECKOUT ###\n");
        Console.Write("Please enter your license plate number: ");
        string licensePlate = Console.ReadLine();

        if (string.IsNullOrEmpty(licensePlate) || licensePlate.Length < 7 || licensePlate.Length > 8)
        {
            Console.WriteLine("Please enter a correct license plate number!\n");
        }
        else
        {
            if (vehicles.Contains(licensePlate))
            {
                Console.Write("Please enter how many hours you stood in the park!: ");
                string hours = Console.ReadLine();

                if (string.IsNullOrEmpty(hours) || !decimal.TryParse(hours, out decimal hoursStood))
                {
                    Console.WriteLine("Please enter a valid number!\n");
                }
                else
                {
                    decimal checkout = hoursStood * pricePerHour + initialPrice;
                    Console.WriteLine("Total: " + checkout + " $$");
                    vehicles.Remove(licensePlate);
                    Console.WriteLine("Thank you for utilizing our services!\n");
                }
            }
            else
            {
                Console.WriteLine("License plate number not recognized!\nPlease enter your license plate number again!\n");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error while trying to identify the vehicle: " + e.Message + "\n");
    }
}

public void ListVehicles()
{
    try
    {
        if (vehicles.Count != 0)
        {
            foreach (string vehicle in vehicles)
            {
                Console.WriteLine("Vehicle's license plate number: " + vehicle + "\n");
            }
        }
        else
        {
            Console.WriteLine("No vehicle's license plate number registered!\n");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error while listing vehicles: " + e.Message + "\n");
    }
}
}
}