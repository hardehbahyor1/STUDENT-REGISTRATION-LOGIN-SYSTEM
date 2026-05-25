using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.UTILITIES;
using System;
using System.Collections.Generic;
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

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for Student_Dashboard.xaml
    /// </summary>
    public partial class Student_Dashboard : Page
    {
        private StudentInfo _currentUser;
        public Student_Dashboard(StudentInfo user)
        {
            InitializeComponent();
            _currentUser = user;

            TxtWelcome.Text = $"Welcome, {_currentUser.Fname} (ID: {_currentUser.Stdnt_ID}) Nationality: {_currentUser.Country}";

            MainContentFrame.Content = new UC_UpdateBiodata(_currentUser); // the default page that will be shown when the dashboard loads
        } // Overloaded constructor to accept a StudentInfo object, allowing personalized content based on the logged-in user

      /*  
        private void ShowwelcomeMessage()
        {
            var user = UserSession._CurrentUser();

            if (user != null)
            {
                TxtWelcome.Text = $"Welcome, {user.FirstName}";

                TxtUserDetails.Text =
                    $"ID: {user.StudentID} | DOB: {user.DateOfBirth} | Nationality: {user.Nationality}";
            }

        }*/
        private void Btn_UpdateBiodata_Click(object sender, RoutedEventArgs e)
        {
            UC_UpdateBiodata ViewBiodata = new UC_UpdateBiodata(); // Create an instance of the UC_UpdateBiodata user control
            MainContentFrame.Content = ViewBiodata; // Set the content of the MainContentFrame to the UC_UpdateBiodata user control

        }

        private void Btn_RegisterCourse_Click(object sender, RoutedEventArgs e)
        {
            UC_RegisterCourse viewCourse = new UC_RegisterCourse(_currentUser);
            string title = "Course Registration";
            string message = "Course registration is currently unavailable. Please check back later.";
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                //MainContentFrame = new UC_RegisterCourse();
                MainContentFrame.Content = viewCourse;
            }
        }

        private void Btn_ViewResults_Click(object sender, RoutedEventArgs e)
        {
            UC_CheckResult viewResult = new UC_CheckResult();

            MainContentFrame.Content = viewResult;
        }

        private void Btn_Hostel_Click(object sender, RoutedEventArgs e)
        {
            UC_Hostel viewHostel = new UC_Hostel();

            string message = "Hostel facilities are currently unavailable. Please check back later.";
            string title = "Hostel Information";
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                MainContentFrame.Content = viewHostel;
            }
        }

        private void Btn_changePsswd_Click(object sender, RoutedEventArgs e)
        {
            UC_ChangePsswd viewChangePsswd = new UC_ChangePsswd();
            MainContentFrame.Content = viewChangePsswd;
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            UC_Logout viewLogout = new UC_Logout();
            MainContentFrame.Content = viewLogout;
        }
    }
}