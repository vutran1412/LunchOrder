using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Vu Tran
// A basic lunch order form that saves each order item
// to display in a listBox

namespace Lunch_Order
{
    public partial class frmLunchOrderForm : Form
    {
        // Initiallizes all the GUI components
        public frmLunchOrderForm()
        {
            InitializeComponent();
        }
        
        // Constants
        decimal SubTotal;
        decimal Tax = 0.0775m;
        decimal OrderTotal;

        // Depending on what the user selects the checkboxes will change
        private void rbHamburger_CheckedChanged(object sender, EventArgs e)
        {
            gbxAddOn.Text = "Add-on items($.75/each)";
            cb1.Text = "Lettuce, tomato, and onions";
            cb2.Text = "Ketchup, mustard, and mayo";
            cb3.Text = "French fries";

            UncheckAll(this);

            lblSubTotal.Text = "";
            lblTax.Text = "";
            lblOrderTotal.Text = "";
        }

        private void rbPizza_CheckedChanged(object sender, EventArgs e)
        {
            gbxAddOn.Text = "Add-on items ($.50/each)";
            cb1.Text = "Pepperoni";
            cb2.Text = "Sausage";
            cb3.Text = "Olives";

            UncheckAll(this);

            lblSubTotal.Text = "";
            lblTax.Text = "";
            lblOrderTotal.Text = "";
        }

        private void rbSalad_CheckedChanged(object sender, EventArgs e)
        {
            gbxAddOn.Text = "Add-on items ($.25/each)";
            cb1.Text = "Croutons";
            cb2.Text = "Bacon bits";
            cb3.Text = "Bread sticks";

            UncheckAll(this);

            lblSubTotal.Text = "";
            lblTax.Text = "";
            lblOrderTotal.Text = "";
        }

        // Method to unchek all checked checkboxes 
        // Learned about this on
        // https://social.msdn.microsoft.com/Forums/vstudio/en-US/61a33ecd-98f2-4ad7-8077-7e8aaeb0b0b3/uncheck-all-checkboxes?forum=csharpgeneral
        private void UncheckAll(Control control)
        {
            CheckBox checkBox = control as CheckBox;
            if (checkBox == null)
            {
                foreach (Control child in control.Controls)
                {
                    UncheckAll(child);
                }
            }
            else
            {
                checkBox.Checked = false;
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            UncheckAll(this);

            lblSubTotal.Text = "";
            lblTax.Text = "";
            lblOrderTotal.Text = "";
        }

        // This method calculates the prices and saves the data in the listbox
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // initiallizes the number of add-ons
            decimal addOns = 0m;
            // Conditionals to count the number of add-ons for the item
            if (cb1.Checked)
            {
                addOns++;
            }
            if (cb2.Checked)
            {
                addOns++;
            }
            if (cb3.Checked)
            {
                addOns++;
            }
            
            // Calculates the Burger price
            if (rbHamburger.Checked)
            {
                decimal hamburgerPrice = 6.95m;
                SubTotal = hamburgerPrice + (addOns * .75m);
                Tax = SubTotal * .0775m;
                OrderTotal = SubTotal + Tax;

                lblSubTotal.Text = SubTotal.ToString("c");
                lblTax.Text = Tax.ToString("c");
                lblOrderTotal.Text = OrderTotal.ToString("c");
                
                // Adds item to ListBox
                lstItems.Items.Add("Hamburger " + "Price: " + OrderTotal.ToString("c"));
            }
            // Calculates the pizza price
            else if (rbPizza.Checked)
            {
                decimal pizzaPrice = 5.95m;
                SubTotal = pizzaPrice + (addOns * .50m);
                Tax = SubTotal * .0775m;
                OrderTotal = SubTotal + Tax;

                lblSubTotal.Text = SubTotal.ToString("c");
                lblTax.Text = Tax.ToString("c");
                lblOrderTotal.Text = OrderTotal.ToString("c");

                lstItems.Items.Add("Pizza " + "Price: " + OrderTotal.ToString("c"));

            }
            // Calculate the salad price
            else
            {
                decimal saladPrice = 4.95m;
                SubTotal = saladPrice + (addOns * .25m);
                Tax = SubTotal * .0775m;
                OrderTotal = SubTotal + Tax;

                lblSubTotal.Text = SubTotal.ToString("c");
                lblTax.Text = Tax.ToString("c");
                lblOrderTotal.Text = OrderTotal.ToString("c");

                lstItems.Items.Add("Salad " + "Price: " + OrderTotal.ToString("c"));

            }
        }

        // Exit the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Deletes the item in the ListBox
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            while (lstItems.SelectedItems.Count != 0)
            {
                lstItems.Items.Remove(lstItems.SelectedItems[0]);
            }
        }
    }
}
