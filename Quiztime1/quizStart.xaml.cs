using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace Quiztime1
{
    /// <summary>
    /// Interaction logic for quizStart.xaml
    /// </summary>
    public partial class quizStart : Window

    {
        Quiz quiz = new Quiz();
        Question question = new Question();
        Answer answer = new Answer();
        private quizAdmin _quizAdmin;
        int _quizId;
        int row = 0;
        DispatcherTimer timer;
        TimeSpan time;


        public quizStart(Int32 quizID)
        {
            
            _quizId = quizID;
            InitializeComponent();
            quizAdmin quizadmin = new quizAdmin(this);
            quizadmin.Show();
            _quizAdmin = quizadmin;

            quiz.Read(quizID);
            lblquiz.Content = quiz.naam;
            _quizAdmin.btnBack.Visibility = Visibility.Hidden;

            question.showQuestion(quizID);
            lblvraag.Content = question.vraag;

            long vraagid = question.ID;

            txbAfbeelding.Visibility = Visibility.Hidden;
            if (File.Exists(System.IO.Path.GetFullPath(@"../../img/question/" + vraagid + ".jpg")))
            {
                ImageBox.Visibility = Visibility.Visible;
                BitmapImage image = new BitmapImage();
                txbAfbeelding.Text = question.afbeelding;
                string absolutePath = System.IO.Path.GetFullPath(@"../../img/question/" + vraagid + ".jpg");
                image.BeginInit();
                image.UriSource = new Uri(absolutePath);
                image.EndInit();

                ImageBox.Source = image;
            }

            answer.Read(question.ID);
            lblA.Content = answer.antwoordA;
            lblB.Content = answer.antwoordB;
            lblC.Content = answer.antwoordC;
            lblD.Content = answer.antwoordD;

            time = TimeSpan.FromSeconds(3);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick; ;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time == TimeSpan.Zero)
            {
                timer.Stop();
                revealAnswer();
                time = TimeSpan.FromSeconds(3);

            }
            else
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                TimeLabel.Content = time.ToString("c");
            }
        }

        public void startTimer()
        {
            timer.Start();
        }


        public void revealAnswer()
        {
            if (answer.correctA == "true")
            {
                lblA.Foreground = Brushes.Green;       
            }
            else
            {
                lblA.Foreground = Brushes.Red;
            }
            if (answer.correctB == "true")
            {
                lblB.Foreground = Brushes.Green;     
            }
            else
            {
                lblB.Foreground = Brushes.Red;
            }
            if (answer.correctC == "true")
            {
                lblC.Foreground = Brushes.Green;
            }
            else
            {
                lblC.Foreground = Brushes.Red;
            }
            if (answer.correctD == "true")
            {
                lblD.Foreground = Brushes.Green;
            }
            else
            {
                lblD.Foreground = Brushes.Red;
            }
        }
        public void LastQuestion()
        {
            row--;
            lblA.Foreground = Brushes.Black;
            lblB.Foreground = Brushes.Black;
            lblC.Foreground = Brushes.Black;
            lblD.Foreground = Brushes.Black;
            question.showQuestion1(_quizId, row);
            lblvraag.Content = question.vraag;
            long vraagid = question.ID;
            if (File.Exists(System.IO.Path.GetFullPath(@"../../img/question/" + vraagid + ".jpg")))
            {
                ImageBox.Visibility = Visibility.Visible;
                BitmapImage image = new BitmapImage();
                txbAfbeelding.Text = question.afbeelding;
                string absolutePath = System.IO.Path.GetFullPath(@"../../img/question/" + vraagid + ".jpg");
                image.BeginInit();
                image.UriSource = new Uri(absolutePath);
                image.EndInit();
                ImageBox.Source = image;
            }

            if (row == 0)
            {
                _quizAdmin.btnBack.Visibility = Visibility.Hidden;
            }
        }

        public void NextQuestion()
        {

            try
            {
                row++;
                
                _quizAdmin.btnBack.Visibility = Visibility.Visible;
                lblA.Foreground = Brushes.Black;
                lblB.Foreground = Brushes.Black;
                lblC.Foreground = Brushes.Black;
                lblD.Foreground = Brushes.Black;

                question.showQuestion1(_quizId, row);
                lblvraag.Content = question.vraag;
                long vraagid = question.ID;
                answer.Read(vraagid);
                lblA.Content = answer.antwoordA;
                lblB.Content = answer.antwoordB;
                lblC.Content = answer.antwoordC;
                lblD.Content = answer.antwoordD;

                if (File.Exists(System.IO.Path.GetFullPath(@"../../img/question/" + vraagid + ".jpg")))
                {
                    ImageBox.Visibility = Visibility.Visible;
                    BitmapImage image = new BitmapImage();
                    txbAfbeelding.Text = question.afbeelding;
                    string absolutePath = System.IO.Path.GetFullPath(@"../../img/question/" + vraagid + ".jpg");
                    image.BeginInit();
                    image.UriSource = new Uri(absolutePath);
                    image.EndInit();

                    ImageBox.Source = image;
                }
                else
                {
                    ImageBox.Visibility = Visibility.Hidden;
                }

            }
            catch
            {
                quizEnd quizEnd = new quizEnd();
                quizEnd.Show();
                this.Close();
            }

        }

    }

}


