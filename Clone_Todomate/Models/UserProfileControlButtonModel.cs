using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.Models
{
    public class UserProfileControlButtonModel : ObservableObject
    {
        private bool _userNameEditEnable = false;
        private bool _userDescriptionEditEnable = false;
        public bool UserNameEditEnable
        {
            get => _userNameEditEnable;
            set => SetProperty(ref _userNameEditEnable, value);
        }
        public bool UserDescriptionEditEnable
        {
            get => _userDescriptionEditEnable;
            set => SetProperty(ref _userDescriptionEditEnable, value);
        }
    }
}
