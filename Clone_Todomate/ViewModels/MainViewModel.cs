using System.Windows.Input;
using Clone_Todomate.Commands;
using Clone_Todomate.Models;
using Clone_Todomate.Models.Repository;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IUserProfileRepository _userProfileRepository;
        private UserProfileModel _userProfile;
        public UserProfileModel UserProfile
        {
            get => _userProfile;
            set => SetProperty(ref _userProfile, value);
        }
        public IUserProfileRepository UserProfileRepository
        {
            get => _userProfileRepository;
            set => SetProperty(ref _userProfileRepository, value);
        }

        public ICommand userProfileSaveCommand { get; set; }
        public ICommand userProfileLoadCommand { get; set; }

        public MainViewModel()
        {
            _userProfileRepository = new UserProfileRepository();
            _userProfileRepository.MakeUserProfileDataFile();
            userProfileSaveCommand = new UserProfileSaveCommand(this, _userProfileRepository);
            userProfileLoadCommand = new UserProfileLoadCommand(this, _userProfileRepository);
            _userProfile = _userProfileRepository.GetUserProfile() ?? new UserProfileModel();
        }
    }
}