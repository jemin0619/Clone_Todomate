using System.IO;
using System.Text.Json;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clone_Todomate.Models.Repository
{
    public class UserProfileRepository : ObservableObject, IUserProfileRepository
    {
        private const string DataPath = "Data";
        private const string UserProfileFilePath = "Data\\userProfile.json";

        public UserProfileModel? GetUserProfile()
        {
            if (File.Exists(UserProfileFilePath))
            {
                try
                {
                    string json = File.ReadAllText(UserProfileFilePath);
                    UserProfileModel? newProfile = JsonSerializer.Deserialize<UserProfileModel>(json);
                    return newProfile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine($"Error loading user profile: {ex.Message}");
                }
            }
            return null;
        }

        public bool MakeUserProfileDataFile()
        {
            if(File.Exists(UserProfileFilePath))
            {
                return true; // 파일이 이미 존재하면 true 반환
            }
            if (!Directory.Exists(DataPath))
            {
                Directory.CreateDirectory(DataPath);
            }
            try
            {
                UserProfileModel userProfile = new UserProfileModel();
                string json = JsonSerializer.Serialize(userProfile, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(UserProfileFilePath, json);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine($"Error MakeUserProfileDataFile: {ex.Message}");
            }
            return false;
        }

        public bool SaveUserProfile(UserProfileModel userProfile)
        {
            try
            {
                string json = JsonSerializer.Serialize(userProfile, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(UserProfileFilePath, json);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine($"Error SaveUserProfile: {ex.Message}");
            }
            return false;
        }
    }
}
