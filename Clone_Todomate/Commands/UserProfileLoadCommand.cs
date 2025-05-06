using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clone_Todomate.Models;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels;

namespace Clone_Todomate.Commands
{
    public class UserProfileLoadCommand : CommandBase
    {
        private MainViewModel _mainViewModel;
        private IUserProfileRepository _userProfileRepository;

        public UserProfileLoadCommand(MainViewModel mainViewModel, IUserProfileRepository userProfileRepository)
        {
            _mainViewModel = mainViewModel;
            _userProfileRepository = userProfileRepository;
        }
        public override bool CanExecute(object? parameter)
        {
            return true; //load는 항상 가능
        }
        public override void Execute(object? parameter)
        {
            var newUserProfile = _userProfileRepository.GetUserProfile();
            _mainViewModel.UserProfile = newUserProfile ?? new UserProfileModel();
        }
    }
}