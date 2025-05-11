using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.Models
{
    public class UserProfileModel : ObservableObject
    {
        //UserName에는 무조건 값이 들어가야 함
        private string _userName = "Default User";
        private string _userImagePath = "";
        private string _userDescription = "";
        private string _userNameTemp = "";
        private string _userDescriptionTemp = "";

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string UserImagePath
        {
            get => _userImagePath;
            set => SetProperty(ref _userImagePath, value);
        }

        public string UserDescription
        {
            get => _userDescription;
            set => SetProperty(ref _userDescription, value);
        }

        public string UserNameTemp
        {
            get => _userNameTemp;
            set => SetProperty(ref _userNameTemp, value);
        }

        public string UserDescriptionTemp
        {
            get => _userDescriptionTemp;
            set => SetProperty(ref _userDescriptionTemp, value);
        }
    }
}
