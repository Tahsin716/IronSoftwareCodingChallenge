using PhoneParser.Contracts;
using PhoneParser.DI;

class Program
{
    static void Main()
    {
        var PhoneParser = ServiceRegistration.GetService<IOldPhoneParser>();
        var result = PhoneParser.OldPhonePad("4433555 555666#");
        Console.WriteLine(result);
    }
}