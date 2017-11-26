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
    /// Interaction logic for CreateCourseWindow.xaml
    /// </summary>
    public partial class CreateCourseWindow : Window
    {
        Context context = new Context();

        public CreateCourseWindow()
        {
            InitializeComponent();

            createCourse_listview_teachers.ItemsSource = context.GetAllTeachers();

            createCourse_button_create.Click += CreateCourse_button_create_Click;
        }

        private void CreateCourse_button_create_Click(object sender, RoutedEventArgs e)
        {
            string name = createCourse_textbox_name.Text;
            Teacher teacher = (Teacher) createCourse_listview_teachers.SelectedItem;

            if(teacher != null && name.Length > 0)
            {
                Course newCourse = new Course(name, teacher);
                context.Courses.Add(newCourse);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}
