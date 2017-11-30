using ClassLibrary.Model;
using Model;
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
    /// Interaction logic for CreateTeacherWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        Context context = Storage.Context.GetInstance();
        User typeCheck;

        // User bliver brugt til at genkende typen, så vinduet kan genbruges ved oprettelse af både lærer og studerende
        public CreateUserWindow(User u)
        {
            InitializeComponent();
            typeCheck = u;
            createTeacher_button_create.Click += CreateTeacher_button_create_Click;
        }

        private void CreateTeacher_button_create_Click(object sender, RoutedEventArgs e)
        {
            string fullname = createTeacher_textBox_fullname.Text;
            string username = createTeacher_textBox_username.Text;

            if(context.GetUserByUsername(username) == null)
            {
                if (fullname.Length > 0 && username.Length > 0)
                {
                    MainWindow parent = (MainWindow)this.DataContext;
                    if (typeCheck.GetType() == typeof(Teacher))
                    {
                        Teacher newTeacher = new Teacher { FullName = fullname, Username = username };
                        context.AddTeacher(newTeacher);

                        // Opdaterer teacher listview i parent viduet
                        parent.tabTeachers_listview_teachers.ItemsSource = context.GetAllTeachers();
                    }
                    else
                    {
                        Student newStudent = new Student { FullName = fullname, Username = username };
                        context.AddStudent(newStudent);

                        // Opdaterer student listview i parent viduet
                        parent.tabStudents_listview_students.ItemsSource = context.GetAllStudentsIncludingCourses();
                    }
                    Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Please specify both a username and your full name!");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Username is already taken!");
            }

            
        }
    }
}
