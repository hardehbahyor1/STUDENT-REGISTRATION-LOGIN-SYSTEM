using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            if (vm == null || vm.Student == null)
            {
                MessageBox.Show("Unexpected error. Please restart the application.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            } // to avoid crashing if datacontext dosent exist

            /*
             * 
             * vm.Student.Stdnt_Password = PsswdBox_Studentpassword.Password; 
            */

            // --- Validation Guard Clauses ---
            // Ensures all required student information is present before processing

            if (string.IsNullOrWhiteSpace(vm.Student.Stdnt_ID))
            {
                MessageBox.Show("Please ensure all fields are filled correctly",
                    "Incorrect Info",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Login successful", "Continue", MessageBoxButton.OK);
        }
    }
}
