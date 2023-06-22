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
    public partial class answerEdit : Window
    {
        Answer answer = new Answer();
        public string _questionID;
        public Int32 _answerID;
        public Int32 _answerIDB;
        public Int32 _answerIDC;
        public Int32 _answerIDD;
        public Button _vraagID;
        public Button _quizID;

        /*public answerEdit()
        {
            InitializeComponent();
           
            txbA.Text = answer.antwoordA;
            txbB.Text = answer.antwoordB;
            txbC.Text = answer.antwoordC;
            txbD.Text = answer.antwoordD;

            


        }*/
        public answerEdit(Button vraagID, Button quizID)
        {
            InitializeComponent();
            answer.Read((int)vraagID.Tag);
            txbA.Text = answer.antwoordA;
            txbB.Text = answer.antwoordB;
            txbC.Text = answer.antwoordC;
            txbD.Text = answer.antwoordD;

            _answerID = answer.ID;
            _answerIDB = answer.IDB;
            _answerIDC = answer.IDC;
            _answerIDD = answer.IDD;
            _quizID = quizID;
            _vraagID = vraagID;
            btnCancel.Click += btnCancel_Click;
            btnUpdate.Click += btnUpdate_Click;


            if (answer.correctA == "true")
            {
                rbA.IsChecked = true;
            }
            if (answer.correctB == "true")
            {
                rbB.IsChecked = true;
            }
            if (answer.correctC == "true")
            {
                rbC.IsChecked = true;
            }
            if (answer.correctD == "true")
            {
                rbD.IsChecked = true;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string correctA = "";
            if (rbA.IsChecked == true)
            {
                correctA = "true";
            }
            else { correctA = "false"; }

            answer.Update(_answerID, txbA.Text, correctA);

            string correctB = "";
            if (rbB.IsChecked == true)
            {
                correctB = "true";
            }
            else { correctB = "false"; }

            answer.Update(_answerIDB, txbB.Text, correctB);

            string correctC = "";
            if (rbC.IsChecked == true)
            {
                correctC = "true";
            }
            else { correctC = "false"; }

            answer.Update(_answerIDC, txbC.Text, correctC);

            string correctD = "";
            if (rbD.IsChecked == true)
            {
                correctD = "true";
            }
            else { correctD = "false"; }

            answer.Update(_answerIDD, txbA.Text, correctD);

            answersGrid answersGrid = new answersGrid(_vraagID, _quizID);
            answersGrid.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            answersGrid answersGrid = new answersGrid(_vraagID, _quizID);
            answersGrid.Show();
            this.Close();
        }
    }
}

