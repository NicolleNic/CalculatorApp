using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        private bool opPress;
        private double saved = 0;
        private string op = string.Empty;
        private double memory = 0;

        public Calculator()
        {
            InitializeComponent();

            btnMR.Enabled=false;
            btnMC.Enabled = false;
            
        }

        private void numbers_Click(object sender, EventArgs e)
        {
            Button btn=sender as Button;
            if (tbResult.Text=="0" ||opPress==true)
            {
                tbResult.Text = btn.Text.ToString();
                opPress = false;
            }
            else
            {
                tbResult.Text += btn.Text.ToString();
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (tbResult.Text.Contains(".")) return;
            else tbResult.Text += ".";
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            double v = double.Parse(tbResult.Text);
            v = -v;
            tbResult.Text = v.ToString();
        }

        private void operator_Click(object sender, EventArgs e)
        {
            opPress = true;
            saved = double.Parse(tbResult.Text);

            Button btn = sender as Button;
            op = btn.Text.ToString();

            tbExp.Text += tbResult.Text + " " + op;

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double v = double.Parse(tbResult.Text);
            switch (op)
            {
                case "+":
                    tbResult.Text = (saved + v).ToString();
                    break;
                case "-":
                    tbResult.Text = (saved - v).ToString();
                    break;
                case "*":
                    tbResult.Text = (saved * v).ToString();
                    break;
                case "/":
                    tbResult.Text = (saved / v).ToString();
                    break;
            }
            tbExp.Text = saved + " " + op + " " + v + "=";
        }

        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            tbExp.Text = "√(" + tbResult.Text + ")";
            tbResult.Text = (Math.Sqrt(double.Parse(tbResult.Text))).ToString();
        }

        private void btnClearEverything_Click(object sender, EventArgs e)
        {
            tbResult.Text = "0";
            tbExp.Text = "";
            saved = 0;
            op = "";
            opPress=false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbResult.Text = "0";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tbResult.Text = tbResult.Text.Remove(tbResult.Text.Length - 1);
            if (tbResult.Text.Length==0)
            {
                tbResult.Text = "0";
            }

        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
            btnMC.Enabled = false;
            btnMR.Enabled = false;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            tbResult.Text = memory.ToString();
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memory += double.Parse(tbResult.Text);
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            memory -= double.Parse(tbResult.Text);
        }

        private void btnMSave_Click(object sender, EventArgs e)
        {
            memory = double.Parse(tbResult.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;

        }
    }
}
