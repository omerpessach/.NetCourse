using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsControlsAndDialogs
{
    public partial class FormsPresenter : Form
    {
        public FormsPresenter()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PopulateListOfForms();
        }

        Assembly m_Assembly = null;

        private void PopulateListOfForms()
        {
            m_Assembly = Assembly.GetExecutingAssembly();

            foreach (Type type in m_Assembly.GetTypes())
            {
                if(type.IsSubclassOf(typeof(Form))
                    && type.IsPublic)
                {
                    listBox1.Items.Add(type);
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Type type = listBox1.SelectedItem as Type;

                Form theFormIWantToSee =
                    m_Assembly.CreateInstance(type.FullName) as Form;

                theFormIWantToSee.Show();
            }
        }
    }
}