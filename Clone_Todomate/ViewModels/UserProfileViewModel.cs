using System.Windows.Input;
using Clone_Todomate.Commands;
using Clone_Todomate.Models;
using Clone_Todomate.Models.Fields;
using Clone_Todomate.Models.Repository;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.ViewModels
{
    public class UserProfileViewModel : ViewModelBase
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

        public ICommand UserNameSaveEditCommand { get; }
        public ICommand UserDescriptionSaveEditCommand { get; }
        public ICommand UserNameEditCancelCommand { get; }
        public ICommand UserDescriptionEditCancelCommand { get; }
        public ICommand UserProfileImageEditCommand { get; }
        public ICommand UserProfileImageResetCommand { get; }

        public UserProfileViewModel(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
            _userProfileControlButton = new UserProfileControlButtonModel();
            _userProfileRepository.MakeUserProfileDataFile();
            _userProfile = _userProfileRepository.GetUserProfile() ?? new UserProfileModel();

            //Commands
            UserNameSaveEditCommand = new UserProfileSaveEditCommand(this, _userProfileRepository, UserProfileField.Name);
            UserNameEditCancelCommand = new UserProfileEditCancelCommand(this, _userProfileRepository, UserProfileField.Name);
            UserDescriptionSaveEditCommand = new UserProfileSaveEditCommand(this, _userProfileRepository, UserProfileField.Description);
            UserDescriptionEditCancelCommand = new UserProfileEditCancelCommand(this, _userProfileRepository, UserProfileField.Description);
            UserProfileImageEditCommand = new UserProfileImageEditCommand(this, _userProfileRepository);
            UserProfileImageResetCommand = new UserProfileImageResetCommand(this, _userProfileRepository);
        }
    }
}