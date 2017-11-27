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
    /// <summary>
    /// Interaction logic for CreateLessonWindow.xaml
    /// </summary>
    public partial class CreateLessonWindow : Window
    {
        Context context = new Context();
        private Course selectedCourse;

        public CreateLessonWindow(Course c)
        {
            InitializeComponent();

            selectedCourse = c;
            List<TimeSpan> timeList = new List<TimeSpan>();
            DateTime intervalStart = new DateTime(01, 01, 01, 08, 00, 00);
            DateTime intervalStop = new DateTime(01, 01, 01, 18, 00, 00);

            // Opretter tider for hvert kvarter i døgnet fra kl. 8 indtil kl. 18. Kan modificeres efter ønske.
            while (intervalStart.CompareTo(intervalStop) <= 0)
            {
                timeList.Add(intervalStart.TimeOfDay);
                Console.WriteLine(intervalStart);
                intervalStart = intervalStart.AddMinutes(15);
            }

            createLesson_menu_startTime.ItemsSource = timeList;
            createLesson_menu_endTime.ItemsSource = timeList;

            createLesson_button_createLesson.Click += CreateLesson_button_createLesson_Click;
        }

        private void CreateLesson_button_createLesson_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = (DateTime) createLesson_datepicker_startTime.SelectedDate;
            TimeSpan startTime = (TimeSpan)createLesson_menu_startTime.SelectedItem;

            DateTime endDate = (DateTime)createLesson_datepicker_endTime.SelectedDate;
            TimeSpan endTime = (TimeSpan)createLesson_menu_endTime.SelectedItem;

            Lesson newLesson = new Lesson
            {
                StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hours, startTime.Minutes, 00),
                EndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hours, endTime.Minutes, 00)
            };

            context.AddLesson(selectedCourse, newLesson);

            // Opdaterer listview i MainWindow
            MainWindow parent = (MainWindow)this.DataContext;
            parent.tabCourse_listview_lessons.ItemsSource = context.GetCourseById(selectedCourse.Id).Lessons.ToList();

            this.Close();
        }
    }
}
