using System.Windows.Input;
using Clone_Todomate.Models;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using Clone_Todomate.Commands;
using System.Windows;
using System.Windows.Navigation;

namespace Clone_Todomate.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IUserProfileRepository _userProfileRepository;
        public IUserProfileRepository UserProfileRepository
        {
            get => _userProfileRepository;
            set => SetProperty(ref _userProfileRepository, value);
        }

        public MainViewModel()
        {
            _userProfileRepository = new UserProfileRepository();
            _userProfileRepository.LoadUserProfile();
        }

        private ICommand _saveCommand;
        private ICommand _loadCommand;
        private ICommand _updateCommand;

        public ICommand SaveCommand
        {
            get
            {
                if(_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(saveExecute,
                        _ => UserProfileRepository.UserProfile.isValid());
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
                        _ => UserProfileRepository.UserProfile.isValid());
                }
                return _updateCommand;
            }
        }

        private void saveExecute(object? obj){
            UserProfileRepository.SaveUserProfile(UserProfileRepository.UserProfile);
        }

        private void loadExecute(object? obj){
            UserProfileRepository.LoadUserProfile();
        }

        private void updateExecute(object? obj){
            UserProfileRepository.UpdateUserProfile(UserProfileRepository.UserProfile);
        }
    }
}
