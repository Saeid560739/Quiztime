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
    /// Interaction logic for questions.xaml
    /// </summary>
    public partial class answersGrid : Window
    {
        Answer answer = new Answer();
        Quiz quiz = new Quiz();
        Question question = new Question();

        public Int32 _vraagID;
        public Button _quizID;
        public Button _vraagID2;


        public answersGrid(Button vraagID, Button quizID)
        {
            InitializeComponent();
            dgAnswers.DataContext = answer.getData((int)vraagID.Tag);
            _vraagID = (int)vraagID.Tag;
            quiz.Read((int)quizID.Tag);
            question.Read((int)vraagID.Tag);

            btnEdit.Click += BtnEdit_Click;
            btnAdd.Click += BtnAdd_Click;
            btnBack.Click += BtnBack_Click;
            lblQuiz.Content = quiz.naam;
            lblAntwoord.Content = question.vraag;
            _quizID = quizID;
            _vraagID2 = vraagID;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            answerEdit answerEdit = new answerEdit(_vraagID2, _quizID);
            answerEdit.Show();
            this.Close();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            questions questions = new questions(_quizID);
            questions.Show();
            this.Close();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            answerAdd answerAdd = new answerAdd(_vraagID2, _quizID);
            answerAdd.Show();
            this.Close();
        }

        /*private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
           
                object item = dgAnswers.SelectedItem;
                int ID = int.Parse((dgAnswers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                answerEdit window = new answerEdit(ID, _vraagID2, _quizID);
                window.Show();
                this.Close();
                   
        }*/

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgAnswers.SelectedItem;
                int ID = int.Parse((dgAnswers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                if (answer.Delete(ID) == true)
                {
                    dgAnswers.DataContext = answer.getData_Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


    }
}
