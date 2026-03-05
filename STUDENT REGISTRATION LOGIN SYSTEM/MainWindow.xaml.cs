//PROJECT: STUDENT REGISTRATION & LOGIN SYSTEM
//DEVELOPED BY: REHOBOTH TECHNOLOGIES INC
//AUTHOR: BOLUWATIFE OLUMIDE ADEBAYO
//YEAR: JAN,2026

using STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Homepage()); //Mainframe is the UI frame holder name in xaml            
        }
    }
}