using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiztime1
{
    /// <summary>
    /// Interaction logic for answerAdd.xaml
    /// </summary>
    public partial class answerAdd : Window
    {
        Answer answer = new Answer();
        Question question = new Question();
        public Int32 _vraagID;
        public Button _btnVraagID;
        public Button _btnQuizID;

        public answerAdd(Button vraagID, Button quizID)
        {
            InitializeComponent();

            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;
            question.Read((int)vraagID.Tag);
            lblQuestion.Content = question.vraag;

            _vraagID = (int)vraagID.Tag;
            _btnVraagID = vraagID;
            _btnQuizID = quizID;




        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string correctA = "";
            if (rbA.IsChecked == true)
            {
                correctA = "true";
            }
            else { correctA = "false"; }

            answer.Create(txbA.Text, correctA, "A", _vraagID);

            string correctB = "";
            if (rbB.IsChecked == true)
            {
                correctB = "true";
            }
            else { correctB = "false"; }

            answer.Create(txbB.Text, correctB, "B", _vraagID);

            string correctC = "";
            if (rbC.IsChecked == true)
            {
                correctC = "true";
            }
            else { correctC = "false"; }

            answer.Create(txbC.Text, correctC, "C", _vraagID);

            string correctD = "";
            if (rbD.IsChecked == true)
            {
                correctD = "true";
            }
            else { correctD = "false"; }

            answer.Create(txbD.Text, correctD, "D", _vraagID);

            answersGrid answersGrid = new answersGrid(_btnVraagID, _btnQuizID);
            answersGrid.Show();
            this.Close();

        }

    }
}

