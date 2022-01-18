namespace Engine
{
    public struct Feedback
    {
        private readonly byte r_AmountOfV;
        private readonly byte r_AmountOfX;

        public Feedback(uint i_AmountOfV, uint i_AmountOfX)
        {
            r_AmountOfV = (byte)i_AmountOfV;
            r_AmountOfX = (byte)i_AmountOfX;
        }

        public byte AmountOfV
        {
            get
            { 
                return r_AmountOfV;
            }
        }

        public byte AmountOfX
        {
            get
            {
                return r_AmountOfX; 
            }
        }
    }
}
