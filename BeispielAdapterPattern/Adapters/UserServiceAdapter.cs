using BeispielAdapterPattern.Interfaces;
using BeispielAdapterPattern.Model;

namespace BeispielAdapterPattern.Adapters
{
    public class UserServiceAdapter : IUserService
    {
        private readonly UserService _userService;

        public UserServiceAdapter(UserService userService)
        {
            _userService = userService;
        }

        public string GetUserName(int userId)
        {
            return _userService.GetUserName(userId); // Anpassung der Schnittstelle
        }

        public int GetUserAge(int userId)
        {
            return _userService.GetUserAge(userId); // Anpassung der Schnittstelle
        }
    }
}
