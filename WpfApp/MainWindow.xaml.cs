
using Storage;
using Model;
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
using ClassLibrary.Model;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context context = Storage.Context.GetInstance();
        Course selectedCourse;

        public MainWindow()
        {
            InitializeComponent();

            // Fag - tabben
            tabCourse_listview_courses.ItemsSource = context.GetAllCourses();
            tabCourse_listview_courses.SelectionChanged += TabCourse_listview_courses_SelectionChanged;
            tabCourse_button_createCourse.Click += TabCourse_button_createCourse_Click;
            tabCourse_button_createLesson.Click += TabCourse_button_createLesson_Click;


            // Lærer -tabben
            tabTeachers_listview_teachers.ItemsSource = context.GetAllTeachersIncludingCourses();
            tabTeachers_listview_teachers.SelectionChanged += TabTeachers_listview_teachers_SelectionChanged;
            tabTeachers_button_createTeacher.Click += TabTeachers_button_createTeacher_Click;

            // Studerende-Tabben
            tabStudents_listview_students.ItemsSource = context.GetAllStudentsIncludingCourses();
            tabStudents_listview_students.SelectionChanged += TabStudents_listview_students_SelectionChanged;
            tabStudents_button_createStudent.Click += TabStudents_button_createStudent_Click;

        }

        private void TabStudents_button_createStudent_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow(new Student());
            createUserWindow.DataContext = this;
            createUserWindow.Show();
        }

        private void TabStudents_listview_students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student selectedStudent = (Student) tabStudents_listview_students.SelectedItem;

            if (selectedStudent != null)
            {
                tabStudent_stackpanel_studentDetails.DataContext = selectedStudent;
                tabStudents_listview_studentsCourses.ItemsSource = selectedStudent.Courses;
            }
        }

        private void TabTeachers_button_createTeacher_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow(new Teacher());
            createUserWindow.DataContext = this;
            createUserWindow.Show();
        }

        private void TabTeachers_listview_teachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Teacher selectedTeacher = (Teacher) tabTeachers_listview_teachers.SelectedItem;

            if (selectedTeacher != null)
            {
                tabTeachers_stackpanel_teacherDetails.DataContext = selectedTeacher;
                tabTeachers_listview_teachersCourses.ItemsSource = selectedTeacher.Courses;
            }
        }

        private void TabCourse_button_createLesson_Click(object sender, RoutedEventArgs e)
        {
            CreateLessonWindow createLessonWindow = new CreateLessonWindow(selectedCourse);
            createLessonWindow.DataContext = this;
            createLessonWindow.Show();
        }

        private void TabCourse_button_createCourse_Click(object sender, RoutedEventArgs e)
        {
            CreateCourseWindow createCourseWindow = new CreateCourseWindow();
            createCourseWindow.DataContext = this;
            createCourseWindow.Show();
        }

        private void TabCourse_listview_courses_SelectionChanged(object sender, RoutedEventArgs e)
        {
            selectedCourse = (Course) tabCourse_listview_courses.SelectedItem;

            if(selectedCourse != null)
            {
                tabCourse_button_createLesson.IsEnabled = true;
            }
            else
            {
                tabCourse_button_createLesson.IsEnabled = false;
            }

            if (selectedCourse.Lessons.Count > 0)
            {
                tabCourse_listview_lessons.IsEnabled = true;
            }
            else
            {
                tabCourse_listview_lessons.IsEnabled = false;
            }
            tabCourse_listview_lessons.ItemsSource = selectedCourse.Lessons;
        }
    }
}
