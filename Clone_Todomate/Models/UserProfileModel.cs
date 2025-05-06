using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.Models
{
    public partial class UserProfileModel : ObservableObject
    {
        private string _userImagePath = "Default ImagePath";

        private string _userName = "Default User";

        private string _userDescription = "Default Description";

        public string UserImagePath
        {
            get => _userImagePath;
            set => SetProperty(ref _userImagePath, value);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string UserDescription
        {
            get => _userDescription;
            set => SetProperty(ref _userDescription, value);
        }
    }
}
