using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public delegate void GuessWasMadeEventHandler(int i_RowIndex, Color i_SelectedColor);

    public class GuessButton : Button
    {
        private readonly PickAColorForm r_FormPickAColor;
        private readonly int            r_RowIndex;

        public GuessButton(int i_RowIndex, List<Color> i_Colors)
        {
            r_FormPickAColor = new PickAColorForm(i_Colors);
            r_RowIndex = i_RowIndex;

            r_FormPickAColor.ColorSelected += formPickAColor_ColorSelected;
        }

        public event GuessWasMadeEventHandler GuessWasMade;

        public ICollection<Color> ColorsToDisable
        {
            set
            {
                r_FormPickAColor.ColorsToDisable = value;
            }
        }

        protected override void   OnClick(EventArgs e)
        {
            r_FormPickAColor.ShowDialog();
        }

        private void              formPickAColor_ColorSelected(Color i_SelectedColor)
        {
            BackColor = i_SelectedColor;
            GuessWasMade?.Invoke(r_RowIndex, i_SelectedColor);
        }
    }
}
