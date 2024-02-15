namespace models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Reservation
    {
        public List<Person> Guests { get; set; }
        public Suite Suite { get; set; }
        public int DaysBooked { get; set; }

        public Reservation() { }

        public Reservation(int DaysBooked)
        {
            DaysBooked = DaysBooked;
        }

        public void RegisterGuests(List<Person> guests)
        {
            if (Suite.Capacity >= GetNumberOfGuests())
            {
                Guests = guests;
                Console.WriteLine($"Guests registered successfully!\nDate: {DateTime.Now.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Number of guests exceeds the suite's capacity!");
            }
        }

        public void RegisterSuite(Suite suite)
        {
            Suite = suite;
            Console.WriteLine($"Suite registered successfully!\nDate: {DateTime.Now.ToShortDateString()}");
        }

        public int GetNumberOfGuests()
        {
            if (Guests != null)
                return Guests.Count;
            else
                return 0;
        }

        public void CalculateDailyRate(string nationality)
        {
            CultureInfo culture = new CultureInfo(nationality);
            decimal value = DaysBooked * Suite.DailyRate;

            if (DaysBooked >= 10)
            {
                value -= value * (10 / 100);
                string withDiscount = value.ToString("C", culture);
                Console.WriteLine($"Total with discount: {withDiscount}\nDays booked: {DaysBooked}");
            }
            string withoutDiscount = value.ToString("C", culture);
            Console.WriteLine($"Total without discount: {withoutDiscount}\nDays booked: {DaysBooked}");
        }
    }
}
