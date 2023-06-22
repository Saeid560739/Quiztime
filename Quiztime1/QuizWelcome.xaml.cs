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
    /// Interaction logic for QuizWelcome.xaml
    /// </summary>
    public partial class QuizWelcome : Window
    {
        Quiz quiz = new Quiz();
        Question question = new Question();
        private  MainWindow _MainWindow;
       

        

        public QuizWelcome(MainWindow mainWindow , Int32 ID)
        {
            //MessageBox.Show("ssssss");
            InitializeComponent();
            
            btnStart.Click += btnStart_Click;
            btnTerug.Click += btnTerug_Click;
            _MainWindow = mainWindow;
            quiz.Read(ID);
            lblQuizName.Content = quiz.naam;
        }
        
        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _MainWindow.quizStart();
            this.Close();
        }

    }
}
