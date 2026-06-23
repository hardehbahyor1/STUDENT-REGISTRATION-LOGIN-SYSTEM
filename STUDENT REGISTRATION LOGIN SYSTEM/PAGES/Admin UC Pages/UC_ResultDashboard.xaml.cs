using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES.Admin_UC_Pages
{
    /// <summary>
    /// Interaction logic for UC_ResultDashboard.xaml
    /// </summary>
    public partial class UC_ResultDashboard : UserControl
    {
        public UC_ResultDashboard()
        {
            InitializeComponent();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            string AcceptUItext = string.Empty;
            AcceptUItext = searchID_txt.Text.ToString();

            var fetchdata = Database_ConnectionPort.LoadData();
            var studentID = fetchdata.SingleOrDefault(s => s.Stdnt_ID == AcceptUItext);
            if(studentID != null)
            {
                MessageBox.Show("Student record Found!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                fname_txt.Text = studentID.Fname.ToString();
                Mname_txt.Text = studentID.Mname.ToString();
                Lname_txt.Text = studentID.Lname.ToString();
                dept_txt.Text = studentID.Stdnt_Department.ToString();
                class_txt.Text = studentID.Stdnt_Class.ToString();

                 List<Subject_Score_Grade> result = studentID.Courses.Select(course=> new Subject_Score_Grade
                 {
                     SubjectName = course,
                     Score = 0,
                     Grade = ""
                 }).ToList();

                subjectScore_datagrid.ItemsSource = result;
            }
            else
            {
                MessageBox.Show("Student Record Not Found", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UNDER DEVELOPMENT, CHECK BACK LATER.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
