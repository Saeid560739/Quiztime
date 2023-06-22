using Microsoft.Win32;
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
    /// Interaction logic for quizEdit.xaml
    /// </summary>
    public partial class questionAdd : Window
    {
        Question question = new Question();
        private Int32 _ID;
        private Button _Id1;


        public questionAdd()
        {


            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;
            btnSelectImage.Click += BtnSelectImage_Click;
            txbAfbeelding.Visibility = Visibility.Hidden;
        }



        public questionAdd(Int32 _quizID, Button quizID)
        {

            InitializeComponent();
            _ID = _quizID;
            _Id1 = quizID;
            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;
            btnSelectImage.Click += BtnSelectImage_Click;
            txbAfbeelding.Visibility = Visibility.Hidden;

        }



        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            questions questions = new questions(_Id1);
            questions.Show();
            this.Close();
        }


        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false };
            {
                bool? result = ofd.ShowDialog();
                if (result == true)
                {
                    txbAfbeelding.Text = ofd.FileName;

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(ofd.FileName);
                    image.EndInit();

                    imgQuestion.Source = image;
                }
                else
                {
                    MessageBox.Show("You didn't choose an image");
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            question.Create(txbVraag.Text, txbAfbeelding.Text, _ID);

            questions questions = new questions(_Id1);
            questions.Show();
            this.Close();
        }


    }
}
