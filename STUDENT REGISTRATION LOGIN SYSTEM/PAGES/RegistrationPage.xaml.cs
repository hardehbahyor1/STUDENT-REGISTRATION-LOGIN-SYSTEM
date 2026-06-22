using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;


namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        
        Dictionary<string, List<string>> countryStates; // key & content
        Dictionary<string, List<string>> stateLGA;
        public Registration()
        {
            InitializeComponent();
            //DataContext = App.StdntViewModel; //data_context
            DataContext = new StudentViewModel();

            LoadCOuntryStateData();
            LoadStateLGAData();


            CountryComboBox.ItemsSource = countryStates.Keys;
            StateComboBox.IsEnabled = false;
            LGAComboBox.IsEnabled = false;
        }// constructor

        //DATA SAVING CASE SENSITIVITY HANDLER
        public string ToProperCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        //COUNTRY & STATE DICTIONARY DEFEINITION
        private void LoadCOuntryStateData()
        {
            countryStates = new Dictionary<string, List<string>>
            {
                { "NIGERIA", new List<string> { "OYO", "OSUN", "EKITI", "KWARA", "ONDO" } },
                { "INDIA",new List<string> { "MAHARASTRA", "HYDRABAD", "NEW DELHI" } },
                { "UNITED KINGDOM", new List<string> { "ENGLAND", "SCOTLAND", "WALES" } },
                { "UNITED STATES", new List<string> {"CALIFORNIA", "TEXAS", "NEW YORK"} },
                { "CANADA", new List<string> { "BRITISH COLUMBIA", "ALBERTA", "ONTARIO" } },
                { "SOUTH AFRICA", new List<string> { "GAUTENG", "JOHNESBURG" } },
            };
        }

        //LGA DICTIONARY DEFEINITION
        private void LoadStateLGAData()
        {
            stateLGA = new Dictionary<string, List<string>>
            {
                {"OYO", new List<string> {"OYO EAST", "OYO WEST", "ATIBA", "AFIJIO", "EGBEDA" } },
                {"OSUN", new List<string>{"OSOGBO", "IFE", "ILESHA", "IKIRE", "IKIRUN"} },
                {"KWARA", new List<string> {"EKITI", "OKE ERO", "ILORIN WEST", "ILORIN EAST", "BARUTEN", "PATIGI", "OFFA"} },
                {"EKITI", new List<string>{"ADO EKITI", "OYE EKITI", "OSI EKITI", "IYUN EKITI", "IKOLE EKITI"} },
                {"ONDO", new List<string>{"ONDO WEST", "OWO", "IDANRE", "AKURE SOUTH", "AKOKO NORTH-WEST"} },
            };
        }
       // Dictionary<string, List<string>> department;
        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CountryComboBox.SelectedItem == null)
                return;

            string selectedCountry = CountryComboBox.SelectedItem.ToString(); // create a string variabe and assign the comboBox object selected to it in form of a string()

            if (countryStates.ContainsKey(selectedCountry))
            {
                StateComboBox.ItemsSource = countryStates[selectedCountry];
                StateComboBox.IsEnabled = true;
                StateComboBox.SelectedIndex = -1;   // Reset state selection

                LGAComboBox.ItemsSource = null;
                LGAComboBox.IsEnabled = false;
            }
        }

        private void StateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StateComboBox.SelectedItem == null)
                return;

            string selectedState = StateComboBox.SelectedItem.ToString();

            if(stateLGA.ContainsKey(selectedState))
            {
                LGAComboBox.ItemsSource= stateLGA[selectedState];
                LGAComboBox.IsEnabled = true;
               // StateComboBox.SelectedIndex = -1;   // Reset state selection
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as StudentViewModel;

            if (vm == null)
            {
                MessageBox.Show("ViewModel not found");
                return;
            }

            if (vm.Student == null)
            {
                MessageBox.Show("Student object is null");
                return;
            }
            
            bool isDOBInvalid = vm.Student.DateOfBirth == null || vm.Student.DateOfBirth >= DateTime.Today; //verify DOB
            // --- Validation Guard Clauses ---
            // Ensures all required student information is present before processing

            if (string.IsNullOrWhiteSpace(vm.Student.Fname) ||
                string.IsNullOrWhiteSpace(vm.Student.Mname) ||
                string.IsNullOrWhiteSpace(vm.Student.Lname) || 
                string.IsNullOrWhiteSpace(vm.Student.Residential_Address) ||
                string.IsNullOrWhiteSpace(vm.Student.Gender) ||
                string.IsNullOrEmpty(vm.Student.PhoneNUmber) ||
                string.IsNullOrWhiteSpace(vm.Student.Email) ||
                isDOBInvalid
            )                
            {
                MessageBox.Show("Please ensure all fields are filled. Make sure the Date of Birth is valid!",
                        "Missing Information",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                return;
            } 
            vm.GenerateStudentCredentials();

            vm.Student.Fname = ToProperCase(vm.Student.Fname);
            vm.Student.Mname = ToProperCase(vm.Student.Mname);
            vm.Student.Lname = ToProperCase(vm.Student.Lname);
            vm.Student.Email = vm.Student.Email?.ToLower();
            vm.Student.Gender = vm.Student.Gender?.ToUpper();

            string Name = $"{vm.Student.Fname} {vm.Student.Mname} {vm.Student.Lname}";

            Database_ConnectionPort.SaveData(vm.Student);
            MessageBox.Show(
                $"Registration Successful...... \n " +
                $"NAME: {Name} \n" +
                $"Your Login Credentials is \n " +
                $"USER_ID:{vm.Student.Stdnt_ID} \n " +
                $"PASSWORD: {vm.Student.Stdnt_Password} \n"
            );
            this.NavigationService.Navigate(new Homepage());
        }

        private void Btn_Homepage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Homepage());
        }
    }
}
