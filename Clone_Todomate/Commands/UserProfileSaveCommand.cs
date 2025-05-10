using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clone_Todomate.Models.Repository;
using System.Windows.Input;
using Clone_Todomate.ViewModels;
using Clone_Todomate.Models;

namespace Clone_Todomate.Commands
{
    public class UserProfileSaveCommand : CommandBase
    {
        private MainViewModel _mainViewModel;
        private IUserProfileRepository _userProfileRepository;

        public UserProfileSaveCommand(MainViewModel mainViewModel, IUserProfileRepository userProfileRepository)
        {
            _mainViewModel = mainViewModel;
            _userProfileRepository = userProfileRepository;
        }
        public override bool CanExecute(object? parameter)
        {
            return _mainViewModel.UserProfile != null && !string.IsNullOrWhiteSpace(_mainViewModel.UserProfile.UserName);
        }
        public override void Execute(object? parameter)
        {
            _userProfileRepository.SaveUserProfile(_mainViewModel.UserProfile);
        }
    }
}
