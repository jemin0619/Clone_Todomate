using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels;
using Microsoft.Win32;

namespace Clone_Todomate.Commands
{
    public class UserProfileImageResetCommand : CommandBase
    {
        private UserProfileViewModel _mainViewModel;
        private IUserProfileRepository _userProfileRepository;
        public UserProfileImageResetCommand(UserProfileViewModel mainViewModel, IUserProfileRepository userProfileRepository)
        {
            _mainViewModel = mainViewModel;
            _userProfileRepository = userProfileRepository;
        }
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.UserProfile.UserImagePath = string.Empty;
            _userProfileRepository.SaveUserProfile(_mainViewModel.UserProfile);
        }
    }
}
