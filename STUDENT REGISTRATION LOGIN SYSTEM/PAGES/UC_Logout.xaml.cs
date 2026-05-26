using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
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
            //MessageBox.Show("Under Development... \n check Back Later", "Information", MessageBoxButton.OK );
            currentuser = null;
            //currentuser.Stdnt_ID = null;
            //currentuser.Gender = null;
            //currentuser.Fname = null;
            
            LoginPage loginscreen = new LoginPage();
            loginscreen.NavigationService.Navigate(loginscreen(currentuser));

            //loginscreen.sh
            //NavigationService.Navigate(new LoginPage());
            this.Visibility= Visibility.Collapsed;
            
        }
    }
}
