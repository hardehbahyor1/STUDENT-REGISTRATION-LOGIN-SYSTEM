using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.UTILITIES;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for UC_Logout.xaml
    /// </summary>
    public partial class UC_Logout : UserControl
    {
        private StudentViewModel vm;
        private StudentInfo currentuser;
        public UC_Logout()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            UserSession.LogoutSession();
            LoginPage page = new LoginPage();

            var window =(MainWindow)Application.Current.MainWindow;
            window.MainFrame.Navigate(page);
        }
    }
}
