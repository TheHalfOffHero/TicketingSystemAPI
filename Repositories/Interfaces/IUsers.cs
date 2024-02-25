using TicketingSystemAPI.Models;

namespace TicketingSystemAPI.Repositories.Interfaces;

public interface IUsers : IDisposable
{
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
    int CreateUser(User user);
    int UpdateUser(User user);
    int DeleteUser(int id);
}