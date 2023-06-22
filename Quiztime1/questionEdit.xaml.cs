using Microsoft.Win32;
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

namespace Quiztime1
{
    /// <summary>
    /// Interaction logic for quizEdit.xaml
    /// </summary>
    public partial class questionEdit : Window
    {
        Question question = new Question();
        private Int32 _questoinID;
        private Button _quizID;
        
        public questionEdit()
        {

            InitializeComponent();
            btnUpdateImage.Visibility = Visibility.Hidden;
            txbAfbeelding.Visibility = Visibility.Hidden;
            btnSelectImage.Click += BtnSelectImage_Click;
            btnUpdateVraag.Click += BtnUpdateVraag_Click;
            btnCancel.Click += btnCancel_Click;
        }



        public questionEdit(Int32 ID, Button quizID)
        {

            InitializeComponent();
            question.Read(ID);
            btnUpdateImage.IsEnabled = false;


            txbVraag.Text = question.vraag;
            long questionID = question.ID;

            if (File.Exists(System.IO.Path.GetFullPath(@"../../img/question/" + questionID + ".jpg")))
            {
                BitmapImage image = new BitmapImage();
                txbAfbeelding.Text = question.afbeelding;
                string absolutePath = System.IO.Path.GetFullPath(@"../../img/question/" + questionID + ".jpg");
                image.BeginInit();
                image.UriSource = new Uri(absolutePath);
                image.EndInit();

                imgQuestion.Source = image;
            }




            txbAfbeelding.Visibility = Visibility.Hidden;
            btnSelectImage.Click += BtnSelectImage_Click;
            btnUpdateImage.Click += BtnUpdateImage_Click1;
            btnUpdateVraag.Click += BtnUpdateVraag_Click;
            btnCancel.Click += btnCancel_Click;
            _questoinID = ID;
            _quizID = quizID;

        }

        private void BtnUpdateVraag_Click(object sender, RoutedEventArgs e)
        {
            question.UpdateQuestion(_questoinID.ToString(),
                            txbVraag.Text);

            lblVraagStatus.Content = "";
            lblVraagStatus.Content = "Vraag is aangepast!";

            /*questions questoins = new questions(_quizID);
            questoins.Show();
            this.Close(); */
        }

        private void BtnUpdateImage_Click1(object sender, RoutedEventArgs e)
        {
            long questionID = question.ID;


            question.Update(_questoinID.ToString(),
                            txbAfbeelding.Text);

            btnUpdateImage.IsEnabled = false;
            lblImageStatus.Content = "Afbeelding is aangepast!";
            /*questions questoins = new questions(_quizID);
            questoins.Show();
            this.Close();*/
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
                    btnUpdateImage.IsEnabled = true;


                }
                else
                {
                    MessageBox.Show("You didn't choose an image");
                }
            }
        }



        /*private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            long questionID = question.ID;
            

            question.Update(_questoinID.ToString(),
                            txbAfbeelding.Text);

            btnUpdate.Visibility = Visibility.Hidden;
            *//*questions questoins = new questions(_quizID);
            questoins.Show();
            this.Close();*//*
        }*/
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            questions questoins = new questions(_quizID);
            questoins.Show();
            this.Close();
        }
    }
}
