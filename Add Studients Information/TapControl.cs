using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revision2
{
    public partial class TapControl : Form
    {
        public TapControl()
        {
            InitializeComponent();
        }

        private void btnAddStudients_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

            ListViewItem item =new ListViewItem(txtName.Text.Trim());

            if (rbMale.Checked)
                item.ImageIndex = 1;
            else
                item.ImageIndex = 4;

            item.SubItems.Add(txtcollage.Text.Trim());
            item.SubItems.Add(txtAge.Text.Trim());

            listView1.Items.Add(item);

            txtName.Clear();
            txtcollage.Clear();
            txtAge.Clear();



        }

        private void btnShowStudientsList_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(0); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider1.SetError(txtName, "Enter Your Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, "");
            }
        }
    }
}
