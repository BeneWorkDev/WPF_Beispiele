using BeispielAdapterPattern.Adapters;
using BeispielAdapterPattern.BaseClasses;
using BeispielAdapterPattern.Interfaces;
using BeispielAdapterPattern.Model;
using BeispielAdapterPattern.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeispielAdapterPattern.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private string _userInfo;
        private int _userId;

        public string UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; OnPropertyChanged(nameof(UserInfo)); }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged(nameof(UserId)); }
        }

        public ICommand GetUserInfoCommand { get; }

        public MainViewModel()
        {
            // Initialisiere den Adapter
            _userService = new UserServiceAdapter(new UserService());
            GetUserInfoCommand = new RelayCommand(GetUserInfo);
        }

        private void GetUserInfo()
        {
            var userName = _userService.GetUserName(UserId);
            var userAge = _userService.GetUserAge(UserId);
            UserInfo = $"Name: {userName}, Age: {userAge}";
        }
    }
}
