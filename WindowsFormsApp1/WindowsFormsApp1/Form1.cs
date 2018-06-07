using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 4;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 4)
            {
                MessageBox.Show("Must be at least 4 characters long.");
                return /*false*/;
            }
            textBox2.Text = StringToBinary(textBox1.Text);
            textBox4.Text = "";
            foreach (var item in StringToBinary1(textBox1.Text))
            {
                textBox4.AppendText(item + Environment.NewLine);
            }
            textBox5.Text = "";
            foreach (var item in StringToBinary2(textBox1.Text))
            {
                textBox5.AppendText(item + Environment.NewLine);
            }
        }
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char L in data.ToCharArray())
            {
                sb.Append(Convert.ToString(L, 2).PadLeft(8, '0'));               
            }
            return sb.ToString();
        }
        public static List<string> StringToBinary1(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char L in data.ToCharArray())
            {
                sb.Append(Convert.ToString(L, 2).PadLeft(8, '0'));
            }
            List<string> split = new List<string>();

            int count = 1;

            string temp = string.Empty;
            for (int i = 0; i < sb.Length; i++)
            {
                if (count < 5)
                {
                    temp += sb[i];
                    count++;
                    if (count == 5)
                    {
                        count = 1;
                        split.Add(temp);
                        temp = string.Empty;
                    }

                }
            }
            return split;
        }
        public static List<string> StringToBinary2(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char L in data.ToCharArray())
            {
                sb.Append(Convert.ToString(L, 2).PadLeft(8, '0'));
            }
            List<string> split = new List<string>();

            int count = 1;

            string temp = string.Empty;
            for (int i = 0; i < sb.Length; i++)
            {
                if (count < 9)
                {
                    temp += sb[i];
                    count++;
                    if (count == 9)
                    {
                        count = 1;
                        split.Add(temp);
                        temp = string.Empty;
                    }

                }
            }
            return split;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = BinaryToString(textBox2.Text);
        }
        public static string BinaryToString(string binary)
        {
            List<Byte> byteList = new List<Byte>();
            for (int i = 0; i < binary.Length; i+=8)
            {
                byteList.Add(Convert.ToByte(binary.Substring(i, 8), 2));
                Console.WriteLine(binary);

            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }       
    }
}

