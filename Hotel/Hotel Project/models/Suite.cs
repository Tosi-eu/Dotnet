namespace models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string suiteType, int capacity, decimal dailyRate)
        {
            SuiteType = suiteType;
            Capacity = capacity;
            DailyRate = dailyRate;
        }

        public string SuiteType { get; set; }
        public int Capacity { get; set; }
        public decimal DailyRate { get; set; }
    }
}
