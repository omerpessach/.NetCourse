using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Board
    {
        private StringBuilder m_GameBuilder;
        private uint m_NumberOfGuesses;

        private uint NumberOfGuesses
        {
            get { return m_NumberOfGuesses; }
            set { m_NumberOfGuesses = value; }
        }

        public Board(uint i_NumberOfGuesses)
        {
            NumberOfGuesses = i_NumberOfGuesses;
        }

        public void PrintBoard()
        {
        }
    }
}
