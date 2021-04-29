using System;
using System.Windows.Forms;

namespace _0507DLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cal cal = new Cal(); //객체 생성

            int num1 = int.Parse(textBox1.Text);
            int num2 = int.Parse(textBox2.Text);
            String oper = (String)comboBox1.SelectedItem;


            switch(oper)
            {
                case "+": cal.Add(num1, num2); break;
                case "-": cal.Sub(num1, num2); break;
                case "*": cal.Mul(num1, num2); break;
                case "/": cal.Div(num1, num2); break;
            }

            textBox3.Text = cal.result.ToString();
        }
    }
}
