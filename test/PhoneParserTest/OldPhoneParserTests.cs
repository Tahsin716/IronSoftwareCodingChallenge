using PhoneParser.Contracts;
using PhoneParser.DI;

namespace PhoneParserTest
{
    public class OldPhoneParserTests
    {
        private readonly IOldPhoneParser _oldPhoneParser;
        public OldPhoneParserTests()
        {
            _oldPhoneParser = ServiceRegistration.GetService<IOldPhoneParser>();
        }

        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void OldPhonePad_ReturnsExpectedOutput(string input, string expected)
        {
            string result = _oldPhoneParser.OldPhonePad(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0#", " ")]
        [InlineData("1#", "&")]
        [InlineData("2#", "A")]
        [InlineData("3#", "D")]
        [InlineData("4#", "G")]
        [InlineData("5#", "J")]
        [InlineData("6#", "M")]
        [InlineData("7#", "P")]
        [InlineData("8#", "T")]
        [InlineData("9#", "W")]
        public void OldPhonePad_ReturnsFirstLetterOnSinglePress(string input, string expected)
        {
            string result = _oldPhoneParser.OldPhonePad(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("22#", "B")]
        [InlineData("33#", "E")]
        [InlineData("44#", "H")]
        [InlineData("55#", "K")]
        [InlineData("66#", "N")]
        [InlineData("77#", "Q")]
        [InlineData("88#", "U")]
        [InlineData("99#", "X")]
        public void OldPhonePad_ReturnsSecondLetterOnDoublePress(string input, string expected)
        {
            string result = _oldPhoneParser.OldPhonePad(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("22 2225#", "BCJ")]
        [InlineData("22 2225*#", "BC")]
        [InlineData("22 2225**#", "B")]
        [InlineData("22***2225#", "CJ")]
        [InlineData("***2225#", "CJ")]
        [InlineData("22 2225***#", "")]
        [InlineData("22 2225****#", "")]
        [InlineData("22*222*5*#", "")]
        [InlineData("***#", "")]
        public void OldPhonePad_HandlesBackspaceCorrectly(string input, string expected)
        {
            string result = _oldPhoneParser.OldPhonePad(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OldPhonePad_ReturnsEmptyOnEmptyInput()
        {
            string result = _oldPhoneParser.OldPhonePad("#");
            Assert.Equal("", result);
        }

        [Fact]
        public void OldPhonePad_IgnoresCharactersAfterHash()
        {
            string result = _oldPhoneParser.OldPhonePad("22#33445");
            Assert.Equal("B", result);
        }
    }
}