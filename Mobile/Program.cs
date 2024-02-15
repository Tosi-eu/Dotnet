using Models;


Console.WriteLine("Smartphone Nokia Tijolinho: ");
Nokia nokia = new("123", "1111111111", "Modelo 1", 32);
nokia.InstallApp("WhatsApp");
Smartphone.MakeCall();


Console.WriteLine("\n");

Console.WriteLine("iPhone de cria 15 PRO MAX:");
Iphone iphone = new("123", "22222222", "Modelo 2", 16);
iphone.InstallApp("Telegram");
Smartphone.ReceiveCall();