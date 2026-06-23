using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.UTILITIES;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES.Admin_UC_Pages
{
    /// <summary>
    /// Interaction logic for UC_staffManagement.xaml
    /// </summary>
    public partial class UC_staffManagement : UserControl, INotifyPropertyChanged
    {
        Admininfo user { get; set; }
        private int TotalStaff;
        private int MaleStaff;
        private int FemaleStaff;
        private int DegreeStaff;
        private int MscStaff;
        private int PhdStaff;
        private int ICTstaff;
        private int TeachingStaff;
        private int AdministrativeStaff;
        List<Admininfo> StaffCount =Database_ConnectionPort.RetrieveAdminData();// Staff Dashboard Count Analysis

        //this class properties were used to StaffCount Logic applying encapsulation(data hiding)
        public int TotalStaffCount
        {
            get => TotalStaff;
            set
            {
                TotalStaff = value;
                OnpropertyChanged();
            }
        }
        public int MaleStaffCount
        {
            get => MaleStaff;
            set
            {
                if (MaleStaff != value)
                {
                    MaleStaff = value;
                    OnpropertyChanged();
                }
            }
        }

        public int FemaleStaffCOunt
        {
            get => FemaleStaff;
            set
            {
                if (FemaleStaff!= value)
                {
                    FemaleStaff = value;
                    OnpropertyChanged();
                }
            }
        }
        public int StaffwithDegree
        {
            get => DegreeStaff;
            set
            {
                if (DegreeStaff != value)
                {
                    DegreeStaff = value;
                    OnpropertyChanged();
                }
            }
        }
        public int StaffwithMasters
        {
            get => MscStaff;
            set
            {
                if (MscStaff != value)
                {
                    MscStaff = value;
                    OnpropertyChanged();
                }
            }
        }
        public int StaffwithPhd
        {
            get => PhdStaff;
            set
            {
                if (PhdStaff != value)
                {
                    PhdStaff = value;
                    OnpropertyChanged();
                }
            }
        }
        public int ICT_StaffCOunt
        {
            get => ICTstaff;
            set
            {
                if (ICTstaff != value)
                {
                    ICTstaff = value;
                    OnpropertyChanged();
                }
            }
        }
        public int Teacher
        {
            get => TeachingStaff;
            set
            {
                if (TeachingStaff != value)
                {
                    TeachingStaff = value;
                    OnpropertyChanged();
                }
            }
        }
        public int AdministrativeStaff_Count
        {
            get => AdministrativeStaff;
            set
            {
                if (AdministrativeStaff != value)
                {
                    AdministrativeStaff = value;
                    OnpropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged; //Inotify Property Implementation
        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UC_staffManagement()
        {
            InitializeComponent();
            DashboardAnalysisChart();
            var LoggedInuser = UserSession.Admin_SessionManager.CurrentAdminUser;
            user = LoggedInuser;
        }

        //SEARCH LOGIC DEFINITION
        private async void  Btn_search_Click(object sender, RoutedEventArgs e)
        {
            searchProgressbar.Visibility = Visibility.Visible;
            await Task.Delay(10000);

            string SearchtaffID;
            var allstaff = Database_ConnectionPort.RetrieveAdminData();
            if(allstaff == null)
            {
                MessageBox.Show("Error Connecting with Database", "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SearchtaffID = Txtbox_Search_StaffID.Text; //assign the UI identifier
            if (string.IsNullOrWhiteSpace(SearchtaffID))
            {
                MessageBox.Show("Please enter a Staff ID to search.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }//Data Input verifiction Logic
            var staffinfo = allstaff.FirstOrDefault(s => s.Admin_ID_No == SearchtaffID);

            MessageBox.Show($"Staff is valid {staffinfo.AdminFirstName}");

            txtStaff_ID.Text = staffinfo.Admin_ID_No;
            txtStaffname.Text = staffinfo.AdminFirstName + " " + staffinfo.AdminMiddlename + " " + staffinfo.AdminLastName.ToUpper();
            txtStaffGender.Text = staffinfo.AdminGender;
            txtStaffMaritalStatus.Text = staffinfo.AdminMaritalStatus ;
            txtStaffAddress.Text =staffinfo.Admin_ResidentialAddress;
            txtStaffNationality.Text =staffinfo.AdminCountry ;
            txtStaffState.Text = staffinfo.AdminState;
            txtStaffLGA.Text = staffinfo.AdminLGA ;
            txtStaffMobile.Text = staffinfo.AdminMobile_No;
            txtStaffDept.Text = staffinfo.AdminDept;
            txtStaffEmploymenttype.Text = staffinfo.employmentType ;
            txtQualification.Text = staffinfo.AdminQualification;
            txtYearofEmployment.Text = staffinfo.Admin_DateEmployed.ToString() ;

            searchProgressbar.Visibility = Visibility.Collapsed;
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Check Back Later", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Btn_staffList_Click(object sender, RoutedEventArgs e)
        {

            var retrievedlist = Database_ConnectionPort.RetrieveAdminData();
            if (retrievedlist == null)
            {
                MessageBox.Show("No Staff Found", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            StafflistDatagrid.ItemsSource = retrievedlist;
            StafflistDatagrid.Visibility = Visibility.Visible;
        }

        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Check Back Later", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Btn_showProfile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Check Back Later", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void DashboardAnalysisChart()
        {
            ObservableCollection<Admininfo> analysis = new ObservableCollection<Admininfo>();
            txtTotalStaff.Text = StaffCount.Count.ToString();
            txtmaleStaff.Text = StaffCount.Count(x => x.AdminGender == "MALE").ToString();
            txtfemaleStaff.Text = StaffCount.Count(x => x.AdminGender == "FEMALE").ToString();
            txtDegreeStaff.Text = StaffCount.Count(x => x.AdminQualification == "B.Sc / B.Ed B.A").ToString();
            txtMScStaff.Text = StaffCount.Count(x=> x.AdminQualification == "M.Sc/ M.Ed / M.A"). ToString();
            txtPhdStaff.Text = StaffCount.Count(x=> x.AdminQualification == "Ph.D"). ToString();
            txtICTStaff.Text = StaffCount.Count(x=> x.AdminDept == "ICT").ToString();
            txtadminStaff.Text = StaffCount.Count(x => x.AdminDept == "ADMIN").ToString();
            txtteacherStaff.Text = StaffCount.Count(x=> x.AdminROle ==  "TUTOR"). ToString();
        } // called from the constructor for Constant Automatic execution.
    }   
}