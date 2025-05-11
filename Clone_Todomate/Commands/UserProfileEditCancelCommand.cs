using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clone_Todomate.Models.Fields;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels;

namespace Clone_Todomate.Commands
{
    public class UserProfileEditCancelCommand : CommandBase
    {
        private UserProfileViewModel _mainViewModel;
        private IUserProfileRepository _userProfileRepository;
        private UserProfileField _userProfileField;

        public UserProfileEditCancelCommand(UserProfileViewModel mainViewModel, IUserProfileRepository userProfileRepository, UserProfileField userProfileField)
        {
            _mainViewModel = mainViewModel;
            _userProfileRepository = userProfileRepository;
            _userProfileField = userProfileField;
        }
        public override bool CanExecute(object? parameter)
        {
            return _userProfileField switch
            {
                UserProfileField.Name => CanExecute_Name(),
                UserProfileField.Description => CanExecute_Description(),
                _ => false
            };
        }

        public override void Execute(object? parameter)
        {
            switch(_userProfileField)
            {
                case UserProfileField.Name:
                    Execute_Name();
                    break;
                case UserProfileField.Description:
                    Execute_Description();
                    break;
            }
        }

        private bool CanExecute_Name()
        {
            return _mainViewModel.UserProfileControlButton.UserNameEditEnable;
        }

        private bool CanExecute_Description()
        {
            return _mainViewModel.UserProfileControlButton.UserDescriptionEditEnable;
        }

        private void Execute_Name()
        {
            _mainViewModel.UserProfile.UserName = _mainViewModel.UserProfile.UserNameTemp;
            _mainViewModel.UserProfileControlButton.UserNameEditEnable = false;
        }

        private void Execute_Description()
        {
            _mainViewModel.UserProfile.UserDescription = _mainViewModel.UserProfile.UserDescriptionTemp;
            _mainViewModel.UserProfileControlButton.UserDescriptionEditEnable = false;
        }
    }
}
