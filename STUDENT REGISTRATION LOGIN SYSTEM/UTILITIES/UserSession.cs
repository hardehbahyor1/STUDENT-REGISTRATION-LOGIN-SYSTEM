using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.UTILITIES
{
   
    public static class UserSession
    {
        public static StudentInfo CurrentUser { get; private set; } // or use  private static StudentInfo _Currentuser;  its still the same

        //public static string Name => _currentUser.Fname;
        //public static string Student_Id => _currentUser.Stdnt_ID;
        //public static string Gender => _currentUser.Gender;


        public static bool IsLogedgin => CurrentUser != null; //check if anyone login()
        public static void ActiveSession( StudentInfo user)
        {
                CurrentUser = user;
        }//Login Method Definition to be accessed Globally where needed
        public static void LogoutSession()
        {
            CurrentUser = null;
        }//Logout Method to be accessed Globally where needed


        // SESSION MANAGER LOGIN FOR ADMIN LOGIN& LOGOUT
        internal class Admin_SessionManager
        {
            public static Admininfo CurrentAdminUser { get; private set;  }
            public static bool isloggedin => CurrentUser != null;
            public static void ActiveAdminSessionManager( Admininfo user_Admin)
            {
                CurrentAdminUser = user_Admin;
            }

            public static void LogoutAdminSessionManager()
            {
                CurrentAdminUser = null;
            }
        }

    }
}
