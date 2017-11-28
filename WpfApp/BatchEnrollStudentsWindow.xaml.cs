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
    public partial class BatchEnrollStudentsWindow : Window
    {
        Context context = Storage.Context.GetInstance();
        Course currCourse;

        public BatchEnrollStudentsWindow(Course course)
        {
            InitializeComponent();
            currCourse = course;
            enrollStudents_listView_students.ItemsSource = context.GetAllStudentsIncludingCourses();
            CheckAndSetEnrollmentState();
            enrollStudents_button_enrollStudents.Click += EnrollStudents_button_enrollStudents_Click;
        }

        private void EnrollStudents_button_enrollStudents_Click(object sender, RoutedEventArgs e)
        {
            UpdateEnrollmentStateStudents();
            Close();
        }

        public void CheckAndSetEnrollmentState()
        {
            for (int i = 0; i < enrollStudents_listView_students.Items.Count; i++)
            {
                Student currItem = (Student)enrollStudents_listView_students.Items.GetItemAt(i);

                if (currItem.Courses.Contains(currCourse))
                {
                    enrollStudents_listView_students.SelectedItems.Add(enrollStudents_listView_students.Items.GetItemAt(i));
                }
             }
        }

        public void UpdateEnrollmentStateStudents()
        {
            for (int i = 0; i < enrollStudents_listView_students.Items.Count; i++)
            {
                Student currStudent = (Student)enrollStudents_listView_students.Items.GetItemAt(i);
                bool studentHasCourse = currStudent.Courses.Contains(currCourse);

                if (!studentHasCourse && enrollStudents_listView_students.SelectedItems.Contains(enrollStudents_listView_students.Items.GetItemAt(i)))
                {
                    context.EnrollStudent(currCourse, currStudent);
                }
                else
                {
                    if(studentHasCourse && currStudent.Courses.Contains(currCourse))
                    {
                        context.DeleteEnrollmentStudent(currCourse, currStudent);
                    }
                }
            }
        }
    }
}
