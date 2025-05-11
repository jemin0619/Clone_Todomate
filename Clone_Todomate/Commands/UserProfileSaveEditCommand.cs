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
    public class UserProfileSaveEditCommand : CommandBase
    {
        private UserProfileViewModel _mainViewModel;
        private IUserProfileRepository _userProfileRepository;
        private UserProfileField _userProfileField;

        public UserProfileSaveEditCommand(UserProfileViewModel mainViewModel, IUserProfileRepository userProfileRepository, UserProfileField userProfileField)
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
            //수정의 경우
            if (_mainViewModel.UserProfileControlButton.UserNameEditEnable == false)
            {
                return _mainViewModel.UserProfileControlButton.UserDescriptionEditEnable == false;
            }

            //저장하는 경우
            return !string.IsNullOrWhiteSpace(_mainViewModel.UserProfile.UserName);
        }

        private bool CanExecute_Description()
        {
            //수정의 경우
            if (_mainViewModel.UserProfileControlButton.UserDescriptionEditEnable == false)
            {
                return _mainViewModel.UserProfileControlButton.UserNameEditEnable == false;
            }

            //항상 수정/저장 가능
            return true;
        }

        private void Execute_Name()
        {
            //수정의 경우
            if (_mainViewModel.UserProfileControlButton.UserNameEditEnable == false)
            {
                _mainViewModel.UserProfileControlButton.UserNameEditEnable = true;
                _mainViewModel.UserProfile.UserNameTemp = _mainViewModel.UserProfile.UserName;
            }

            //저장하는 경우
            else
            {
                _mainViewModel.UserProfileControlButton.UserNameEditEnable = false;
                _userProfileRepository.SaveUserProfile(_mainViewModel.UserProfile);
            }
        }

        private void Execute_Description()
        {
            //수정의 경우
            if (_mainViewModel.UserProfileControlButton.UserDescriptionEditEnable == false)
            {
                _mainViewModel.UserProfileControlButton.UserDescriptionEditEnable = true;
                _mainViewModel.UserProfile.UserDescriptionTemp = _mainViewModel.UserProfile.UserDescription;
            }

            //저장하는 경우
            else
            {
                _mainViewModel.UserProfileControlButton.UserDescriptionEditEnable = false;
                _userProfileRepository.SaveUserProfile(_mainViewModel.UserProfile);
            }
        }
    }
}
