using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using Clone_Todomate.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.Models.Repository
{
    public class UserProfileRepository : ObservableObject, IUserProfileRepository
    {
        private const string UserProfileFilePath = "userProfile.json";
        private UserProfileModel? _userProfile;

        public UserProfileModel? UserProfile
        {
            get
            {
                if (_userProfile == null)
                {
                    LoadUserProfile();
                    if (_userProfile == null)
                        _userProfile = new UserProfileModel(); // Default initialization 
                }
                return _userProfile;
            }
        }

        public bool LoadUserProfile()
        {
            if (File.Exists(UserProfileFilePath))
            {
                try
                {
                    string json = File.ReadAllText(UserProfileFilePath);
                    var newProfile = JsonSerializer.Deserialize<UserProfileModel>(json);

                    if (newProfile != null)
                    {
                        //여기서 그냥 _userProfile 전체를 JsonSerialize로 덮어버리면 Notify가 안되는 듯... => json이 외부에서 강제 수정되면 반영이 안됨
                        _userProfile ??= new UserProfileModel(); // _userProfile이 null이면 초기화
                        _userProfile.UserName = newProfile.UserName;
                        _userProfile.UserDescription = newProfile.UserDescription;
                        _userProfile.UserImagePath = newProfile.UserImagePath;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine($"Error loading user profile: {ex.Message}");
                }
            }
            return false;
        }

        public bool SaveUserProfile(UserProfileModel userProfile)
        {
            try
            {
                string json = JsonSerializer.Serialize(userProfile, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(UserProfileFilePath, json);
                _userProfile ??= new UserProfileModel(); // _userProfile이 null이면 초기화
                _userProfile.UserName = userProfile.UserName;
                _userProfile.UserDescription = userProfile.UserDescription;
                _userProfile.UserImagePath = userProfile.UserImagePath;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user profile: {ex.Message}");
            }
            return false;
        }

        public bool UpdateUserProfile(UserProfileModel userProfile)
        {
            return SaveUserProfile(userProfile);
        }
    }
}
