using System.Windows;
using Clone_Todomate.Models.Repository;
using Clone_Todomate.ViewModels;

namespace Clone_Todomate.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UserProfileWindow : Window
    {
        public UserProfileWindow()
        {
            InitializeComponent();
            this.DataContext = new UserProfileViewModel(new UserProfileRepository());
        }
    }
}