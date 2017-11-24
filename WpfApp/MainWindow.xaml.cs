using Eksamen2017.Model;
using Eksamen2017.Storage;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Storage storage = new Storage();

        public MainWindow()
        {
            User temp = storage.getUserByUserName("user1");
            Console.WriteLine(temp.UserName);

            InitializeComponent();


        }
    }
}
