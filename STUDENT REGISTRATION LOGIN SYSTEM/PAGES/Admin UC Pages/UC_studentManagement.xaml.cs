using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
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
    public partial class UC_studentManagement : UserControl, INotifyPropertyChanged
    {
        private int totalStudent;
        private int maleStudent;
        private int femaleStudent;
        private int jssStudent;
        private int sssStuden;
        private int sciStudent;
        private int artStudent;
        private int commercialStudent;

        private StudentInfo currentsudent; // to be used to assign searched student during hostel allocation

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Total
        {
            get => totalStudent;
            set
            {
                if(totalStudent!= value)
                {
                    totalStudent=value;
                    OnpropertyChanged();
                }
            }
        }
        public int Male
        {
            get => maleStudent;
            set
            {
                if (maleStudent != value)
                {
                    maleStudent  = value;
                    OnpropertyChanged();
                }
            }
        }
        public int Female
        {
            get => femaleStudent;
            set
            {
                if (femaleStudent != value)
                {
                    femaleStudent = value;
                    OnpropertyChanged();
                }
            }
        }
        public int Jss
        {
            get => jssStudent;
            set
            {
                if (jssStudent != value)
                {
                    jssStudent = value;
                    OnpropertyChanged();
                }
            }
        }
        public int Sss
        {
            get => sssStuden;
            set
            {
                if (sssStuden != value)
                {
                    sssStuden = value;
                    OnpropertyChanged();
                }
            }
        }
        public int Science
        {
            get => sciStudent;
            set
            {
                if (sciStudent != value)
                {
                    sciStudent = value;
                    OnpropertyChanged();
                }
            }
        }
        public int Commercial
        {
            get => commercialStudent;
            set
            {
                if (commercialStudent != value)
                {
                    commercialStudent = value;
                    OnpropertyChanged();
                }
            }
        }
        public int Arts
        {
            get => artStudent;
            set
            {
                if (artStudent != value)
                {
                    artStudent = value;
                    OnpropertyChanged();
                }
            }
        }
        public UC_studentManagement()
        {
            InitializeComponent();
            StudentDashboardAnalysis();
            StudentDashboardAnalysis(); // called twice for real-time update after updating / editing student record
            HostelAllocation_UI_Grid.Visibility = Visibility.Collapsed; // UI only visible if Student record does not return NULL
        }

        private void btn_NewStudent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UNDER DEVELOPMENT.... CHECK BACK LATER.", "Information", MessageBoxButton.OK, MessageBoxImage.Information); 
            //admin
        }// to register new student(Navigate to the Student Reg Dashboard)

        private void btn_ListofStudent_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("UNDER DEVELOPMENT.... CHECK BACK LATER.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            var fetchlist = Database_ConnectionPort.LoadData();
            if(fetchlist != null)
            {
                MessageBox.Show("Connection Secured/ Record Found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information );
                listofstudent_DataGrid.ItemsSource = fetchlist;
                listofstudent_DataGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Connection Not Secured or No Record Found.", "Information", MessageBoxButton.RetryCancel, MessageBoxImage.Error);
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
                   // List<StudentInfo> subject = new List<StudentInfo>();
                    //listofSubject_txt.ItemsSource = stdnt.Courses;
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

        public void StudentDashboardAnalysis()
        {
            List<StudentInfo> studentCount = Database_ConnectionPort.LoadData();
            int Sss1, Sss2, Sss3;

            totalStudent_txt.Text = studentCount.Count().ToString();
            maleStudent_txt.Text = studentCount.Count(x=> x.Gender == "MALE").ToString();
            femaleStudent_txt.Text = studentCount.Count(x => x.Gender == "FEMALE").ToString();
            jsStudent_txt.Text = studentCount.Count(x => x.Stdnt_Department == "Junior Secondary").ToString();
                Sss1 = studentCount.Count(x => x.Stdnt_Class == "SS 1");
                Sss2 = studentCount.Count(x=> x.Stdnt_Class == "SS 2");
                Sss3 = studentCount.Count(x=> x.Stdnt_Class == "SS 3");
                ss_Student_txt.Text = (Sss1 + Sss2 + Sss3).ToString();
            arts_Student_txt.Text = studentCount.Count(x => x.Stdnt_Department == "Arts").ToString();
            sciStudent_txt.Text = studentCount.Count(x => x.Stdnt_Department == "Science").ToString();
            commercial_Student_txt.Text = studentCount.Count(x => x.Stdnt_Department == "Commercial").ToString();
        }

        private void btn_allocateHostel_Click(object sender, RoutedEventArgs e)
        {
            if(currentsudent == null)
            {
                MessageBox.Show("Search for a student first.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(currentsudent.Hostelname))
            {
                MessageBox.Show($"Student is already allocated to {currentsudent.Hostelname}", 
                    "Information", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
                return;
            }// check if Hostel is not allocated already

            currentsudent.Hostelname = hostelNameCmb.Text.ToString();
            currentsudent.BedspaceNumber = bedSpacecmb.Text.ToString();
            currentsudent.Blocktype = blockType_cmb.Text.ToString();
            currentsudent.Roomnumber = roomNo_cmb.Text.ToString();

            if (string.IsNullOrWhiteSpace(hostelNameCmb.Text) || string.IsNullOrWhiteSpace(bedSpacecmb.Text) ||
                string.IsNullOrWhiteSpace(roomNo_cmb.Text))
            {
                MessageBox.Show("Ensure all Fields are filled correctly", "Information", MessageBoxButton.RetryCancel, MessageBoxImage.Information);
            }

            Database_ConnectionPort.UpdateStudent(currentsudent);
            MessageBox.Show("Hostel allocation successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Hostel Accomodation Development Logic. If Search Record is found, then the Collapsed UI will be Visible
        private void SearchID_btn_Click(object sender, RoutedEventArgs e)
        {
            var fetchInfo = Database_ConnectionPort.LoadData();
            string acceptInput = AcceptStudentID_txt.Text.ToString();
            var student = fetchInfo.SingleOrDefault(s => s.Stdnt_ID == acceptInput);
            if(student != null)
            {
                currentsudent = student;
                MessageBox.Show($"Record Found..... {student.Gender} Student Detected.", "Infomation", MessageBoxButton.OK, MessageBoxImage.Information);
                if(student.Gender == "FEMALE")
                {
                    MessageBox.Show("Student is FEMALE");
                    HostelAllocation_UI_Grid.Visibility = Visibility.Visible;
                    HostelViewModel hostel = new HostelViewModel();
                    hostel.LoadHostelByGender(student.Gender);
                    hostelNameCmb.ItemsSource = hostel.HostelName;

                    
                    return;
                }
                else if(student.Gender == "MALE")
                {
                    MessageBox.Show("Student is MALE");
                    HostelAllocation_UI_Grid.Visibility = Visibility.Visible;
                    HostelViewModel hostel = new HostelViewModel();
                    hostel.LoadHostelByGender(student.Gender);
                    hostelNameCmb.ItemsSource = hostel.HostelName;
                    return;
                }
                return;
                //var verifyGender = checkGender.SingleOrDefault(s => s.Gender == g) 
            }
            else
            {
                MessageBox.Show("Record not Found.", "Infomation", MessageBoxButton.RetryCancel, MessageBoxImage.Error);
                //HostelAllocation_UI_Grid.Visibility = Visibility.Collapsed;
                return;
            }
        }// used to search for the student before allocating an accomodation
    }
}
