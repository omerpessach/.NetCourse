namespace UI
{
    public static class Validations
    {
        public static bool IsStringContainsLettersOnly(string i_StringToCheck)
        {
            bool isStringContainsLettersOnly = true;

            for (int i = 0; i < i_StringToCheck.Length && isStringContainsLettersOnly; i++)
            {
                isStringContainsLettersOnly = char.IsLetter(i_StringToCheck[i]);
            }

            return isStringContainsLettersOnly;
        }

        public static bool IsStringContainsSpecCharsOnly(string i_StringToCheck, string i_SpecChars)
        {
            bool isStringContainsSpecCharsOnly = true;

            for (int i = 0; i < i_StringToCheck.Length && isStringContainsSpecCharsOnly; i++)
            {
                isStringContainsSpecCharsOnly = i_SpecChars.Contains(i_StringToCheck[i].ToString());
            }

            return isStringContainsSpecCharsOnly;
        }
    }
}
