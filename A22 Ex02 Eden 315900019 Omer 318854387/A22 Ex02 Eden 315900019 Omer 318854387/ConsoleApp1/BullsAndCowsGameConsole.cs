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
        private const char k_CorrectLocationSign = 'V';
        private const char k_AlmostCorrectLocationSign = 'X';
        private const char k_HiddenSign = '#';
        private const string k_TypeGuessStatement = "Please type your next guess <{0}> or 'Q' to quit";
        private const string k_PrePrintBoardStatusStatement = "current board status:";
        private const string k_AskForRestartStatement = "Would you like to start a new game? <Y/N>";
        private const string k_WinStatement = "You guessed after {0} steps!";
        private const string k_LostStatement = "No more guesses allowed. You Lost.";
        private const string k_NumberOfGuessesRequest = "Please enter number of guesses between {0} to {1}";
        private const string k_InValidInputNotALetter = "No more guesses allowed. You Lost."; // I should change the text
        private const string k_InValidInputNotANumber = "No more guesses allowed. You Lost.";
        private const string k_InValidInputNumberOutOfRange = "No more guesses allowed. You Lost.";
        private const string k_InValidInputLetterOutOfRange = "No more guesses allowed. You Lost.";
        private GameManger m_GameManager = new GameManger(0);
        private Board m_Board;

        private Board Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }


        public void StartNewGame()
        {
            uint guessesNumber = getGuessesNumberFromUser();

            Board = new Board(guessesNumber);
            guessesInteractionsWithTheUser();
        }

        private void checkIfAnswerIsCorrect(char[] i_Guesses)
        {
            m_GameManager.CreateRound(i_Guesses);
            Console.WriteLine("");
        }

        private void cleanScreen()
        {
            Screen.Clear();
        }

        private void closeConsole()
        {
            Environment.Exit(0);
        }

        private void guessesInteractionsWithTheUser()
        {
            char[] guessesInput = new char[k_SequenceLenght];

            for (int i = 0; i < k_SequenceLenght; i++)
            {
                guessesInput[i] = getUserGuess();
            }

            checkIfAnswerIsCorrect(guessesInput);
            Board.PrintBoard();
        }

        private char getUserGuess()
        {
            char userInput;
            eInputValidCheckResponse validCheckResponse;
            char[] computerSequence = { 'A', 'B' }; //m_GameManager.RandomSequenceForComparison;
            Console.WriteLine(string.Format(k_TypeGuessStatement, computerSequence.ToString()));
            userInput = Console.ReadKey().KeyChar;
            validCheckResponse = Validations.IsCharRepresnetscharInSpecRange(userInput, computerSequence);
            while (validCheckResponse != eInputValidCheckResponse.VALID)
            {
                switch (validCheckResponse)
                {
                    case eInputValidCheckResponse.QUIT:
                        {
                            closeConsole();
                            break;
                        }
                    case eInputValidCheckResponse.OUT_OF_RANGE:
                        {
                            Console.WriteLine(k_InValidInputLetterOutOfRange);
                            break;
                        }
                    case eInputValidCheckResponse.WRONG_FORMAT:
                        {
                            Console.WriteLine(k_InValidInputNotALetter);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                userInput = Console.ReadKey().KeyChar;
                validCheckResponse = Validations.IsCharRepresnetscharInSpecRange(userInput, computerSequence);
            }

            return userInput;
        }

        private uint getGuessesNumberFromUser()
        {
            string requestForNumberMsg = string.Format(k_NumberOfGuessesRequest, k_MinNumOfAttempts, k_MaxNumOfAttempts);
            StringBuilder requestForNumberOutput = new StringBuilder(requestForNumberMsg);
            StringBuilder notADigitMsg = new StringBuilder(k_InValidInputNotANumber);
            StringBuilder notInRangeMsg = new StringBuilder(k_InValidInputNumberOutOfRange);
            string userInput;
            uint userInputAsValidDigit;
            eInputValidCheckResponse validCheckResponse;

            notADigitMsg.AppendLine(requestForNumberMsg);
            notInRangeMsg.AppendLine(requestForNumberMsg);
            Console.WriteLine(requestForNumberOutput);
            userInput = Console.ReadLine();
            validCheckResponse = Validations.IsStringRepresnetsDigitInSpecRange(userInput, k_MinNumOfAttempts, k_MaxNumOfAttempts, out userInputAsValidDigit);
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
                validCheckResponse = Validations.IsStringRepresnetsDigitInSpecRange(userInput, k_MinNumOfAttempts, k_MaxNumOfAttempts, out userInputAsValidDigit);
            }

            return userInputAsValidDigit;
        }
    }
}
