using PhoneParser.Contracts;
using PhoneParser.DI;

namespace PhoneParserTest
{
    public class OldPhoneParserTests
    {
        private readonly IOldPhoneParser OldPhoneParser;
        public OldPhoneParserTests()
        {
            OldPhoneParser = ServiceRegistration.GetService<IOldPhoneParser>();
        }

        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void OldPhonePad_ReturnsExpectedOutput(string input, string expected)
        {
            string result = OldPhoneParser.OldPhonePad(input);
            Assert.Equal(expected, result);
        }
    }
}