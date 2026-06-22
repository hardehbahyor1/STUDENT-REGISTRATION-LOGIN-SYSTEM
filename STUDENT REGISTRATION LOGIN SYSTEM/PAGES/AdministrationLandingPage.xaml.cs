using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES.Admin_UC_Pages;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.UTILITIES;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for AdministrationLandingPage.xaml
    /// </summary>
    public partial class AdministrationLandingPage : Page
    {
        private Admininfo user { get; set; }
        public AdministrationLandingPage()
        {
            InitializeComponent();
            var LoggedInuser = UserSession.Admin_SessionManager.CurrentAdminUser;
            user = LoggedInuser;
            if(LoggedInuser != null)
            {
                Txtblock_WelcomMssg.Text = $"Welcome, {user.Admin_ID_No}, {user.AdminROle.ToUpper()}, {user.AdminFirstName.ToUpper()} {user.AdminLastName}";
            }
            Admin_Landing_PageDashboard.Content = new UC_ResultDashboard();
        }

        private void Btn_Result_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UNDER DEVELOPMENT, CHECK BACK LATER.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            UC_ResultDashboard uC_Result = new UC_ResultDashboard();
            Admin_Landing_PageDashboard.Content = uC_Result;
        }

        private void Btn_courseReg_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UNDER DEVELOPMENT, CHECK BACK LATER.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
             UC_courseRegistration uC_Course = new UC_courseRegistration();
            Admin_Landing_PageDashboard.Content = uC_Course;
        }

        private void Btn_staffDashboard_Click(object sender, RoutedEventArgs e)
        {
            // Safety check: Ensure the session hasn't dropped
            if (user == null)
            {
                MessageBox.Show("Session expired. Please log in again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //MessageBox.Show("UNDER DEVELOPMENT, CHECK BACK LATER.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            var FetchData = Database_ConnectionPort.RetrieveAdminData();

            if (user.AdminROle.Equals("ICT ADMIN", StringComparison.CurrentCultureIgnoreCase))
            {
                UC_staffManagement uC_Staff = new UC_staffManagement();
                Admin_Landing_PageDashboard.Content = uC_Staff;
            }

            else
            {
                MessageBox.Show("ACCESS DENIED: You do not have the required permissions to view Staff Management.",
                    "Access Denied", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }     
        }

        private void Btn_studendDashboard_Click(object sender, RoutedEventArgs e)
        {
            // Safety check: Ensure the session hasn't dropped
            if (user == null)
            {
                MessageBox.Show("Session expired. Please log in again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (user.AdminROle == "ICT ADMIN")
            {
                MessageBox.Show("Access granted");
                UC_studentManagement uC_Student = new UC_studentManagement();
                Admin_Landing_PageDashboard.Content = uC_Student;
            }
            else
            {
                MessageBox.Show("ACCESS DENIED, You do not have the Permission Access", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            } 
        }

        private void Btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result= MessageBox.Show("DO you want to LOGOUT Your Account?", "Infomation", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if(result == MessageBoxResult.Yes)
            {
                UserSession.Admin_SessionManager.LogoutAdminSessionManager();

                NavigationService.Navigate(new Admin_Create_Account());
            }    
        }

        private void Btn_homepage_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Going back to the Home Page will log you out of your current session. Do You wish to Continue?",
                "Confirm Navigation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                UserSession.Admin_SessionManager.LogoutAdminSessionManager();
                NavigationService.Navigate(new LoginPage());
            }
        }
    }
}
