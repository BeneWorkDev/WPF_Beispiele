using BeispielAdapterPattern.Interfaces;

namespace BeispielAdapterPattern.Model
{
    public class UserService : IUserService
    {
        public string GetUserName(int userId)
        {
            // Simuliert einen externen API-Aufruf
            return "John Doe";
        }

        public int GetUserAge(int userId)
        {
            // Simuliert einen externen API-Aufruf
            return 30;
        }
    }
}
