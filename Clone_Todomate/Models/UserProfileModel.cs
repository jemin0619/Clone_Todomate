using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.Models
{
    public class UserProfileModel : ObservableObject
    {
        private string? _userImagePath;
        private string? _userName;
        private string? _userDescription;
        
        public string? UserImagePath
        {
            get => _userImagePath;
            set => SetProperty(ref _userImagePath, value);
        }

        public string? UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string? UserDescription
        {
            get => _userDescription;
            set => SetProperty(ref _userDescription, value);
        }

        public bool isValid()
        {
            return UserImagePath is not null && UserName is not null && UserDescription is not null;
        }
    }
}
