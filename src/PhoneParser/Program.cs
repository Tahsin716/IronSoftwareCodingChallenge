using PhoneParser.Contracts;
using PhoneParser.DI;

namespace PhoneParser
{
    public class Program
    {
        static void Main()
        {
            var oldPhoneParser = ServiceRegistration.GetService<IOldPhoneParser>();
            var result = oldPhoneParser.OldPhonePad("4433555 555666#");
            Console.WriteLine(result);
        }
    }
}
