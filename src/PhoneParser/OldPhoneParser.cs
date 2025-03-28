using System.Text;

namespace PhoneParser
{
    public static class OldPhoneParser
    {
        private readonly static Dictionary<char, string> KeypadMap = new Dictionary<char, string>
        {
            {'1', "&'(" },
            {'2', "ABC" },
            {'3', "DEF" },
            {'4', "GHI" },
            {'5', "JKL" },
            {'6', "MNO" },
            {'7', "PQRS" },
            {'8', "TUV" },
            {'9', "WXYZ" },
            {'0', " " }
        };
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var result = new StringBuilder();
            var inputArray = input.ToCharArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                var currentChar = inputArray[i];
                var count = 1;

                if (currentChar == '#') return result.ToString();

                if (currentChar == '*' && result.Length > 0)
                {
                    result.Remove(result.Length - 1, 1);
                    continue;
                }

                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[j] == currentChar)
                    {
                        count++;
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                result.Append(GetPhoneChar(currentChar, count));
            }

            return result.ToString();
        }

        private static string GetPhoneChar(char currentChar, int count)
        {
            if (!KeypadMap.ContainsKey(currentChar)) return string.Empty;

            var letters = KeypadMap[currentChar];
            int index = (count - 1) % letters.Length;
            return letters[index].ToString();
        }
    }
}
