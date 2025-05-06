namespace Clone_Todomate.Models.Repository
{
    public interface IUserProfileRepository
    {
        UserProfileModel? GetUserProfile();
        bool SaveUserProfile(UserProfileModel userProfile);
        bool MakeUserProfileDataFile();
    }
}