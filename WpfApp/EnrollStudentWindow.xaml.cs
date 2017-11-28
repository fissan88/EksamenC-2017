using ClassLibrary.Model;
using Storage;
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

namespace WpfApp
{
    public partial class EnrollStudentWindow : Window
    {
        Context context = Context.GetInstance();
        Student currStudent;
        Course currCourse;

        public EnrollStudentWindow(Student s)
        {
            InitializeComponent();
            currStudent = s;
            enrollStudent_listview_courses.ItemsSource = context.GetCoursesStudentNotEnrolledIn(currStudent);
            enrollStudent_listview_courses.SelectionChanged += EnrollStudent_listview_courses_SelectionChanged;
            enrollStudent_button_enroll.Click += EnrollStudent_button_enroll_Click;
        }

        private void EnrollStudent_listview_courses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currCourse = (Course) enrollStudent_listview_courses.SelectedItem;
            enrollStudent_button_enroll.IsEnabled = true;
        }

        private void EnrollStudent_button_enroll_Click(object sender, RoutedEventArgs e)
        {
           if(currCourse != null)
            {
                context.EnrollStudent(currCourse, currStudent);

                // Opdaterer listview for studerendes kurser i MainWindow
                MainWindow parent = (MainWindow)this.DataContext;
                currStudent = (Student) context.GetUserById(currStudent.Id);
                parent.tabStudents_listview_studentsCourses.ItemsSource = currStudent.Courses;

                Close();
            }
        }
    }
}
