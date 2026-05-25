using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for Admin_Dashboard.xaml
    /// </summary>
    public partial class Admin_Dashboard : Page
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Admin_Login_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"UNDER DEVELOPMENT \n",
                "CHECK BACK LATER",
                MessageBoxButton.OK,
                MessageBoxImage.Error                
                );
        }

        private void Btn_CreateAdmin_Account_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin_Create_Account());
        }
    }
}
