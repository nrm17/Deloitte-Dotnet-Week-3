using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIIS_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtNum1.Text);
            int n1 = int.Parse(txtNum2.Text);

            try
            {
                ServiceReference1.CalculatorClient cc = new ServiceReference1.CalculatorClient(); // interface cant create object soooo Google

                var add = cc.Add(n, n1);
                var sub = cc.Sub(n, n1);

                MessageBox.Show("Addition : " + add);
                MessageBox.Show("Subtraction : " + sub);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtNum1.Text);
            int n1 = int.Parse(txtNum2.Text);

            try
            {
                ServiceReference2.CalculatorClient cc = new ServiceReference2.CalculatorClient(); // interface cant create object soooo Google

                var add = cc.Add(n, n1);
                var sub = cc.Sub(n, n1);

                MessageBox.Show("Addition : " + add);
                MessageBox.Show("Subtraction : " + sub);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
