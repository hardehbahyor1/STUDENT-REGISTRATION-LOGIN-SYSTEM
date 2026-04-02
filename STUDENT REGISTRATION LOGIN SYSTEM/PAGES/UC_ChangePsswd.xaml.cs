using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for UC_ChangePsswd.xaml
    /// </summary>
    public partial class UC_ChangePsswd : UserControl
    {

        private StudentInfo currentStdnt = null; // to hold the current login student infomation
        private bool isPsswdVerified = false;
        public UC_ChangePsswd()
        {
            InitializeComponent();
            DataContext = new StudentViewModel();
        }

        string AcceptCurrentPassword = string.Empty;
        string newPassword = string.Empty;
        private bool isPasswordVerified = false;
        //database connection setting
        readonly string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentList.Json");

        private void Btn_ConfirmPsswrd_Click(object sender, RoutedEventArgs e)
        {
            AcceptCurrentPassword = txtbx_CurrentPsswrd.Password;
           // newPassword = txtbx_NewPsswrd.Password;

            var RetrieveData = Database_ConnectionPort.LoadData();

            currentStdnt = RetrieveData.SingleOrDefault(s => s.Stdnt_Password.ToString() == AcceptCurrentPassword);

            if (string.IsNullOrWhiteSpace(AcceptCurrentPassword))
            {
                MessageBox.Show("Password cannot be empty", "Error Message", MessageBoxButton.RetryCancel, MessageBoxImage.Error);
                return;
            }
            if (currentStdnt.Stdnt_Password == AcceptCurrentPassword)
            {
                isPasswordVerified = true;
                MessageBox.Show($"Verification Successful", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                
                txtbx_NewPsswrd.IsEnabled= true; //Enable new password field
            }
            else
            {
                isPasswordVerified=false;
                MessageBox.Show("Current Password not Correct", "Error!", MessageBoxButton.RetryCancel, MessageBoxImage.Exclamation);
            }
        }

        private void Btn_SubmitNewPsswrd_Click(object sender, RoutedEventArgs e)
        {
            if (!isPasswordVerified)
            {
                MessageBox.Show("Please your Current Password first");
            }
            newPassword = txtbx_NewPsswrd.Password;
            var loadDatabase = Database_ConnectionPort.LoadData();
            var stdntToUpdate = loadDatabase.SingleOrDefault(s=> s.Stdnt_ID == currentStdnt.Stdnt_ID);
            
            if(stdntToUpdate!= null)
            {
                stdntToUpdate.Stdnt_Password = newPassword;
                string json = System.Text.Json.JsonSerializer.Serialize(loadDatabase, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                File.WriteAllText(filepath,json);
                MessageBox.Show("Password changed successfully!");

                isPasswordVerified = false; // reset
            }
        }
    }
}
