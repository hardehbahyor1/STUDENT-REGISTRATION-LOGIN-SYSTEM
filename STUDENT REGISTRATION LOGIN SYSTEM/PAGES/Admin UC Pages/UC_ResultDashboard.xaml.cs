using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES.Admin_UC_Pages
{
    /// <summary>
    /// Interaction logic for UC_ResultDashboard.xaml
    /// </summary>
    public partial class UC_ResultDashboard : UserControl
    {
        private List<Subject_Score_Grade> currentResults = new();
        private StudentInfo currentStudent;
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

            if (studentID != null)
            {
                currentStudent = studentID;
                MessageBox.Show("Student record Found!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                //Display Student Information
                fname_txt.Text = studentID.Fname.ToString();
                Mname_txt.Text = studentID.Mname.ToString();
                Lname_txt.Text = studentID.Lname.ToString();
                dept_txt.Text = studentID.Stdnt_Department.ToString();
                class_txt.Text = studentID.Stdnt_Class.ToString();

                if (studentID.Student_Results != null &&
                    studentID.Student_Results.Count > 0)
                {
                    // Student already has saved results
                    currentResults = studentID.Student_Results;
                }
                else
                {
                    // First time entering results
                    currentResults = studentID.Courses
                        .Select(course => new Subject_Score_Grade
                        {
                            SubjectName = course,
                            Score = 0,
                            Grade = "",
                            Remark = ""
                        })
                        .ToList();
                }
                subjectScore_datagrid.ItemsSource = currentResults;
            }
        }
        public void OverallStudentPerformance()
        {
            double TotalScore;
            double AveScore;

            AveScore = 0;
            TotalScore = 0;

            AveScore = TotalScore / 9;
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            // Ensure a student has been selected
                if (currentStudent == null)
                {
                    MessageBox.Show("Please search and select a student first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            // Ensure there are results to save
            if (currentResults == null || currentResults.Count == 0)
            {
                MessageBox.Show("No result available to save.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (var subject in currentResults)
            {
                subject.ComputeGrade();
            }
            subjectScore_datagrid.Items.Refresh();
            currentStudent.Student_Results = currentResults;
            Database_ConnectionPort.UpdateStudent(currentStudent);

            subjectScore_datagrid.Items.Refresh();

            MessageBox.Show(
                "Student Result Saved Successfully.",
                "Success",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
