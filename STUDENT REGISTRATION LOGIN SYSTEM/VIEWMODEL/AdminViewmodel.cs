using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL
{
    // Pseudocode / Plan:
    // 1. Read existing file "AdminDataBase.json" if it exists.
    // 2. If file contains JSON, attempt to deserialize to List<AdminViewmodel>.
    //    - The deserializer can return null; handle that by falling back to a new list.
    // 3. Add the provided admin to the list.
    // 4. Serialize the full list back to the file (not a single admin object).
    // 5. Show success message. Catch and show exceptions.
    //
    // Rationale for change:
    // - Fix CS8600 by avoiding direct assignment of possible-null deserialization result
    //   to a non-nullable variable. Use a null-coalescing fallback or local check.
    // - Initialize list correctly (use new List<AdminViewmodel>() instead of [] syntax).
    // - Ensure file is written with the full admin list.

    public class AdminViewmodel : INotifyPropertyChanged
    {
        private string Firstname = string.Empty;
        private string Middlename = string.Empty;
        private string Lastname = string.Empty;
        private string Department = string.Empty;
        private string Uname = string.Empty;
        private string Password = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Fname
        {
            get => Firstname;
            set
            {
                if (Firstname != value)
                {
                    Firstname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Mname
        {
            get => Middlename;
            set
            {
                if (Middlename != value)
                {
                    Middlename = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Lname
        {
            get => Lastname;
            set
            {
                if (Lastname != value)
                {
                    Lastname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Admin_Dept
        {
            get => Department;
            set
            {
                if (Department != value)
                {
                    Department = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Admin_Uname
        {
            get => Uname;
            set
            {
                if (Uname != value)
                {
                    Uname = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Admin_Password
        {
            get => Password;
            set
            {
                if (Password != value)
                {
                    Password = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // data saving module definition
        public void SaveAdminData(AdminViewmodel admin)
        {
            try
            {
                string filePath = "AdminDataBase.json";

                // Initialize with empty list; will be replaced if file contains valid data.
                List<AdminViewmodel> adminList = new List<AdminViewmodel>();

                if (File.Exists(filePath))
                {
                    string existingJson = File.ReadAllText(filePath);
                    if (!string.IsNullOrWhiteSpace(existingJson))
                    {
                        // Deserialize may return null; use null-coalescing to ensure non-null list.
                        var deserialized = JsonSerializer.Deserialize<List<AdminViewmodel>>(existingJson);
                        if (deserialized != null)
                        {
                            adminList = deserialized;
                        }
                    }
                }

                // Add new admin and persist the entire list
                adminList.Add(admin);
                string json = JsonSerializer.Serialize(adminList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);

                MessageBox.Show("Admin saved successfully!", "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving admin: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
