using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels;
using Clone_Todomate.Utils;
using Microsoft.Win32;

namespace Clone_Todomate.Commands
{
    public class UserProfileImageEditCommand : CommandBase
    {
        private UserProfileViewModel _mainViewModel;
        private IUserProfileRepository _userProfileRepository;
        public UserProfileImageEditCommand(UserProfileViewModel mainViewModel, IUserProfileRepository userProfileRepository)
        {
            _mainViewModel = mainViewModel;
            _userProfileRepository = userProfileRepository;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
            };

            if (fileDialog.ShowDialog() == true)
            {
                // 선택한 파일 경로
                string sourceFilePath = fileDialog.FileName;

                // 복사 대상 디렉터리
                string targetDirectory = Constants.UserProfileImageDirectory;

                // 디렉터리가 없으면 생성
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // 복사 대상 파일 경로
                string targetFilePath = Path.Combine(targetDirectory, Constants.UserProfileImageFileName);
                int count = 0;
                while(File.Exists(targetFilePath))
                {
                    // 파일 이름에 숫자를 붙여서 중복 방지
                    string newFileName = $"{Path.GetFileNameWithoutExtension(Constants.UserProfileImageFileName)}_{count}{Path.GetExtension(Constants.UserProfileImageFileName)}";
                    targetFilePath = Path.Combine(targetDirectory, newFileName);
                    count++;
                }

                // 파일 복사
                File.Copy(sourceFilePath, targetFilePath);

                // ViewModel에 복사된 파일 경로 저장
                _mainViewModel.UserProfile.UserImagePath = targetFilePath;

                // 변경된 프로필 저장
                _userProfileRepository.SaveUserProfile(_mainViewModel.UserProfile);
            }
        }

    }
}