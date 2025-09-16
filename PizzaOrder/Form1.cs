using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void UpdateSize()
        {
            GetTotalPrice();
            if (rbSmall.Checked)
            {
                lblSize1.Text = "Small";
                return;
            }

            if(rbMedium.Checked)
            {
                lblSize1.Text = "Medium";
                return;
            }

            if(rbLarge.Checked)
            {
                lblSize1.Text = "Large";
                return;
            }
        }


        void UpdateCrustType()
        {
            GetTotalPrice();
            if (rbThinCrust.Checked)
            {
                lblCrustType1.Text = "Thin Crust";
                return;
            }

            if(rbThinkCrust.Checked)
            {
                lblCrustType1.Text = "Think Crust";
                return;
            }
        }

        void UpdateToppings()
        {

            GetTotalPrice();
            String Toppings = "";

            if(chkExteraCheese.Checked)
            {
                Toppings = "Extera Cheese";
            }

            if(chkMachroom.Checked)
            {
                Toppings += ", Machroom";
            }

            if(chkTomatoes.Checked)
            {
                Toppings += ", Tomatoes";
            }

            if(chkOnion.Checked)
            {
                Toppings += ", Onions";
            }

            if(chkOlives.Checked)
            {
                Toppings += "\n, Olives";
            }

            if(chkGreenPapper.Checked)
            {
                Toppings += ", GreenPapper";
            }

            if(Toppings.StartsWith(","))
            {
                Toppings = Toppings.Substring(1, Toppings.Length - 1);
            }

            if(Toppings=="")
            {
                lblToppings1.Text = "No Thing";
            }

            lblToppings1.Text = Toppings;
        }

        void UpdatWhereToEat()
        {
            if (rbEatIn.Checked)
            {
                lblWhereToEat1.Text = "Eat In";
                return;
            }

            if(rbEatOut.Checked)
            {
                lblWhereToEat1.Text = "Eat Out";
                return;
            }
        }

        float GetSizePrice()
        {
            if(rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }
            if (rbMedium.Checked)
            {
                return Convert.ToSingle(rbMedium.Tag);
            }
            else
                return Convert.ToSingle(rbLarge.Tag);
        }

        float GetCrustTypePrice()
        {
            if (rbThinCrust.Checked)
            {
                return Convert.ToSingle(rbThinCrust.Tag);

            }
            else
                return Convert.ToSingle(rbThinkCrust.Tag);
        }

       
        float GetToppingsPrice()
        {
            float Toppings = 0;

            if(chkExteraCheese.Checked)
            {
                Toppings += Convert.ToSingle(chkExteraCheese.Tag);
            }

            if (chkMachroom.Checked)
            {
                Toppings += Convert.ToSingle(chkMachroom.Tag);
            }

            if (chkTomatoes.Checked)
            {
                Toppings += Convert.ToSingle(chkTomatoes.Tag);
            }

            if (chkOnion.Checked)
            {
                Toppings += Convert.ToSingle(chkOnion.Tag);
            }

            if (chkOlives.Checked)
            {
                Toppings += Convert.ToSingle(chkOlives.Tag);
            }

            if (chkGreenPapper.Checked)
            {
                Toppings += Convert.ToSingle(chkGreenPapper.Tag);
            }

            return Toppings;
        }

        float UpdateTotalPrice()
        {
            return GetCrustTypePrice() + GetSizePrice() + GetToppingsPrice();
        }

        void GetTotalPrice()
        {
            lblNumber.Text = "$" + UpdateTotalPrice().ToString();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void chkExteraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMachroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPapper_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdatWhereToEat();
        }

        private void rbEatOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdatWhereToEat();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Order Sure?","Confirm",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question)==DialogResult.OK)
            {
                MessageBox.Show("Order Success", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                gbSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
                btnOrderPizza.Enabled = false;
            }

            else

            MessageBox.Show("Tray Again", "Update", 
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        void ResetForm()
        {
            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            btnOrderPizza.Enabled = true;

            rbMedium.Checked = true;

            rbThinCrust.Checked = true;

            chkTomatoes.Checked = false;
            chkExteraCheese.Checked = false;
            chkGreenPapper.Checked = false;
            chkOlives.Checked = false;
            chkOnion.Checked = false;
            chkMachroom.Checked = false;

            rbEatIn.Checked = true;

            lblToppings.Text = " No Toppings";


        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrustType();
            UpdatWhereToEat();
            UpdateTotalPrice();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
