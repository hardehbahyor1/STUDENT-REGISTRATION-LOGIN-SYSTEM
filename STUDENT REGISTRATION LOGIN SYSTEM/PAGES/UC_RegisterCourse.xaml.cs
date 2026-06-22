using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Runtime.CompilerServices;
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
using static System.Collections.Specialized.BitVector32;
using Path = System.IO.Path;
namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for UC_RegisterCourse.xaml
    /// </summary>
    public partial class UC_RegisterCourse : UserControl, INotifyPropertyChanged
    {
        private StudentViewModel vm;
        private StudentInfo currentuser;
        private int NumberOfRegisteredCourse;
        public int RegisteredCourse_Count
        {
            get => NumberOfRegisteredCourse;
            set
            {
                if(NumberOfRegisteredCourse != value)
                {
                    NumberOfRegisteredCourse= value;
                    OnpropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public UC_RegisterCourse()
        {
            InitializeComponent();
            vm = new StudentViewModel(); 
            DataContext = vm;

            SetSubjectRepository();
            
            //RegisterSubject();
        }

        public UC_RegisterCourse(StudentInfo student) : this() // reuse first constructor
        {
            currentuser = student;
            GetnumberofRegisteredCourses(); // get the total number of already registered courses.
            if (currentuser != null && currentuser.Courses != null && currentuser.Courses.Count > 0)
            {
                DisplayRegSubject_Listbox.ItemsSource = currentuser.Courses;
                DisplayRegSubject_Listbox.Visibility = Visibility.Visible;

                CourseListBox.Visibility = Visibility.Collapsed;

                BtnSubmitRegistration.Visibility = Visibility.Collapsed;
            }
            else
            {
                DisplayRegSubject_Listbox.Visibility= Visibility.Collapsed;
                CourseListBox.Visibility = Visibility.Visible;
                BtnSubmitRegistration.Visibility = Visibility.Visible;
            }
            //Connect_Dict_with_UI();
        }

        private Dictionary<string, List<string>> Senior_SecondarySubject; // = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> Junior_SecondarySubject; // = new Dictionary<string, List<string>>();

        private void SetSubjectRepository()
        {
            Senior_SecondarySubject = new Dictionary<string, List<string>>()
            {
                {"Science", new List<string>
                    {
                        "MATHEMATICS", "ENGLISH", "BIOLOGY", "PHYSICS", "CHEMISTRY", "AGRICULTURAL SCIENCE", "CIVIC EDUCATION", "GEOGRAPHY", "ECONOMICS", "FURTHER MATHEMATICS",
                        "TECHNICAL DRAWING", "DATA PROCESSING", "COMPUTER STUDIES", "LIVE STOCK FARMING", "FISHERY" }
                },

                { "Arts", new List<string>

                    {
                        "ENGLISH LANGUAGE", "MATHEMATICS", "GOVERNMENT", "LITERATURE-IN-ENGLISH", "HISTORY", "CRS", "IRS", "MUSIC", "FINE-ART", "YORUBA LANGUAGE",
                        "HAUSA LANGUAGE", "IGBO LANGUAGE", "CATERING CRAFT PRATICE", "FASHION DESIGNING", "DATA PROCESSING"
                    }
                },

                { "Commercial", new List<string>
                    { 
                        "ENGLISH LANGUAGE", "MATHEMATICS", "FINANCIAL ACCOUNTING", "ECONOMICS", "MARKETING", "COMMERCE", "CIVIC EDUCATION", "COMPUTER STUDIES", "DATA PROCESSING",
                        "CATERING CRAFT PRATICE", "FISHERY", 
                    }
                },
            };

            Junior_SecondarySubject = new Dictionary<string, List<string>>()
            {
                 {"Junior Secondary", new List<string>
                    {
                        "ENGLISH", "MATHEMATICS", "CIVIC EDUCATION", "BASIC TECHNOLOGY", "BASIC SCIENCE", "FRENCH", "YORUBA", "HAUSA LANGUAGE", "MUSIC", "COMPUTER STUDIES",
                        " CRS/IRS", "AGRICULTURAL SCIENCE", "SOCIAL STUDY", "HISTORY", "FINE ARTS", "TECHNICAL DRAWING", "DATA PROCESSING"
                    }
                }
            };

        }

        private void Connect_Dict_with_UI()
        {
            string department = currentuser?.Stdnt_Department ?? "Commercial";
            if (Senior_SecondarySubject.ContainsKey(department))
                {
                CourseListBox.ItemsSource = Senior_SecondarySubject[department];
                }
            else
            {
                CourseListBox.ItemsSource = Junior_SecondarySubject["Junior Secondary"];
            }
        }

        private List<string> GetSelectedSubjects()
        {
            List<string> selectedSubjects = new List<string>();

            foreach (var item in CourseListBox.Items)
            {
                var container = CourseListBox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;

                if (container != null)
                {
                    var checkBox = FindVisualChild<CheckBox>(container);

                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        selectedSubjects.Add(item.ToString());
                    }
                }
            }

            return selectedSubjects;
        }

        // 🔷 HELPER METHOD
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T correctlyTyped)
                    return correctlyTyped;

                var result = FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }

            return null;
        }


        private void RegisterSubject()
        {
            Database_ConnectionPort.LoadData();
            GetnumberofRegisteredCourses(); // get the number of courses REGISTRED which is displayed when user naviagte to the Register Course UI
            currentuser = Database_ConnectionPort.LoadData().Find(s =>s.Stdnt_ID == currentuser.Stdnt_ID); // Refresh current user data from database

            if (currentuser == null)
            {
                MessageBox.Show("Connection Error", "Session expired.Please login again.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            Connect_Dict_with_UI();
            var selectedSubjects = GetSelectedSubjects();

            if (selectedSubjects.Count < 6 || selectedSubjects.Count > 9)
            {
                MessageBox.Show("You must select between 6 and 9 subjects.");
                return;
            }

            // 🔥 SAVE TO USER
            currentuser.Courses = selectedSubjects;

            // 🔥 SAVE TO DATABASE
            Database_ConnectionPort.UpdateStudent(currentuser);

            MessageBox.Show("Course registration successful!");
        }

        //Get number of registered Courses and Return the Value to the UI
        private void GetnumberofRegisteredCourses()
        {
           if(currentuser != null && currentuser.Courses != null)
            {
                Count_RegisteredSubject_Txt.Text = currentuser.Courses.Count().ToString();
                MessageBox.Show($"Dear {currentuser.Fname} with Identity Number{currentuser.Stdnt_ID},\n" +
                    $"You've Registered your Preferred {currentuser.Courses.Count()} Subjects already.",
                    "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnSubmitRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegisterSubject();
        }

        private void CheckResult_btn_Click(object sender, RoutedEventArgs e)
        {
            UC_CheckResult page = new UC_CheckResult();
            var window = (MainWindow)Application.Current.MainWindow;
            window.MainFrame.Navigate(page);
        }
    }
}
