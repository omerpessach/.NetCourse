namespace Engine
{
    public struct Feedback
    {
        private readonly byte m_AmountOfV;
        private readonly byte m_AmountOfX;

        public Feedback(uint i_AmountOfV, uint i_AmountOfX)
        {
            m_AmountOfV = (byte)i_AmountOfV;
            m_AmountOfX = (byte)i_AmountOfX;
        }

        public byte AmountOfV
        {
            get
            { 
                return m_AmountOfV;
            }
        }

        public byte AmountOfX
        {
            get
            {
                return m_AmountOfX; 
            }
        }
    }
}
