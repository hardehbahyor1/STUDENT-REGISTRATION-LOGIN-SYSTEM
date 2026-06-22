using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.UTILITIES;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES
{
    public partial class Admin_Dashboard : Page
    {
        private Admininfo user;

        public Admin_Dashboard()
        {
            InitializeComponent();
            DataContext = new AdminViewmodel();
        }

        public Admin_Dashboard(Admininfo user)
        {
            this.user = user;
        }

        private void Btn_Submit_Admin_Login_Click(object sender, RoutedEventArgs e)
        {
            string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StaffList_DataBase.json");
            var Avm = DataContext as AdminViewmodel; //Avm = Admin Viewmodel
            var fetchdata = Database_ConnectionPort.RetrieveAdminData();

            string accept_Username = Txtbox_Admin_ID.Text;
            string accept_Password = PsswrdBox_Admin.Password;

            var user = fetchdata.SingleOrDefault(s=> s.Admin_ID_No == accept_Username && s.AdminPassword == accept_Password);

            if(string.IsNullOrEmpty(accept_Username) || string.IsNullOrEmpty(accept_Password))
            {
                MessageBox.Show("Ensure all fields are filled correctly.", "Information", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
                //MessageBox.Show()
            }
            else
            {
                if(user != null)
                {
                    MessageBox.Show("Login Successfull", "Message");
                    UserSession.Admin_SessionManager.ActiveAdminSessionManager(user);
                    NavigationService.Navigate(new AdministrationLandingPage ());
                }
                else
                {
                    MessageBox.Show("Invalid User-ID or Password", "Validation message",MessageBoxButton.RetryCancel,MessageBoxImage.Exclamation);
                }
            }
            if(Avm  == null || Avm.admin == null)
            {
                MessageBox.Show("Unexpected error. Please restart the application.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                return;
            }         
        }

        private void Btn_CreateAdmin_Account_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin_Create_Account());
        }

        private void Btn_Homepage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Homepage());
            //method to Navigate back to the App Landing Homepage
        }
    }
}
