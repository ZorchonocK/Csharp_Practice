namespace LR23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color color = button1.BackColor;
            button1.BackColor = button2.BackColor;
            button2.BackColor = color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color color = button2.BackColor;
            button2.BackColor = button1.BackColor;
            button1.BackColor = color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(textBox1.Text);
                double a = double.Parse(textBox2.Text);
                double b = double.Parse(textBox3.Text);
                textBox4.Text = Convert.ToString(0.8 * Math.Cos(x + b) / (Math.Pow((0.21 * x + a), 1 / 5)));
            }
            catch (Exception)
            {

                
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button13.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + button14.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
             label4.Text = textBox5.Text;
             textBox5.Text = "";
             label5.Text = button15.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            double a = double.Parse(label4.Text);
            double b = double.Parse(textBox5.Text);
            if (label5.Text == "+")
            {
                textBox5.Text = Convert.ToString(a + b);
            }
            else if(label5.Text == "-")
            {
                textBox5.Text = Convert.ToString(a - b);
            }
            else if (label5.Text == "*")
            {
                textBox5.Text = Convert.ToString(a * b);
            }
            else if (label5.Text == "/")
            {
                textBox5.Text = Convert.ToString(a / b);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label4.Text = textBox5.Text;
            textBox5.Text = "";
            label5.Text = button16.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label4.Text = textBox5.Text;
            textBox5.Text = "";
            label5.Text = button17.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label4.Text = textBox5.Text;
            textBox5.Text = "";
            label5.Text = button18.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(Math.Sqrt(double.Parse(textBox5.Text)));
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(Math.Pow(double.Parse(textBox5.Text),2));
        }

        private void button22_Click(object sender, EventArgs e)
        {
            
           
           
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox5.Text = null;
            label4.Text = null;
            label5.Text=null;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text[0] == '-')
                {
                    string str = textBox5.Text;
                    char[] ch = str.ToCharArray();
                    ch[0] = '+';
                    textBox5.Text = "";
                    for (int i = 0; i < ch.Length; i++)
                    {
                        textBox5.Text += ch[i].ToString();
                    }
                  
                } else
                if (textBox5.Text[0] == '+')
                {
                    string str = textBox5.Text;
                    char[] ch = str.ToCharArray();
                    ch[0] = '-';
                    textBox5.Text = "";
                    for (int i = 0; i < ch.Length; i++)
                    {
                        textBox5.Text += ch[i].ToString();
                    }
                }
                else
                {
                    textBox5.Text = "-" + textBox5.Text;
                }
            }
            catch (Exception)
            {

            }
      
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    label6.Text = Convert.ToString(int.Parse(textBox6.Text), 2);
                }
            }
            catch (Exception)
            {

            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked == true)
                {
                    label6.Text = Convert.ToString(int.Parse(textBox6.Text), 8);
                }
            }
            catch (Exception)
            {

            }
        
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton3.Checked == true)
                {
                    label6.Text = Convert.ToString(int.Parse(textBox6.Text), 16);
                }
            }
            catch (Exception) { }
            
        }
    }
}