using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class GameManager
    {
        private string charsBank;
        private string numberOfChars;

        public GameManager(int numberOfChars, string _charsBank)
        {
        }

        public CorrectAnswerResponse CheckIfCorrectAnswer()
        {
            //Logic 
            return new CorrectAnswerResponse(0, 0);
        }

        public void GenerateRandomChars(byte amountOfChars)
        {
        }
    }

    public struct CorrectAnswerResponse
    {
        byte V { get; set; }
        byte X { get; set; }

        public CorrectAnswerResponse(byte v, byte x)
        {
            V = v;
            X = x;
        }
    }
}
