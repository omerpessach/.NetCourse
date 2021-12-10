using BL;
using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;

namespace ConsoleApp1
{
    public enum eInputValidCheckResponse
    {
        Valid,
        OutOfRange,
        WrongFormat,
        InputNotInTheRightLength,
        Quit,
    }

    public class BullsAndCowsGameConsole
    {
        private const uint k_MinNumOfAttempts = 4;
        private const uint k_MaxNumOfAttempts = 10;
        private const ushort k_SequenceLength = 4;
        private const string k_QuitSign = "Q";
        private const string k_YesSign = "Y";
        private const string k_NoSign = "N";
        private const string k_TypeGuessStatement = "Please type your next guess <{0}> or 'Q' to quit";
        private const string k_AskForRestartStatement = "Would you like to start a new game? <{0}/{1}>";
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

        // What about private props? is it fine?
        private Board Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }

        public void StartNewGame()
        {
            Screen.Clear();
            m_guessesNumber = getGuessesNumberFromUser();
            m_GameManager = new GameManger(m_guessesNumber, k_SequenceLength);
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
            bool hasTheUserWon = false;

            for (int i = 0; i < m_guessesNumber && !hasTheUserWon; i++)
            {
                char[] guessesInput = getUserGuess().ToCharArray();

                Round newRound = m_GameManager.CreateRound(guessesInput);
                Board.AddRound(newRound);
                hasTheUserWon = this.hasTheUserWon(newRound.CurrentFeedback);
                Board.PrintBoard();
            }

            endInteractionWithTheUser(hasTheUserWon);
        }

        private void endInteractionWithTheUser(bool hasTheUserWon)
        {
            StringBuilder endGameOutput = new StringBuilder();
            string userResponse;

            if (hasTheUserWon)
            {
                endGameOutput.AppendLine(string.Format(k_WinStatement, m_GameManager.CurrentRound));
            }
            else
            {
                endGameOutput.AppendLine(k_LostStatement);
            }

            endGameOutput.AppendLine(string.Format(k_AskForRestartStatement, k_YesSign, k_NoSign));

            do
            {
                Console.WriteLine(endGameOutput);
                userResponse = Console.ReadLine();
            } while (userResponse != k_YesSign && userResponse != k_NoSign);

            if (userResponse == k_YesSign)
            {
                StartNewGame();
            }
            else
            {
                // Should I close the console or just print goodbye?
                closeConsole();
            }
        }

        private string getUserGuess()
        {
            string userInput;
            eInputValidCheckResponse validCheckResponse;
            string[] guessingOptionsEnumNames = Enum.GetNames(typeof(eGuessingOption));
            string guessingOptions = string.Concat(guessingOptionsEnumNames);
            string guessingOptionsConsoleFormat = string.Join(" ", guessingOptionsEnumNames);

            Console.WriteLine(string.Format(k_TypeGuessStatement, guessingOptionsConsoleFormat));
            userInput = Console.ReadLine();
            validCheckResponse = isStringContainsLetterAndSpecCharsOnly(userInput, guessingOptions);
            while (validCheckResponse != eInputValidCheckResponse.Valid)
            {
                switch (validCheckResponse)
                {
                    case eInputValidCheckResponse.Quit:
                        {
                            closeConsole();
                            break;
                        }
                    case eInputValidCheckResponse.InputNotInTheRightLength:
                        {
                            Console.WriteLine(k_InValidInputLNotEnoughChars);
                            break;
                        }
                    case eInputValidCheckResponse.OutOfRange:
                        {
                            Console.WriteLine(k_InValidInputLettersOutOfRange);
                            break;
                        }
                    case eInputValidCheckResponse.WrongFormat:
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
                validCheckResponse = isStringContainsLetterAndSpecCharsOnly(userInput, guessingOptions);
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
            while (validCheckResponse != eInputValidCheckResponse.Valid)
            {
                switch (validCheckResponse)
                {
                    case eInputValidCheckResponse.WrongFormat:
                        {
                            Console.WriteLine(notADigitMsg);
                            break;
                        }
                    case eInputValidCheckResponse.OutOfRange:
                        {
                            Console.WriteLine(notInRangeMsg);
                            break;
                        }
                    case eInputValidCheckResponse.Quit:
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

        private bool hasTheUserWon(Feedback i_Feedback)
        {
            return (i_Feedback.AmountOfV == k_SequenceLength);
        }

        private eInputValidCheckResponse isStringRepresnetsDigitInSpecRange(string i_stringToCheck, uint i_MinValue, uint i_MaxValue, out uint o_result)
        {
            eInputValidCheckResponse response = eInputValidCheckResponse.Valid;
            uint inputNumber;

            o_result = default;
            if (i_stringToCheck == k_QuitSign)
            {
                response = eInputValidCheckResponse.Quit;
            }
            else if (!uint.TryParse(i_stringToCheck, out inputNumber))
            {
                response = eInputValidCheckResponse.WrongFormat;
            }
            else if (inputNumber < i_MinValue || inputNumber > i_MaxValue)
            {
                response = eInputValidCheckResponse.OutOfRange;
            }
            else
            {
                o_result = inputNumber;
            }

            return response;
        }

        private eInputValidCheckResponse isStringContainsLetterAndSpecCharsOnly(string i_StringToCheck, string i_SpecChars)
        {
            eInputValidCheckResponse response = eInputValidCheckResponse.Valid;

            if (i_StringToCheck == k_QuitSign)
            {
                response = eInputValidCheckResponse.Quit;
            }
            else if (i_StringToCheck.Length != k_SequenceLength)
            {
                response = eInputValidCheckResponse.InputNotInTheRightLength;
            }
            else if (!Validations.IsStringContainsLettersOnly(i_StringToCheck))
            {
                response = eInputValidCheckResponse.WrongFormat;
            }
            else if (!Validations.IsStringContainsSpecCharsOnly(i_StringToCheck, i_SpecChars))
            {
                response = eInputValidCheckResponse.OutOfRange;
            }

            return response;
        }
    }
}
