using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class BoardForm : Form
    {
        public BoardForm(List<Color> i_ColorOptions)
        {
            InitializeComponent();
            PickAColorForm d = new PickAColorForm(i_ColorOptions);
            d.ShowDialog();
        }
    }
}
