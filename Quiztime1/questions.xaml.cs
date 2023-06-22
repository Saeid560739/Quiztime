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
    public partial class questions : Window
    {
        Question question = new Question();
        Quiz quiz = new Quiz();

        private Int32 _quizID;
        private Button _quizIDButton;



        public questions(Button quizID)
        {

            InitializeComponent();
            dgVragen.DataContext = question.getData((int)quizID.Tag);
            quiz.Read((int)quizID.Tag);

            btnAdd.Click += BtnAdd_Click;
            btnBack.Click += BtnBack_Click;


            _quizID = (int)quizID.Tag;
            _quizIDButton = quizID;
            lblQuiz.Content = quiz.naam;

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            questionAdd questionAdd = new questionAdd(_quizID, _quizIDButton);
            questionAdd.Show();
            this.Close();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgVragen.SelectedItem;
                int ID = int.Parse((dgVragen.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);


                questionEdit window = new questionEdit(ID, _quizIDButton);
                window.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgVragen.SelectedItem;
                int ID = int.Parse((dgVragen.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                if (question.Delete(ID) == true)
                {
                    dgVragen.DataContext = question.getData_Delete();
                }

                questions questions = new questions(_quizIDButton);
                questions.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btn_Antwoorden(object sender, RoutedEventArgs e)
        {
            Button vraagID = (Button)sender;

            answersGrid answersGrid = new answersGrid(vraagID, _quizIDButton);
            answersGrid.Show();
            this.Close();




        }
    }
}
