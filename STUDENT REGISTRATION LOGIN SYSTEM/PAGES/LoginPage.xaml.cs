using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;
using System.Windows.Navigation;
using System.Text.Json;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;


namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            DataContext = new StudentViewModel();
        }
        
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as StudentViewModel;
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentList.json");
            var retrievedInfo = Database_ConnectionPort.LoadData();
            
            string Accept_StdntID = Txtbox_studentID.Text;
            string Accept_Stdnt_Psswd =  PsswdBox_Studentpassword.Password;
            var user = retrievedInfo.SingleOrDefault(s => s.Stdnt_ID == Accept_StdntID && s.Stdnt_Password.ToString() == Accept_Stdnt_Psswd);

            // --- Validation Guard Clauses ---
            // Ensures all required student information is present before processing
            if (string.IsNullOrWhiteSpace(Accept_StdntID) || string.IsNullOrWhiteSpace(Accept_Stdnt_Psswd))
            {
                MessageBox.Show("Ensure all fields are filled correctly",
                    "Validation Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                if (user != null)
                {
                    MessageBox.Show("Login Successfull", "Message");
                    NavigationService.Navigate(new Student_Dashboard(user));
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Error Message", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                }
            }

            
            if (vm == null || vm.Student == null)
                {
                    MessageBox.Show("Unexpected error. Please restart the application.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                } // to avoid crashing if datacontext dosent exist
        }

        private void BtnNavigateToStudntRegPage_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new Registration());
        }// when clicked allows the user to navigate to the student reg dashboard to register an account

        private void BtnForget_Password_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Forget_Password_Page());
        }
    }
}
