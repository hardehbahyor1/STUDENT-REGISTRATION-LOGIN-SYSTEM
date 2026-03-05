using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
            DataContext = App.StdntViewModel; //data_context
        }

        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void Btn_AdminLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin_Dashboard());
        }
    }
}
