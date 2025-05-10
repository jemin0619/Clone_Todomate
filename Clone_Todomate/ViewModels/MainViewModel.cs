using System.Windows.Input;
using Clone_Todomate.Commands;
using Clone_Todomate.Models;
using Clone_Todomate.Models.Repository;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private UserProfileModel _userProfile;
        private UserProfileControlButtonModel _userProfileControlButton;

        public UserProfileControlButtonModel UserProfileControlButton
        {
            get => _userProfileControlButton;
            set => SetProperty(ref _userProfileControlButton, value);
        }

        public UserProfileModel UserProfile
        {
            get => _userProfile;
            set => SetProperty(ref _userProfile, value);
        }

        public ICommand UserProfileSaveCommand { get; }
        public ICommand UserProfileLoadCommand { get; }
        public ICommand UserNameSaveEditCommand { get; }
        public ICommand UserDescriptionSaveEditCommand { get; }
        public ICommand UserNameEditCancelCommand { get; }
        public ICommand UserDescriptionEditCancelCommand { get; }

        public MainViewModel(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
            _userProfileControlButton = new UserProfileControlButtonModel();
            UserProfileSaveCommand = new UserProfileSaveCommand(this, _userProfileRepository);
            UserProfileLoadCommand = new UserProfileLoadCommand(this, _userProfileRepository);
            UserNameSaveEditCommand = new UserProfileSaveEditCommand(this, _userProfileRepository, "Name");
            UserDescriptionSaveEditCommand = new UserProfileSaveEditCommand(this, _userProfileRepository, "Description");
            UserNameEditCancelCommand = new UserProfileEditCancelCommand(this, _userProfileRepository, "Name");
            UserDescriptionEditCancelCommand = new UserProfileEditCancelCommand(this, _userProfileRepository, "Description");

            _userProfileRepository.MakeUserProfileDataFile();
            _userProfile = _userProfileRepository.GetUserProfile() ?? new UserProfileModel();
        }
    }
}