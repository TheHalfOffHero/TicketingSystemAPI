using TicketingSystemAPI.Models;

namespace TicketingSystemAPI.Repositories.Interfaces;

public interface ITickets : IDisposable
{
    IEnumerable<Ticket> GetAllTickets();
    Ticket GetTicketById(int id);
    int CreateTicket(Ticket ticket);
    int UpdateTicket(Ticket ticket);
    int DeleteTicket(int id);
}