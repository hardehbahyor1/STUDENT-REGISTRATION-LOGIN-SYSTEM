using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for Forget_Password_Page.xaml
    /// </summary>
    public partial class Forget_Password_Page : Page
    {
        public Forget_Password_Page()
        {
            InitializeComponent();
            DataContext = new StudentViewModel();
        }

         
        private void BtnVerify_Click(object sender, RoutedEventArgs e)
        {
            string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentList.json");
            var retrievedInfo = Database_ConnectionPort.LoadData(); // deserailzation occurs here

            string Accept_ID = Txtbox_Retrieve_studentID.Text;
            var user = retrievedInfo.SingleOrDefault(s => s.Stdnt_ID == Accept_ID);

            // --- Validation Guard Clauses ---
            if (string.IsNullOrWhiteSpace(Accept_ID))
            {
                MessageBox.Show("Ensure the field is filled",
                    "Input Validation Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                if (user != null)
                {
                    MessageBox.Show($"Verification Successful \n PASSWORD: {user.Stdnt_Password}", 
                        "Infromation",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                        NavigationService.Navigate(new LoginPage());
                }
                else
                {

                    MessageBox.Show("Invalid STUDENt ID Try Again", "Error Message", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                }
            }
        }
    }
}
