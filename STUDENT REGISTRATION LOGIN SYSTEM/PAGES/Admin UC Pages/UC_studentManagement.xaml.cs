using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES.Admin_UC_Pages
{
    /// <summary>
    /// Interaction logic for UC_studentManagement.xaml
    /// </summary>
    public partial class UC_studentManagement : UserControl
    {
        public UC_studentManagement()
        {
            InitializeComponent();
        }

        private void btn_NewStudent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UNDER DEVELOPMENT.... CHECK BACK LATER.", "Information", MessageBoxButton.OK, MessageBoxImage.Information); 
        }// to register new student(Navigate to the Student Reg Dashboard)

        private void btn_ListofStudent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UNDER DEVELOPMENT.... CHECK BACK LATER.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            var fetchlist = Database_ConnectionPort.LoadData();
            if(fetchlist != null)
            {
                MessageBox.Show("Connection Secured.", "Information", MessageBoxButton.OK, MessageBoxImage.Information );
            }
            else
            {
                MessageBox.Show("Connection Not Secured.", "Information", MessageBoxButton.RetryCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void btn_Editstudent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UNDER DEVELOPMENT.... CHECK BACK LATER.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_SearchStudent_Click(object sender, RoutedEventArgs e)
        {
            var fetchlist = Database_ConnectionPort.LoadData();
            if (fetchlist != null)
            {
                MessageBox.Show("Connection Secured.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                
                string Acceptinput = search_txtblock.Text;
                var stdnt = fetchlist.SingleOrDefault(s => s.Stdnt_ID == Acceptinput);
                if(stdnt != null)
                {
                    fname_txt.Text = stdnt.Fname;
                    Mname_txt.Text = stdnt.Mname;
                    Lname_txt.Text = stdnt.Lname;
                    gender_txt.Text = stdnt.Gender;
                    class_txt.Text = stdnt.Stdnt_Class;
                    department_txt.Text = stdnt.Stdnt_Department;
                    dob_txt.Text = stdnt.DateOfBirth.ToString();

                    parentname_txt.Text = stdnt.ParentFullName;
                    address_txt.Text = stdnt.ParentResidentialAddress;
                    mobile_txt.Text = stdnt.ParentMobile_No;
                    occupation_txt.Text = stdnt.ParentJobOccupation;

                    bloodtype_txt.Text = stdnt.StudentBloodGroup;
                    allergries_txt.Text = stdnt.StudentAllergies;
                }
                else
                {
                    MessageBox.Show("Record Not Found", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Connection Not Secured.", "Information", MessageBoxButton.RetryCancel, MessageBoxImage.Error);
                return;
            }
        }
    }
}
