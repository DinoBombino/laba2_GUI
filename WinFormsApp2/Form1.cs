using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.input.ToString();
        }

        private void button1_Click(object sender, EventArgs e)  // ������ ���
        {
            int input;
            try
            {
                input = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("������������ ����", "������", MessageBoxButtons.OK, MessageBoxIcon.Error); // ����� � ������
                textBox1.Clear();
                return;
            }
            Properties.Settings.Default.input = input;
            Properties.Settings.Default.Save();

            MessageBox.Show("�������������� ��� �������������� �����: " + Logic.Generate(input), "�����");
        }

        private void button2_Click(object sender, EventArgs e)  // ������ ��������
        {
            textBox1.Clear();
        }
    }

    public class Logic
    {
        public static string Generate(int n)
        {
            if (n <= 0)
            {
                return "�������� ����. ����������, ������� ������������� ����� ����� ������ ����.";
            }

            int prevNumber = 0;
            int currentNumber = 0;
            string result = "";

            for (int i = 1; ; i++)
            {
                currentNumber = i * i;

                if (currentNumber > n)
                    break;

                prevNumber = currentNumber;
                result += prevNumber + " ";
            }

            result += Environment.NewLine + "������ �����, ������� " + n + ": " + currentNumber;
            return result;
        }
    }
}
