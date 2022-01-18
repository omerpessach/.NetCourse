using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public delegate void ColorSelectedEventHandler(Color i_SelectedColor);

    public partial class PickAColorForm : Form
    {
        private const int k_ColorButtonWidth = 60;
        private const int k_ColorButtonHeight = 60;
        private const int k_SpaceBetweenButtons = 10;
        private readonly Size r_ButtonColorSize = new Size(k_ColorButtonWidth, k_ColorButtonHeight);

        public PickAColorForm(List<Color> i_ColorOptions)
        {
            InitializeComponent();
            initColorOptions(i_ColorOptions);
        }

        public event ColorSelectedEventHandler ColorSelected;

        private void initColorOptions(List<Color> i_ColorOptions)
        {
            Point relevantColorLocation = new Point(k_SpaceBetweenButtons, k_SpaceBetweenButtons);
            int maxLeft = k_SpaceBetweenButtons + (i_ColorOptions.Count / 2 * (k_ColorButtonWidth + k_SpaceBetweenButtons));

            foreach (Color color in i_ColorOptions)
            {
                Button newButton = new Button();

                newButton.Size = r_ButtonColorSize;
                newButton.BackColor = color;
                newButton.Location = relevantColorLocation;
                newButton.Click += buttonColor_Click;
                Controls.Add(newButton);
                relevantColorLocation.X += k_SpaceBetweenButtons + k_ColorButtonWidth;
                if (relevantColorLocation.X == maxLeft)
                {
                    relevantColorLocation.Y += k_SpaceBetweenButtons + k_ColorButtonHeight;
                    relevantColorLocation.X = k_SpaceBetweenButtons;
                }
            }

            Size = new Size(maxLeft, relevantColorLocation.Y + SystemInformation.CaptionHeight);
        }

        private void buttonColor_Click(object i_Sender, EventArgs i_EventArgs)
        {
            ColorSelected?.Invoke((i_Sender as Button).BackColor);
            Close();
        }
    }
}
