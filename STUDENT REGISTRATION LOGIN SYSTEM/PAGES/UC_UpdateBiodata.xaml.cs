using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Linq;
using Path = System.IO.Path;
using System.Text.Json;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.UTILITIES;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for UC_UpdateBiodata.xaml
    /// </summary>
    public partial class UC_UpdateBiodata : UserControl
    {
        
        private StudentInfo currentUser;
        
        private StudentViewModel vm;
        Dictionary<string, string> name = new Dictionary<string, string>();
        public UC_UpdateBiodata()
        {
            InitializeComponent();

            var user = UserSession.CurrentUser;
            
            vm = new StudentViewModel();
            vm.Student = user;
            DataContext = vm;
        }

    /*    public UC_UpdateBiodata(StudentInfo currentUser)
            {
                InitializeComponent(); //It tells WPF to draw the UI elements.
                //var user = UserSession._currentUser;
                this.currentUser = user;
                vm = new StudentViewModel();
                vm.Student = currentUser;
                DataContext = vm;
            }
    */
        private static readonly string databaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentList.json");
        public string ToProperCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void BtnSaveBioData_Click_1(object sender, RoutedEventArgs e)
        {
            if (vm == null)
            {
                MessageBox.Show("Error establishing data context.", "Error !", MessageBoxButton.RetryCancel, MessageBoxImage.Error);
                return;
            }

            if (vm.Student == null)
            {
                MessageBox.Show("Student object is null");
                return;
            }

            if (string.IsNullOrWhiteSpace(vm.Student.ParentFullName) ||
                string.IsNullOrWhiteSpace(vm.Student.parentCity) ||
                string.IsNullOrWhiteSpace(vm.Student.ParentJobOccupation) ||
                string.IsNullOrWhiteSpace(vm.Student.ParentMobile_No) ||
                string.IsNullOrWhiteSpace(vm.Student.ParentResidentialAddress) ||

                string.IsNullOrWhiteSpace(vm.Student.StudentBloodGroup) ||
                string.IsNullOrWhiteSpace(vm.Student.StudentAllergies) ||

                string.IsNullOrWhiteSpace(vm.Student.Stdnt_Department) ||
                string.IsNullOrWhiteSpace(vm.Student.Stdnt_Class))
            {
                MessageBox.Show("Please ensure all fields are filled.",
                        "Missing Information",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                return;
            }

            if (!File.Exists(databaseDir)){
                MessageBox.Show("Error Establishing Connection with the Database, \n Database file not found.", "Error !", MessageBoxButton.RetryCancel, MessageBoxImage.Error);
                return;
            }

            var DatabaseInfo = File.ReadAllText(databaseDir);
            var student = JsonSerializer.Deserialize<List <StudentInfo>>(DatabaseInfo) ?? new List<StudentInfo>();

            string targetStudentId = vm.Student?.Stdnt_ID ?? this.currentUser?.Stdnt_ID;

            if (string.IsNullOrWhiteSpace(targetStudentId))
            {
                MessageBox.Show("Cannot update: We lost track of the Student ID.", "Missing ID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingStudent = student.FirstOrDefault(s => s.Stdnt_ID == targetStudentId);
            if (existingStudent == null)
            {
                MessageBox.Show("Student not found.");
                return;
            }

            existingStudent.Stdnt_Department = vm.Student.Stdnt_Department;
            existingStudent.Stdnt_Class = vm.Student.Stdnt_Class;

            existingStudent.ParentFullName = ToProperCase(vm.Student.ParentFullName);
            existingStudent.parentCity = ToProperCase(vm.Student.parentCity);
            existingStudent.ParentJobOccupation = ToProperCase(vm.Student.ParentJobOccupation);
            existingStudent.ParentMobile_No = vm.Student.ParentMobile_No;
            existingStudent.ParentResidentialAddress = ToProperCase( vm.Student.ParentResidentialAddress);

            existingStudent.StudentBloodGroup = vm.Student.StudentBloodGroup;
            existingStudent.StudentAllergies = ToProperCase(vm.Student.StudentAllergies);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var updatedJson = JsonSerializer.Serialize(student, options);
            File.WriteAllText(databaseDir, updatedJson);

            string response = "BIO_DATA Updated SUccessfully";
            MessageBox.Show(response, "Success !", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
        }
    }
}