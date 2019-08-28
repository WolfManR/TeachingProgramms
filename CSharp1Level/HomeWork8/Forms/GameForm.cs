using HomeWork8.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork8.Forms
{
    public partial class GameForm : Form
    {
        public MainForm Main { get; set; }
        List<Question> questions = new List<Question>();
        int currentIndex = 0;
        int correct = 0;
        int max = Program.DataBase.Count;
        public GameForm()
        {
            InitializeComponent();
        }
        void SwitchOffBtns()
        {
            btnYes.Enabled = false;
            btnNo.Enabled = false;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Main.Close();
        }

        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        void InitializeNextQuestion()
        {
            currentIndex++;
            if (currentIndex < max) tbQuestion.Text = questions[currentIndex].text;
            else GameEnd();
        }
        void GameEnd()
        {
            SwitchOffBtns();
            MessageBox.Show($"Вы ответили верно на {correct} из {max} вопросов");
            Main.Show();
            Close();
        }
        void CheckAnswer(bool answer)
        {
            if (answer == questions[currentIndex].trueFalse)
            {
                correct++;
                lblTrueAnswers.Text = correct.ToString();
                lblTrueAnswer.Text = "Верно";
            }
            else lblTrueAnswer.Text = "Не верно";
        }
        private void BtnYes_Click(object sender, EventArgs e)
        {
            CheckAnswer(true);
            InitializeNextQuestion();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            CheckAnswer(false);
            InitializeNextQuestion();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            int number = 0;
            lblQuestions.Text = max.ToString();
            Random rand = new Random();
            List<int> numbers = new List<int>();
            do
            {
                number = rand.Next(max);
                if (!numbers.Contains(number))
                {
                    questions.Add(Program.DataBase[number]);
                    numbers.Add(number);
                }
            } while (questions.Count != max);
            tbQuestion.Text = questions[currentIndex].text;
        }
    }
}
