using System;
using System.Windows.Forms;

namespace MastermindUserInterface
{
    public partial class NewGameForm : Form
    {
        private const int k_MinNumberOfGuesses = 4;
        private const int k_MaxNumberOfGuesses = 10;
        private bool v_FormClosedPressingTheStartButton = false;
        private int m_NumberOfChances;

        public NewGameForm()
        {
            m_NumberOfChances = k_MinNumberOfGuesses;
            InitializeComponent();
            i_NumberOfChancesBotton.Text = string.Format(@"number of chances: {0}", m_NumberOfChances);
        }

        public int NumberOfChances
        {
            get { return m_NumberOfChances;  }
        }

        public bool FormClosedPressingTheStartButton
        {
            get { return v_FormClosedPressingTheStartButton; }
        }

        private void I_NumberOfChancesBotton_Click(object sender, EventArgs e)
        {
            if (m_NumberOfChances == k_MaxNumberOfGuesses)
            {
                m_NumberOfChances = k_MinNumberOfGuesses;
            }
            else
            {
                m_NumberOfChances++;
            }

            i_NumberOfChancesBotton.Text = string.Format(@"number of chances: {0}", m_NumberOfChances);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            v_FormClosedPressingTheStartButton = true;
            this.Close();
        }

        private void NewGameForm_Load(object sender, EventArgs e)
        {
        }
    }
}
