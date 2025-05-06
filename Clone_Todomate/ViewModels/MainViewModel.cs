using System.Windows.Input;
using Clone_Todomate.Models;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using Clone_Todomate.Commands;
using System.Windows;
using System.Windows.Navigation;

namespace Clone_Todomate.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private IUserProfileRepository _userProfileRepository;

        public UserProfileModel? UserProfile => _userProfileRepository.UserProfile;
        public IUserProfileRepository UserProfileRepository
        {
            get => _userProfileRepository;
            set => SetProperty(ref _userProfileRepository, value);
        }

        public MainViewModel()
        {
            _userProfileRepository = new UserProfileRepository();
            _userProfileRepository.LoadUserProfile();
        }
    }
}
