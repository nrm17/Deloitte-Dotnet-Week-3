using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int card = int.Parse(txtCard.Text);
            string cvv = txtCvv.Text;
            decimal amt = decimal.Parse(txtAmt.Text);

            try
            {
                ServiceReference2.CardClient cc = new ServiceReference2.CardClient();

                var c = cc.Authenticate(card, cvv);
                if(c)
                {
                    MessageBox.Show("Card details are correct");
                }


                var d = cc.DateCheck(card);
                if (d)
                {
                    MessageBox.Show("Your card is valid ");
                }
                else MessageBox.Show("Your card has expired");

                var f = cc.Trans(card, amt);

                if( c && d)
                {
                   
                    MessageBox.Show("Your balance is : " + f);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
