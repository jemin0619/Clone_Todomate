using System.Windows.Input;
using Clone_Todomate.Models;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using Clone_Todomate.Commands;
using System.Windows;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.Input;

namespace Clone_Todomate.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private ICommand _saveCommand;
        private ICommand _loadCommand;
        private ICommand _updateCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(saveExecute,
                        _ => UserProfile != null &&
                        !string.IsNullOrWhiteSpace(UserProfile.UserName) &&
                        !string.IsNullOrWhiteSpace(UserProfile.UserDescription) &&
                        !string.IsNullOrWhiteSpace(UserProfile.UserImagePath));
                }
                return _saveCommand;
            }
        }

        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                {
                    _loadCommand = new RelayCommand(loadExecute);
                }
                return _loadCommand;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(updateExecute,
                        _ => UserProfile != null &&
                        !string.IsNullOrWhiteSpace(UserProfile.UserName) &&
                        !string.IsNullOrWhiteSpace(UserProfile.UserDescription) &&
                        !string.IsNullOrWhiteSpace(UserProfile.UserImagePath));
                }
                return _updateCommand;
            }
        }

        private void saveExecute(object? obj)
        {
            UserProfileRepository.SaveUserProfile(UserProfile);
        }

        private void loadExecute(object? obj)
        {
            UserProfileRepository.LoadUserProfile();
        }

        private void updateExecute(object? obj)
        {
            UserProfileRepository.UpdateUserProfile(UserProfile);
        }
    }
}
