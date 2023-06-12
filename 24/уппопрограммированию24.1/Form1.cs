using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace уппопрограммированию24._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.RowCount = int.Parse(textBox1.Text);
                dataGridView1.ColumnCount = int.Parse(textBox1.Text);
                dataGridView2.RowCount = int.Parse(textBox1.Text);
                dataGridView2.ColumnCount = int.Parse(textBox1.Text);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            dataGridView1.Rows[i].Cells[j].Value = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) * int.Parse(textBox2.Text);
                    }
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        if (dataGridView2.Rows[i].Cells[j].Value != null)
                            dataGridView2.Rows[i].Cells[j].Value = int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString()) * int.Parse(textBox3.Text);
                    }
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount == dataGridView2.RowCount && dataGridView2.ColumnCount == dataGridView1.ColumnCount)
                {
                    dataGridView3.RowCount = dataGridView1.RowCount;
                    dataGridView3.ColumnCount = dataGridView2.ColumnCount;
                    for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridView3.ColumnCount; j++)
                        {
                            dataGridView3.Rows[i].Cells[j].Value = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) + int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception) { }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount == dataGridView2.RowCount && dataGridView2.ColumnCount == dataGridView1.ColumnCount)
                {
                    dataGridView3.RowCount = dataGridView1.RowCount;
                    dataGridView3.ColumnCount = dataGridView2.ColumnCount;
                    for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridView3.ColumnCount; j++)
                        {
                            dataGridView3.Rows[i].Cells[j].Value = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) - int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {

             
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount == dataGridView2.RowCount && dataGridView2.ColumnCount == dataGridView1.ColumnCount)
                {
                    dataGridView3.RowCount = dataGridView1.RowCount;
                    dataGridView3.ColumnCount = dataGridView2.ColumnCount;
                    for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridView3.ColumnCount; j++)
                        {
                            dataGridView3.Rows[i].Cells[j].Value = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) * int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null && dataGridView1.Rows[i + 1].Cells[j].Value != null && int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) > int.Parse(dataGridView1.Rows[i + 1].Cells[j].Value.ToString()))
                        {
                            object data_temp = dataGridView1.Rows[i].Cells[j].Value;
                            dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[i + 1].Cells[j].Value;
                            dataGridView1.Rows[i + 1].Cells[j].Value = data_temp;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        if (dataGridView2.Rows[i].Cells[j].Value != null && dataGridView2.Rows[i + 1].Cells[j].Value != null && int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString()) > int.Parse(dataGridView2.Rows[i + 1].Cells[j].Value.ToString()))
                        {
                            object data_temp = dataGridView2.Rows[i].Cells[j].Value;
                            dataGridView2.Rows[i].Cells[j].Value = dataGridView2.Rows[i + 1].Cells[j].Value;
                            dataGridView2.Rows[i + 1].Cells[j].Value = data_temp;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.RowCount = dataGridView1.RowCount;
                dataGridView3.ColumnCount = dataGridView1.ColumnCount;
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView3.Rows[j].Cells[i].Value = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }
            catch (Exception) { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.RowCount = dataGridView2.RowCount;
                dataGridView3.ColumnCount = dataGridView2.ColumnCount;
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        dataGridView3.Rows[j].Cells[i].Value = int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }
            catch(Exception) { }    
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                double determinant1 = 0;
                if (dataGridView1.RowCount == 2 && dataGridView1.ColumnCount == 2)
                {
                    determinant1 = (Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value) *
                        Convert.ToInt32(dataGridView1.Rows[1].Cells[1].Value)) -
                        (Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value) *
                        Convert.ToInt32(dataGridView1.Rows[1].Cells[0].Value));

                }
                else
                    determinant1 = (Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value) *
                        Convert.ToInt32(dataGridView1.Rows[1].Cells[1].Value) *
                        Convert.ToInt32(dataGridView1.Rows[2].Cells[2].Value)) -
                        (Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value) *
                        Convert.ToInt32(dataGridView1.Rows[1].Cells[2].Value) *
                        Convert.ToInt32(dataGridView1.Rows[2].Cells[1].Value)) -
                        (Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value) *
                        Convert.ToInt32(dataGridView1.Rows[1].Cells[0].Value) *
                        Convert.ToInt32(dataGridView1.Rows[2].Cells[2].Value)) +
                        (Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value) *
                        Convert.ToInt32(dataGridView1.Rows[1].Cells[2].Value) *
                        Convert.ToInt32(dataGridView1.Rows[2].Cells[0].Value)) +
                        (Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value) *
                        Convert.ToInt32(dataGridView1.Rows[1].Cells[0].Value) *
                        Convert.ToInt32(dataGridView1.Rows[2].Cells[1].Value)) -
                        (Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value) *
                        Convert.ToInt32(dataGridView1.Rows[1].Cells[1].Value) *
                        Convert.ToInt32(dataGridView1.Rows[2].Cells[0].Value));
                MessageBox.Show("Детерминант - " + determinant1);
            }
            catch (Exception) { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int determinant2 = 0;
                if (dataGridView2.RowCount == 2 & dataGridView2.ColumnCount == 2)
                {
                    determinant2 = (Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value) *
                        Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value)) -
                        (Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value) *
                        Convert.ToInt32(dataGridView2.Rows[1].Cells[0].Value));
                }
                else
                    determinant2 = (Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value) *
                        Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value) *
                        Convert.ToInt32(dataGridView2.Rows[2].Cells[2].Value)) -
                        (Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value) *
                        Convert.ToInt32(dataGridView2.Rows[1].Cells[2].Value) *
                        Convert.ToInt32(dataGridView2.Rows[2].Cells[1].Value)) -
                        (Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value) *
                        Convert.ToInt32(dataGridView2.Rows[1].Cells[0].Value) *
                        Convert.ToInt32(dataGridView2.Rows[2].Cells[2].Value)) +
                        (Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value) *
                        Convert.ToInt32(dataGridView2.Rows[1].Cells[2].Value) *
                        Convert.ToInt32(dataGridView2.Rows[2].Cells[0].Value)) +
                        (Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value) *
                        Convert.ToInt32(dataGridView2.Rows[1].Cells[0].Value) *
                        Convert.ToInt32(dataGridView2.Rows[2].Cells[1].Value)) -
                        (Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value) *
                        Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value) *
                        Convert.ToInt32(dataGridView2.Rows[2].Cells[0].Value));
                MessageBox.Show("Детерминант - " + determinant2);
            }
            catch (Exception) { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
