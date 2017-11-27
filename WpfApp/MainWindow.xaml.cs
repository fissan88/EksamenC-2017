
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

        public MainWindow()
        {
            InitializeComponent();

            List<Course> allCourses = context.GetAllCourses();
            tabCourse_listview_courses.ItemsSource = allCourses;
            tabCourse_listview_courses.SelectionChanged += tabCourse_listview_courses_SelectionChanged;

            tabCourse_button_createCourse.Click += TabCourse_button_createCourse_Click;
        }

        private void TabCourse_button_createCourse_Click(object sender, RoutedEventArgs e)
        {
            CreateCourseWindow createCourseWindow = new CreateCourseWindow();
            createCourseWindow.Show();
        }

        private void tabCourse_listview_courses_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Course selectedCourse = (Course)tabCourse_listview_courses.SelectedItem;

            if(selectedCourse.Lessons.Count > 0 && selectedCourse != null)
            {
                tabCourse_listview_lessons.IsEnabled = true;
                tabCourse_button_createLesson.IsEnabled = true;
                tabCourse_listview_lessons.ItemsSource = selectedCourse.Lessons;
            }
            else
            {
                System.Windows.MessageBox.Show("The selected course has no registered lessons.");
            }
        }
    }
}
