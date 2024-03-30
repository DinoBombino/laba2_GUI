namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.number.ToString();
        }

        private void button1_Click(object sender, EventArgs e)  //Кнопка ТЫК
        {
            //MessageBox.Show(this.textBox1.Text);
            //MessageBox.Show("Ура работает! (╯°□°）╯︵ ┻━┻");

            int number;
            try
            {
                number = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); //можно и убрать
                textBox1.Clear();
                return;
            }

            Properties.Settings.Default.number = number;
            //Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();

            //number = int.Parse(this.textBox1.Text);
            if (!(number > 99 && number < 1000))
            {
                MessageBox.Show("Введено некорректное число. Введите трехзначное число.", "Ошибка");
            }
            else
            {
                MessageBox.Show("Наибольшая цифра в числе: " + Logic.FindMaxDigit(number).ToString(), "Ответ");
            }
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)  //Кнопка Очистить
        {
            textBox1.Clear();
        }
    }
    public class Logic
    {
        public static int FindMaxDigit(int number)
        {
            int digit1 = number / 100;
            int digit2 = (number / 10) % 10;
            int digit3 = number % 10;

            int maxDigit = digit1;
            if (digit2 > maxDigit)
            {
                maxDigit = digit2;
            }
            if (digit3 > maxDigit)
            {
                maxDigit = digit3;
            }

            return maxDigit;
        }
    }
}
