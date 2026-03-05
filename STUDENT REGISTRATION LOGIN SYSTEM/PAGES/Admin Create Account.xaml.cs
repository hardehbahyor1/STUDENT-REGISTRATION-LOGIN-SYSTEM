using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Admin_Create_Account.xaml
    /// </summary>
    public partial class Admin_Create_Account : Page
    {
        public AdminViewmodel ViewModel { get; set; }
        public Admin_Create_Account()
        {
            InitializeComponent();
            ViewModel = new AdminViewmodel();
            DataContext = ViewModel;
        }

        private void BtnCreatAccount_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(ViewModel.Fname) ||
                string.IsNullOrWhiteSpace(ViewModel.Mname) ||
                string.IsNullOrWhiteSpace(ViewModel.Lname) ||
                string.IsNullOrWhiteSpace(ViewModel.Admin_Dept) ||
                string.IsNullOrWhiteSpace(ViewModel.Admin_Uname) ||
                string.IsNullOrWhiteSpace(ViewModel.Admin_Password)
              )
            {
                MessageBox.Show("Please ensure all fields are filled correctly",
                    "Incorrect Info",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                /*
                    MessageBox.Show($"Admin {ViewModel.Fname} saved!",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                */
                ViewModel.SaveAdminData(ViewModel);
            }
            
        }
    }
}