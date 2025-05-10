using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels;

namespace Clone_Todomate.Commands
{
    public class UserProfileEditCancelCommand : CommandBase
    {
        private MainViewModel _mainViewModel;
        private IUserProfileRepository _userProfileRepository;
        private string _type;

        public UserProfileEditCancelCommand(MainViewModel mainViewModel, IUserProfileRepository userProfileRepository, string type)
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
