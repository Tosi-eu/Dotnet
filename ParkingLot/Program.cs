using models;
using System;

try
{
    Console.WriteLine("Specify the hour value and the initial price for the parking lot:");
    Console.Write("Parking lot hour value: ");
    string iP = Console.ReadLine();
    if (!decimal.TryParse(iP, out decimal initialPrice))
    {
        Console.WriteLine("Please enter a valid initial price!\n");
        return;
    }

    Console.Write("Parking lot's initial price: ");
    string pPH = Console.ReadLine();
    if (!decimal.TryParse(pPH, out decimal pricePerHour))
    {
        Console.WriteLine("Please enter a valid price per hour!\n");
        return;
    }

    ParkingLot parkingLot = new(initialPrice, pricePerHour);
    bool showMenu = true;

    while (showMenu)
    {
        Console.Write("     ### PARK MENU ###\n" + "### 1 - Add Vehicle - 1 ###\n"
                        + "### 2 - Remove Vehicle - 2 ###\n" + "### 3 - List All Vehicles - 3 ###\n"
                        + "### 4 - EXIT - 4 ###\n" + "Choose an option: ");

        string option = Console.ReadLine();
        if (!int.TryParse(option, out int op))
        {
            Console.WriteLine("Please enter a valid option!\n");
            continue;
        }

        Console.Clear();

        switch (op)
        {
            case 1:
                parkingLot.AddVehicle();
                break;
            case 2:
                parkingLot.RemoveVehicle();
                break;
            case 3:
                parkingLot.ListVehicles();
                break;
            case 4:
                Console.WriteLine("\nExiting from the system");
                showMenu = false;
                break;
            default:
                Console.WriteLine("\nInvalid option, choose another option!\n");
                break;
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Error in the main program: " + e.Message + "\n");
}
