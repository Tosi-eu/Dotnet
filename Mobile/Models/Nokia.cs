using System.Text;
namespace Models
{
    public class Nokia(string number, string imei, string model, int memory) : Smartphone(number, imei, model, memory)
    {
        public override void InstallApp(string appName)
        {
            StringBuilder asciiSequence = new();

            foreach (char character in appName)
            {
                int asciiCode = (int)character;
                asciiSequence.Append(asciiCode.ToString() + " ");
            }

            int code = appName.GetHashCode();

            if(code < 0) code *= -1;

            Console.WriteLine($"Installing app: {appName}\nApp version: {code}\nCode: {asciiSequence.ToString().Trim()}");
        }
    }
}