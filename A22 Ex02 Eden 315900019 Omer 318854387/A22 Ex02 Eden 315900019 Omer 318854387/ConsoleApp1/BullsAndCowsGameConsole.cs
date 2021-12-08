using BL;
using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;

namespace ConsoleApp1
{
    public class BullsAndCowsGameConsole
    {
        private const uint k_MinNumOfAttempts = 4;
        private const uint k_MaxNumOfAttempts = 10;
        private const ushort k_SequenceLenght = 4;
        private const string k_QuitSign = "Q";
        private const char k_YesSign = 'Y';
        private const char k_NoSign = 'N';
        private const string k_TypeGuessStatement = "Please type your next guess <{0}> or 'Q' to quit";
        private const string k_AskForRestartStatement = "Would you like to start a new game? <Y/N>";
        private const string k_WinStatement = "You guessed after {0} steps!";
        private const string k_LostStatement = "No more guesses allowed. You Lost.";
        private const string k_NumberOfGuessesRequest = "Please enter number of guesses between {0} to {1}";
        private const string k_InValidInputNotALetters = "Invalid format, letters only";
        private const string k_InValidInputNotANumber = "Invalid format, native number only";
        private const string k_InValidInputNumberOutOfRange = "Number out of range";
        private const string k_InValidInputLettersOutOfRange = "Invalid, letters out of range";
        private const string k_InValidInputLNotEnoughChars = "Invalid, type 4 chars only";
        private const string k_QuitMsg = "Goodbye";
        private GameManger m_GameManager;
        private Board m_Board;
        private uint m_guessesNumber;

        private Board Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }

        public void StartNewGame()
        {
            m_guessesNumber = getGuessesNumberFromUser();

            m_GameManager = new GameManger(m_guessesNumber);
            Board = new Board(m_guessesNumber);
            Board.PrintBoard();
            startGuessesInteractionsWithTheUser();
        }

        private void closeConsole()
        {
            Console.WriteLine(k_QuitMsg);
            Environment.Exit(0);
        }

        private void startGuessesInteractionsWithTheUser()
        {
            for (int i = 0; i < m_guessesNumber; i++)
            {
                char[] guessesInput = getUserGuess().ToCharArray();

                Round newRound = m_GameManager.CreateRound(guessesInput);
                Board.AddRound(newRound);
                Board.PrintBoard();
            }
        }

        private string getUserGuess()
        {
            string userInput;
            eInputValidCheckResponse validCheckResponse;
            char[] computerSequence = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' }; //m_GameManager.RandomSequenceForComparison;
            StringBuilder sb = new StringBuilder();
            sb.Append(computerSequence);

            Console.WriteLine(string.Format(k_TypeGuessStatement, sb));
            userInput = Console.ReadLine();
            validCheckResponse = isStringContainsLetterAndSpecCharsOnly(userInput, computerSequence);
            while (validCheckResponse != eInputValidCheckResponse.VALID)
            {
                switch (validCheckResponse)
                {
                    case eInputValidCheckResponse.QUIT:
                        {
                            closeConsole();
                            break;
                        }
                    case eInputValidCheckResponse.NOTENOUGHCHARS:
                        {
                            Console.WriteLine(k_InValidInputLNotEnoughChars);
                            break;
                        }
                    case eInputValidCheckResponse.OUT_OF_RANGE:
                        {
                            Console.WriteLine(k_InValidInputLettersOutOfRange);
                            break;
                        }
                    case eInputValidCheckResponse.WRONG_FORMAT:
                        {
                            Console.WriteLine(k_InValidInputNotALetters);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                userInput = Console.ReadLine();
                validCheckResponse = isStringContainsLetterAndSpecCharsOnly(userInput, computerSequence);
            }

            return userInput;
        }

        private uint getGuessesNumberFromUser()
        {
            string requestForNumberMsg = string.Format(k_NumberOfGuessesRequest, k_MinNumOfAttempts, k_MaxNumOfAttempts);
            string userInput;
            uint userInputAsValidDigit;
            eInputValidCheckResponse validCheckResponse;
            StringBuilder requestForNumberOutput = new StringBuilder(requestForNumberMsg);
            StringBuilder notADigitMsg = new StringBuilder(k_InValidInputNotANumber);
            StringBuilder notInRangeMsg = new StringBuilder(k_InValidInputNumberOutOfRange);

            notADigitMsg.AppendLine(requestForNumberMsg);
            notInRangeMsg.AppendLine(requestForNumberMsg);
            Console.WriteLine(requestForNumberOutput);
            userInput = Console.ReadLine();
            validCheckResponse = isStringRepresnetsDigitInSpecRange(userInput, k_MinNumOfAttempts, k_MaxNumOfAttempts, out userInputAsValidDigit);
            while (validCheckResponse != eInputValidCheckResponse.VALID)
            {
                switch (validCheckResponse)
                {
                    case eInputValidCheckResponse.WRONG_FORMAT:
                        {
                            Console.WriteLine(notADigitMsg);
                            break;
                        }
                    case eInputValidCheckResponse.OUT_OF_RANGE:
                        {
                            Console.WriteLine(notInRangeMsg);
                            break;
                        }
                    case eInputValidCheckResponse.QUIT:
                        {
                            closeConsole();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                userInput = Console.ReadLine();
                validCheckResponse = isStringRepresnetsDigitInSpecRange(userInput, k_MinNumOfAttempts, k_MaxNumOfAttempts, out userInputAsValidDigit);
            }

            return userInputAsValidDigit;
        }

        private eInputValidCheckResponse isStringRepresnetsDigitInSpecRange(string i_stringToCheck, uint i_MinValue, uint i_MaxValue, out uint o_result)
        {
            eInputValidCheckResponse response = eInputValidCheckResponse.VALID;
            uint inputNumber;
            o_result = default;

            if (i_stringToCheck == k_QuitSign)
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

            return response;
        }

        private eInputValidCheckResponse isStringContainsLetterAndSpecCharsOnly(string i_StringToCheck, char[] i_SpecChars)
        {
            eInputValidCheckResponse response = eInputValidCheckResponse.VALID;

            if (i_StringToCheck == k_QuitSign)
            {
                response = eInputValidCheckResponse.QUIT;
            }
            else if (i_StringToCheck.Length != k_SequenceLenght)
            {
                response = eInputValidCheckResponse.NOTENOUGHCHARS;
            }
            else if (!Validations.IsStringContainsLettersOnly(i_StringToCheck))
            {
                response = eInputValidCheckResponse.WRONG_FORMAT;
            }
            else if (!Validations.IsStringContainsSpecCharsOnly(i_StringToCheck, i_SpecChars))
            {
                response = eInputValidCheckResponse.OUT_OF_RANGE;
            }

            return response;
        }
    }

    public enum eInputValidCheckResponse
    {
        VALID,
        OUT_OF_RANGE,
        WRONG_FORMAT,
        NOTENOUGHCHARS,
        QUIT,
    }
}
