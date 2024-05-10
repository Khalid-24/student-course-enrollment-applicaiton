# Student Management System (SMS) - WPF Application

This is a WPF application for managing student enrollments in courses. It allows students to login and enroll in available courses. This README provides an overview of the project setup and functionality.

## Setup Database

1. Download the SMS SQL script from the repository.
2. Open SQL Server Object Explorer in Visual Studio.
3. Right-click on the local DB server and choose "New Query".
4. Copy the contents of the SMS SQL file and paste them into the query window.
5. Run the SQL script to create the database with four tables: Course, Student, Login, and Enrollment.

## Running the Project

1. Install all the NuGet Packages required to set up the database using Entity Framework Core for a .NET application.
2. The required packages for **net 8.0 version** are **Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools**
3. Run the required command to create Model and DbContext classes automatically.
4. To run the command, go to Tools > Nuget Package Manager > Package Manger Console.
5. The command to run in the the console is, **Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB; database=SMS;Integrated Security=True" "Microsoft.EntityFrameworkCore.SqlServer" -o Models**. Change the connection source string in the command. You can get the connection string by going to SQL Server Object Explorer > SMS. Right cllick on SMS and go to properties, and copy the connection string and replace this part in the command "Data Source=(localdb)\MSSQLLocalDB; database=SMS;Integrated Security=True".
6. Rebuild the project and run.

## Features of the Application.

1. **User Authentication:** Users can log in with their username and password to access the application.
2. **Course Enrollment:** Users can enroll students in available courses.
3. **Database Integration:** The application is integrated with a SQL database to store and manage student, course, login, and enrollment data.
4. **UI Controls:** Various WPF UI controls such as TextBoxes, Labels, ComboBoxes, Buttons, ListBox, and DataGrid provide a user-friendly interface for managing student enrollments.
5. **Error Handling:** Error messages in dialogs inform users of incorrect actions, such as attempting to remove an enrollment without selecting a course or student.
6. **Dynamic Data Display:** The application dynamically updates the ListBox and DataGrid based on user selections to display relevant information about courses and enrolled students.
7. **Code Reusability:** A class library project is used for database operations, promoting code reusability and maintainability.
8. **NuGet Packages**: NuGet packages are used for setting up the database using Entity Framework Core, simplifying database integration.
9. **Modular Design:** Separate user controls for login and enrollment promote modularity and ease of maintenance.

## Student Login Information

These are default student login information used in the application. The login information can be found in the SQL file also.


**1. ('300111222','password') <br>
2. ('300222333','test') <br>
3. ('300333444','password') <br>
4. ('300444555','password')** <br>

## Screenshots of the application.

1. Login Page
   
![Screenshot 2024-05-09 222923](https://github.com/Khalid-24/student-course-enrollment-applicaiton/assets/145816901/fd278c3d-f183-46d8-b95a-536aebaded85)

2. Enrollment Page
   
![Screenshot 2024-05-09 223152](https://github.com/Khalid-24/student-course-enrollment-applicaiton/assets/145816901/fba73b7b-a769-48ec-a7bc-88da30886dc5)


 

