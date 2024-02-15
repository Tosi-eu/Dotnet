﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using models;

class Program
{
    static List<Person> guests = new List<Person>();
    static Reservation reservation;

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        reservation = new Reservation();

        while (true)
        {
            ShowMenu();

            string option = Console.ReadLine();

            try
            {
                switch (option)
                {
                    case "1":
                        Console.Write("Tell the number of people: ");
                        string numberOfPeopleInput = Console.ReadLine();
                        int numberOfPeople = Convert.ToInt32(numberOfPeopleInput);
                        guests.Clear();

                        for (int i = 0; i < numberOfPeople; i++)
                        {
                            Console.Write($"Person's {i + 1} name: ");
                            string name = Console.ReadLine();

                            Console.Write($"Person's {i + 1} age: ");
                            string ageInput = Console.ReadLine();
                            int age = Convert.ToInt32(ageInput);

                            Person person = new Person(name, age);
                            guests.Add(person);
                        }
                        break;

                    case "2":
                        Console.Write("Tell the suite type: ");
                        string suiteType = Console.ReadLine();

                        Console.Write("Tell the suite's size: ");
                        string suiteSizeInput = Console.ReadLine();
                        int suiteSize = Convert.ToInt32(suiteSizeInput);

                        if (suiteSize < guests.Count)
                        {
                            Console.WriteLine("Suite's size is insufficient!");
                            break;
                        }

                        Console.Write("Tell the daily rate price: ");
                        string dailyRateInput = Console.ReadLine();
                        decimal dailyRate = Convert.ToDecimal(dailyRateInput);

                        Suite suite = new Suite(suiteType, suiteSize, dailyRate);
                        reservation.RegisterSuite(suite);
                        reservation.RegisterGuests(guests);

                        Console.WriteLine("Suite and guests registered successfully!");
                        break;

                    case "3":
                        Console.WriteLine($"Guests: {reservation.GetNumberOfGuests()}");
                        Console.Write("Number of days booked: ");
                        int numberOfDays = Convert.ToInt32(Console.ReadLine());
                        reservation.DaysBooked = numberOfDays;
                        reservation.CalculateDailyRate("en-US");
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine($"Invalid operation: {option}");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The number is too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("1. Register Guests");
        Console.WriteLine("2. Register Suite");
        Console.WriteLine("3. Calculate Stay Value");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");
    }
}
