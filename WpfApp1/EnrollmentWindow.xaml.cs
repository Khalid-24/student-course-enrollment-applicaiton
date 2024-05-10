using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
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



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EnrollmentWindow.xaml
    /// </summary>
    public partial class EnrollmentWindow : Window
    {
        private SmsContext _dbContext;
        public List<Course> EnrolledCourses { get; set; }
        public string StudentId { get; set; }

        public EnrollmentWindow(string studentId)
        {
            InitializeComponent();
            _dbContext = new SmsContext();
            StudentId = studentId;
            LoadStudentInformation();
            LoadCourseDataGrid();
            LoadEnrolledCourses();
        }

        private void LoadEnrolledCourses()
        {
            var student = _dbContext.Students.Include(s => s.CourseCodes).FirstOrDefault(s => s.StudentId == StudentId);
            if (student != null)
            {
                EnrolledCourses = student.CourseCodes.ToList();
                EnrolledCoursesListBox.ItemsSource = EnrolledCourses;
            }
        }

        private void LoadStudentInformation()
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.StudentId == StudentId);
            if (student != null)
            {
                StudentIdTextBlock.Text = student.StudentId;
                FirstNameTextBlock.Text = student.FirstName;
                LastNameTextBlock.Text = student.LastName;
                ProgramTextBlock.Text = student.Program;
            }
        }

        private void LoadCourseDataGrid()
        {
            var courses = _dbContext.Courses.ToList();
            CourseDataGrid.ItemsSource = courses;
        }

        private void EnrollButton_Click(object sender, RoutedEventArgs e)
        {
            Course selectedCourse = CourseDataGrid.SelectedItem as Course;

            if (selectedCourse != null)
            {
                var student = _dbContext.Students.FirstOrDefault(s => s.StudentId == StudentId);

                if (student != null)
                {
                    HashSet<string> courseCodes = new HashSet<string>(student.CourseCodes.Select(c => c.CourseCode));

                    bool alreadyEnrolled = courseCodes.Contains(selectedCourse.CourseCode);

                    if (!alreadyEnrolled)
                    {
                        student.CourseCodes.Add(selectedCourse);
                        _dbContext.SaveChanges();

                        LoadCourseDataGrid();
                        LoadEnrolledCourses();

                        MessageBox.Show($"Successfully enrolled in {selectedCourse.CourseTitle} Course.");
                    }
                    else
                    {
                        MessageBox.Show($"You are already enrolled in {selectedCourse.CourseTitle} course.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid course to enroll into program.");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Course selectedCourse = CourseDataGrid.SelectedItem as Course;

            if (selectedCourse != null)
            {
                var student = _dbContext.Students.Include(s => s.CourseCodes).FirstOrDefault(s => s.StudentId == StudentId);

                if (student != null)
                {
                    bool enrolledInSelectedCourse = student.CourseCodes.Any(c => c.CourseCode == selectedCourse.CourseCode);

                    if (enrolledInSelectedCourse)
                    {
                        var enrolledCourse = student.CourseCodes.FirstOrDefault(c => c.CourseCode == selectedCourse.CourseCode);

                        if (enrolledCourse != null)
                        {
                            student.CourseCodes.Remove(enrolledCourse);
                            _dbContext.SaveChanges();

                            LoadCourseDataGrid();
                            LoadEnrolledCourses();

                            MessageBox.Show($"Enrollment for {selectedCourse.CourseTitle} course has been removed successfully.");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"You are not enrolled in {selectedCourse.CourseTitle}.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid course to remove enrollment.");
            }
        }
    }
}
