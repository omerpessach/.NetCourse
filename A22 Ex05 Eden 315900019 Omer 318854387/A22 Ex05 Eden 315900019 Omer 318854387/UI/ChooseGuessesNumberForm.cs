using System;
using System.Windows.Forms;

namespace UI
{
    public partial class ChooseGuessesNumberForm : Form
    {
        private const uint   k_MinGuessesNumber = 4;
        private const uint   k_MaxGuessesNumber = 10;
        private const string k_GuessesNumberMsg = "Number of chances: {0}";
        private uint         m_GuessesNumber = k_MinGuessesNumber;

        public ChooseGuessesNumberForm()
        {
            InitializeComponent();
            buttonGuessesNumber.Text = string.Format(k_GuessesNumberMsg, m_GuessesNumber);
        }

        public uint  GuessesNumber
        {
            get { return m_GuessesNumber; }
        }

        private void buttonGuessesNumber_Click(object sender, EventArgs e)
        {
            if (m_GuessesNumber == k_MaxGuessesNumber)
            {
                m_GuessesNumber = k_MinGuessesNumber;
            }
            else
            {
                m_GuessesNumber++;
            }

            buttonGuessesNumber.Text = string.Format(k_GuessesNumberMsg, m_GuessesNumber);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }

        private void ChooseGuessesNumberForm_Load(object sender, EventArgs e)
        {

        }
    }
}
