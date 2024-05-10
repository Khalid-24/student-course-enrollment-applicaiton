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
 

