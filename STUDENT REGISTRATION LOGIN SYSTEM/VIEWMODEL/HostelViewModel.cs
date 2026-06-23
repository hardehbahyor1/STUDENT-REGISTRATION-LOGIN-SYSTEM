using STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL
{
    public class HostelViewModel : INotifyPropertyChanged
    {
        public string HostelType { get; set;  } //Male / Female Hostel
        public string StudentGender { get; set; } //Male / Female
        public List<string> Blocks { get; set; } // Block A, Block B etc...

        //private Dictionary<String, String> Gender = new Dictionary<string, string>();
        private Dictionary<string, List<string>> HostelGender;
        public List<string> HostelName { get; set; }

        public HostelViewModel()
        {
            LoadHostel();
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void LoadHostel() 
        {
            HostelGender = new Dictionary<string, List<string>>()
            {
                {"FEMALE", new List<string>
                    { "DEBORAH HALL", "ELIZABETH HALL", "ESTHER HALL", "GRACE HALL", "RUTH HALL"}
                },

                { "MALE", new List<string>

                    { "DANIEL HALL", "DAVID HALL", "JOSEPH HALL", "JONATHAN HALL", "WISDOM HALL"}
                }
            };            
        }
        public void LoadHostelByGender(string gender)
        {
            HostelName = HostelGender[gender];
        }
    }

    internal class Block:HostelViewModel
    {
        string RoomNumber { get; set; } // Room1, Room2, etc..
        string BlockNumber { get; set; } // A1, A2, B2 etc..
    }
}
