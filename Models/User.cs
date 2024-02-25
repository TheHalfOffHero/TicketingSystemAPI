namespace TicketingSystemAPI.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}