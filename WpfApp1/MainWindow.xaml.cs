using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using ClassLibrary1.Models; 


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    
    public partial class MainWindow : Window
    {
        private SmsContext _dbContext;
        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new SmsContext();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = loginControl.Username;
            string password = loginControl.Password;

            var user = _dbContext.Logins.FirstOrDefault(u => u.LoginName == username && u.Password == password);

            if (user != null)
            {
                var student = _dbContext.Students.FirstOrDefault(s => s.Login.LoginName == username);

                if (student != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    EnrollmentWindow enrollmentWindow = new EnrollmentWindow(student.StudentId);
                    enrollmentWindow.Show();
                }
                else
                {
                    MessageBox.Show("Student information not found. Please contact your administrator.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}