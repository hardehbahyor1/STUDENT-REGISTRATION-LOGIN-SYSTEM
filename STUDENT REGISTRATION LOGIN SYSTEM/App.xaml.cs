using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System.Configuration;
using System.Data;
using System.Windows;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static StudentViewModel StdntViewModel {  get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StdntViewModel = new StudentViewModel();
        }
    }

}
