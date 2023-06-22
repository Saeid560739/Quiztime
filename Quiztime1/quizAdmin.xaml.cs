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
    /// Interaction logic for quizAdmin.xaml
    /// </summary>
    public partial class quizAdmin : Window
    {
        Quiz quiz = new Quiz();
        Question question = new Question();
        private quizStart _quizStart;
        private MainWindow _MainWindow;
        public quizAdmin(quizStart quizStart)
        {
            InitializeComponent();
            btnNext.Click += BtnNext_Click;
            btnBack.Click += BtnBack_Click;
            btnAntwoord.Click += BtnAntwoord_Click;
            btnTimeStart.Click += btnTimeStart_Click;
            btnhoofdPagina.Click += btnhoofdPagina_Click;
            _quizStart = quizStart;
        }

        private void btnhoofdPagina_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            _quizStart.Close();
        }

        private void btnTimeStart_Click(object sender, RoutedEventArgs e)
        {
            _quizStart.startTimer();
        }
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            _quizStart.NextQuestion();
        }
        private void BtnAntwoord_Click(object sender, RoutedEventArgs e)
        {
            _quizStart.revealAnswer();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            _quizStart.LastQuestion();
        }


    }
}
