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

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for SchoolWindow.xaml
    /// </summary>
    public partial class SchoolWindow : Window
    {
        private School school;
        public SchoolWindow()
        {
            InitializeComponent();
            school = new School();
            lbCampuses.ItemsSource = school.Campuses;
            lbCourses.ItemsSource = school.Courses;
            lbMajors.ItemsSource = school.Majors;
            lbStudents.ItemsSource = school.Students;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student newStudent = new Student();
            StudentWindow studentWindow = new StudentWindow(newStudent);
            studentWindow.ShowDialog();
            if (studentWindow.DialogResult == true)
            {
                MessageBox.Show("Student "+newStudent.StudentNumber+" Added!");
                school.Students.Add(newStudent);
                lbStudents.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Dialog Cancelled!");
            }
        }

        private void bntSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text Files|*.txt";

            bool? result= dialog.ShowDialog();
            if (result == true)
            {
                string path = dialog.FileName;
                string s = "";
                foreach(Student student in school.Students)
                {
                    s += student.ToString()+"\n";
                }

                File.WriteAllText(path, s);
            }

        }
    }
}
