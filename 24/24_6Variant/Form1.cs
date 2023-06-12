using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _24_6Variant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string[] words = text.Split(' ');
            string lastWord = words.Last();
            string slovary = "";

            foreach (var item in words)
            {
                if (String.IsNullOrEmpty(item))
                    continue;
                if (item[item.Length - 1] == words[0][words[0].Length - 1])
                    slovary += item + " ";
            }
            label3.Text = slovary;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        int countMax = 0;

        int index = 0;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            string text = textBox2.Text;
            string[] words = text.Split(' ');


            for (int i = 0; i < words.Length; i++)
            {
                if (String.IsNullOrEmpty(words[i]))
                    continue;

                int count = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (words[i][j] == 'и')
                        count++;

                }
                if (count > countMax)
                {
                    countMax = count;
                    index = i;
                    
                }

            }
            label4.Text = words[index];

        }
    }
}
