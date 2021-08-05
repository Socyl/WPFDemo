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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student TheStudent { get; }

        public StudentWindow():this(new Student())
        {
            
        }

        public StudentWindow(Student newStudent)
        {
            InitializeComponent();
            TheStudent = newStudent;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
           

            //Set the values from our controls into the class
            TheStudent.FirstName = txbFirstName.Text;
            TheStudent.LastName = txbLastName.Text;
            TheStudent.StudentNumber = txbStudentNum.Text;
            TheStudent.Major = txbMajor.Text;

            List<Assignment> scores = new List<Assignment>();
            foreach (Assignment score in lbScores.Items)
            {
                scores.Add(score);    
            }
            TheStudent.Scores = scores;

            //Set the results from the class into a control on the form
            txbResults.Text = TheStudent.ToString();
            DialogResult = true;
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Assignment assign = new Assignment();
            assign.Title = txbTitle.Text;
            assign.Score = int.Parse(txbScore.Text);
            lbScores.Items.Add(assign);
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
