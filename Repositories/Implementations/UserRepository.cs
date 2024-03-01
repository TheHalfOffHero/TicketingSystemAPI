using TicketingSystemAPI.Models;
using TicketingSystemAPI.Repositories.Interfaces;

namespace TicketingSystemAPI.Repositories.Implementations;

public class UserRepository(TicketingSystemApiContext db) : IUsers
{
    private readonly TicketingSystemApiContext _context = db;

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUserById(int id)
    {
        User user = _context.Users.Where(x => x.Id == id).FirstOrDefault() ?? null;
        return user;
    }

    public int CreateUser(User user)
    {
        int result = -1;

        if (user != null)
        {
            _context.Add(user);
            _context.SaveChangesAsync();
            result = user.Id;
        }

        return result;
    }
    
    public int UpdateUser(User user)
    {
        int result = -1;
        int oldUserId = user.Id;
        User oldUser = _context.Users.Where(x => x.Id == user.Id).FirstOrDefault() ?? null;

        if (oldUser != null)
        {
            oldUser.UserName = user.UserName;
            oldUser.email = user.email;
            oldUser.password = user.password;
            oldUser.Tickets = user.Tickets;
            result = user.Id;
        }

        _context.SaveChangesAsync();
        return result;
    }

    public int DeleteUser(int id)
    {
        int result = -1;
        User deletedUser = _context.Users.Where(x => x.Id == id).FirstOrDefault() ?? null;
        
        if (deletedUser != null)
        {
            _context.Users.Remove(deletedUser);
            _context.SaveChangesAsync();
            result = deletedUser.Id;
        }

        return result;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}