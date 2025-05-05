using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clone_Todomate.Models.Repository
{
    public interface IUserProfileRepository
    {
        UserProfileModel? UserProfile { get; }
        bool SaveUserProfile(UserProfileModel userProfile);
        bool LoadUserProfile();
        bool UpdateUserProfile(UserProfileModel userProfile);
    }
}