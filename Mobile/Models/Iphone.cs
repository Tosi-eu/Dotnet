namespace Models
{
    public class Iphone(string number, string imei, string model, int memory) : Smartphone(number, imei, model, memory)
    {
        public override void InstallApp(string appName)
        {

            int code = appName.GetHashCode();

            if(code < 0) code *= -1;

            Console.WriteLine($"Installing app: {appName}\nApp version: {code}\n");
        }
    }
}