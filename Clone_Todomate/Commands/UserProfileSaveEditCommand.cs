using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels;

namespace Clone_Todomate.Commands
{
    public class UserProfileSaveEditCommand : CommandBase
    {
        private MainViewModel _mainViewModel;
        private IUserProfileRepository _userProfileRepository;
        private string _type;

        public UserProfileSaveEditCommand(MainViewModel mainViewModel, IUserProfileRepository userProfileRepository, string type)
        {
            _mainViewModel = mainViewModel;
            _userProfileRepository = userProfileRepository;
            _type = type;
        }
        public override bool CanExecute(object? parameter)
        {
            if(_type.Equals("Name")) return CanExecute_Name();
            if (_type.Equals("Description")) return CanExecute_Description();
            return false;
        }

        public override void Execute(object? parameter)
        {
            if (_type.Equals("Name")) Execute_Name();
            if (_type.Equals("Description")) Execute_Description();
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
                _mainViewModel.UserProfile.UserDescriptionTemp = _mainViewModel.UserProfile.UserDescriptionTemp;
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
