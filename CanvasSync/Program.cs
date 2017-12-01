using ClassLibrary.Model;
using Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CanvasApi
{
    class Program
    {

        class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string sortable_name { get; set; }
            public string short_name { get; set; }
            public string sis_user_id { get; set; }
            public int sis_import_id { get; set; }
            public object sis_login_id { get; set; }
            public string integration_id { get; set; }
            public string login_id { get; set; }
            public string avatar_url { get; set; }
            public object enrollments { get; set; }
            public string email { get; set; }
            public string locale { get; set; }
            public DateTime? last_login { get; set; }
            public string time_zone { get; set; }
            public string bio { get; set; }
        }


         class Course
        {
            public int id { get; set; }
            public string name { get; set; }
            public int account_id { get; set; }
            public string uuid { get; set; }
            public DateTime? start_at { get; set; }
            public object grading_standard_id { get; set; }
            public object is_public { get; set; }
            public string course_code { get; set; }
            public string default_view { get; set; }
            public int root_account_id { get; set; }
            public int enrollment_term_id { get; set; }
            public Teacher[] Teachers { get; set; }
            public DateTime? end_at { get; set; }
            public bool public_syllabus { get; set; }
            public bool public_syllabus_to_auth { get; set; }
            public int storage_quota_mb { get; set; }
            public bool is_public_to_auth_users { get; set; }
            public bool apply_assignment_group_weights { get; set; }
            public Calendar calendar { get; set; }
            public string time_zone { get; set; }
            public Enrollment[] enrollments { get; set; }
            public bool hide_final_grades { get; set; }
            public string workflow_state { get; set; }
            public bool restrict_enrollments_to_course_dates { get; set; }
        }

         class Calendar
        {
            public string ics { get; set; }
        }

         class Enrollment
        {
            public string type { get; set; }
            public string role { get; set; }
            public int role_id { get; set; }
            public int user_id { get; set; }
            public string enrollment_state { get; set; }
        }

        class Teacher
        {
            public int id { get; set; }
            public string html_url { get; set; }
        }

        static void Main(string[] args)
        {
            Context context = Storage.Context.GetInstance();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://eaaa.instructure.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "10913~3HyrxzKtnT5wetg9Ja2jjZ50af5IDtOjHJgpYz21buCGK5xU1pYE9vBTLkYYms1s");

                Console.WriteLine("Loading all courses from " + client.BaseAddress);
                var response = client.GetAsync("/api/v1/courses?include=teachers").Result.Content.ReadAsAsync<Course[]>();
                
                foreach (Course c in response.Result)
                {
                    ClassLibrary.Model.Course currCourse = new ClassLibrary.Model.Course(c.name);
                     Console.WriteLine($"Fetching {c.name}");
                     var res = client.GetAsync($"/api/v1/courses/{c.id}/students").Result.Content.ReadAsAsync<User[]>();
                     if(context.GetCourseByName(currCourse.Name) == null)
                     {
                        string placeholderName = "teacher" + c.Teachers[0].id;
                        if (context.GetUserByUsername(placeholderName) == null)
                        {
                            context.AddTeacher(new ClassLibrary.Model.Teacher() { FullName = placeholderName, Username = placeholderName });
                        }

                        context.AddCourse(currCourse, context.GetTeacherByUsername(placeholderName));
                     }
                     
                     // Get kalender pr kursus
                     /*
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(c.calendar.ics);
                    myRequest.Method = "GET";
                    WebResponse myResponse = myRequest.GetResponse();
                    StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    string result = sr.ReadToEnd();
                    sr.Close();
                    myResponse.Close();
                    Console.WriteLine(result); 
                    */ 


                    foreach (User u in res.Result)
                     {
                        string placeholderName = "student" + u.id;
                        ClassLibrary.Model.Student currStudent = new Student() { FullName = u.name, Username = placeholderName };
                        
                        if (context.GetUserByUsername(placeholderName) == null)
                        {
                            context.AddStudent(currStudent);
                            
                        }

                        currStudent = context.GetStudentByUsername(placeholderName);
                        if (!currCourse.Students.Contains(currStudent))
                        {
                            context.EnrollStudent(context.GetCourseByName(currCourse.Name), context.GetStudentByUsername(placeholderName));
                        }    
                    }
                }
                Console.WriteLine($"Fetching from {client.BaseAddress} completed succesfully");
                Console.Read();
            }
        }
    }
}
