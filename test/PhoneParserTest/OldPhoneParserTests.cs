using PhoneParser;

namespace PhoneParserTest
{
    public class OldPhoneParserTests
    {
        [Theory]
        [InlineData("33#", "E")]  
        [InlineData("227*#", "BP")]  
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURIONG")]
        public void OldPhonePad_ReturnsExpectedOutput(string input, string expected)
        {
            string result = OldPhoneParser.OldPhonePad(input);
            Assert.Equal(expected, result);
        }
    }
}