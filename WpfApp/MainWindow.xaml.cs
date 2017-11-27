
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
        Context context = new Context();
        Course selectedCourse;

        public MainWindow()
        {
            InitializeComponent();

            List<Course> allCourses = context.GetAllCourses();
            tabCourse_listview_courses.ItemsSource = allCourses;
            tabCourse_listview_courses.SelectionChanged += tabCourse_listview_courses_SelectionChanged;

            tabCourse_button_createCourse.Click += TabCourse_button_createCourse_Click;
            tabCourse_button_createLesson.Click += TabCourse_button_createLesson_Click;
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

        private void tabCourse_listview_courses_SelectionChanged(object sender, RoutedEventArgs e)
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
