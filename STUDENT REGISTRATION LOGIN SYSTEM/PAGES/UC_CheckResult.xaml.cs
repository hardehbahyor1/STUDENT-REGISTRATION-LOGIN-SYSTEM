using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.UTILITIES;
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

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for UC_CheckResult.xaml
    /// </summary>
    public partial class UC_CheckResult : UserControl
    {
        public UC_CheckResult()
        {
            InitializeComponent();
            var user = UserSession.CurrentUser;

            MessageBox.Show("Under Development \n We're working on this Section, Check Back Later", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            var fecthdata = Database_ConnectionPort.LoadData();
            var info = fecthdata.SingleOrDefault(s => user.Stdnt_ID == s.Stdnt_ID);
            if(info != null)
            {
                StudentID_txtbox.Text = info.Stdnt_ID;
                string Getfullname = $"{info.Fname} {info.Mname} {info.Lname}";
                StudentName_txtbox.Text = Getfullname;
                StudentDept_txtbox.Text = info.Stdnt_Department;
                StudentClass_txtbox.Text = info.Stdnt_Class;
            }
            else
            {
                MessageBox.Show("Your result has not yet been published.", "Information", MessageBoxButton.RetryCancel, MessageBoxImage.Information);
            }

            //display result in UI Datagrid.
            //DisplayResult_DataGrid.ItemsSource = info;
            DisplayResult_DataGrid.ItemsSource = info.Student_Results; 

            //compute Result Analysis
            int Total_Registered_Course;
            double Average_Score;
            double Total_Score;
            string Remark;

            Total_Registered_Course = info.Courses.Count();
            Average_Score = info.Student_Results.Average(r => r.Score); //Average_Score = info.Student_Results.Count / Total_Registered_Course;
            Total_Score = info.Student_Results.Sum(r => r.Score);

            if(Average_Score >= 70)
            {
                Remark = "Excellent";
            }
            else if(Average_Score >=60)
            {
                Remark = "Very Good";
            }
            else if (Average_Score >= 50)
            {
                Remark = "Good";
            }
            else if (Average_Score >= 40)
            {
                Remark = "Pass";
            }
            else if (Average_Score >= 30)
            {
                Remark = "Poor";
            }
            else
            {
                Remark = "Fail";
            }
            //Link to UI
            totalCourse_txt.Text = Total_Registered_Course.ToString();
            AverageScore_txt.Text = Average_Score.ToString();
            totalScore_txt.Text = Total_Score.ToString();
            Overallremark_txt.Text = Remark;
        }
    }
}
