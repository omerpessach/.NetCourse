using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Validations
    {
        public static eInputValidCheckResponse IsCharRepresnetscharInSpecRange(char i_CharToCheck, char[] i_Range)
        {
            eInputValidCheckResponse response = eInputValidCheckResponse.VALID;

            if (!Char.IsLetter(i_CharToCheck))
            {
                response = eInputValidCheckResponse.WRONG_FORMAT;
            }
            else if (i_CharToCheck == 'Q')
            {
                response = eInputValidCheckResponse.QUIT;
            }
            else if (!i_Range.ToString().Contains(i_CharToCheck.ToString()))
            {
                response = eInputValidCheckResponse.OUT_OF_RANGE;
            }

            return response;
        }

        public static eInputValidCheckResponse IsStringRepresnetsDigitInSpecRange(string i_stringToCheck, uint i_MinValue, uint i_MaxValue, out uint o_result)
        {
            eInputValidCheckResponse response = eInputValidCheckResponse.VALID;
            uint inputNumber;

            if (i_stringToCheck == "Q")
            {
                response = eInputValidCheckResponse.QUIT;
            }
            else if (!uint.TryParse(i_stringToCheck, out inputNumber))
            {
                response = eInputValidCheckResponse.WRONG_FORMAT;
            }
            else if (inputNumber < i_MinValue || inputNumber > i_MaxValue)
            {
                response = eInputValidCheckResponse.OUT_OF_RANGE;
            }
            else
            {
                o_result = inputNumber;
            }

            o_result = default;
            return response;
        }

    }
    public enum eInputValidCheckResponse
    {
        VALID,
        OUT_OF_RANGE,
        WRONG_FORMAT,
        QUIT,
    }
}
