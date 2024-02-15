namespace Models
{
    public abstract class Smartphone
    {
        public string Number { get; set; }
        
        private string Model { get; set; }

        private string IMEI { get; set; }

        private int Memory { get; set; }

        public Smartphone(string number, string imei, string model, int memory)
        {
            Number = number;
            IMEI = imei;
            Model = model;
            Memory = memory;
        }

        public static void MakeCall()       
        {
            Console.WriteLine("Calling!");
        }

        public static void ReceiveCall()
        {
            Console.WriteLine("Phone calling!\tAccept?");
        }

        public abstract void InstallApp(string appName);
    }
}