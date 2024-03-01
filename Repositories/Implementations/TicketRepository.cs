using TicketingSystemAPI.Models;
using TicketingSystemAPI.Repositories.Interfaces;

namespace TicketingSystemAPI.Repositories.Implementations;

public class TicketRepository(TicketingSystemApiContext db) : ITickets
{

    private readonly TicketingSystemApiContext _context = db;
    
    public IEnumerable<Ticket> GetAllTickets()
    {
        return _context.Tickets.ToList();
    }

    public Ticket GetTicketById(int id)
    {
        Ticket ticket = _context.Tickets.Where(x => x.TicketId == id).FirstOrDefault() ?? null;
        return ticket;
    }

    public int CreateTicket(Ticket ticket)
    {
        int result = -1;

        if (ticket != null)
        {
            _context.Add(ticket);
            _context.SaveChangesAsync();
            result = ticket.TicketId;
        }

        return result;
    }

    public int UpdateTicket(Ticket ticket)
    {
        int result = -1;
        int oldTicketId = ticket.TicketId;
        Ticket oldTicket = _context.Tickets.Where(x => x.TicketId == ticket.TicketId).FirstOrDefault() ?? null;

        if (oldTicket != null)
        {
            oldTicket.Title = ticket.Title;
            oldTicket.Description = ticket.Description;
            oldTicket.CreatedAt = ticket.CreatedAt;
            oldTicket.Status = ticket.Status;
            oldTicket.UserId = ticket.UserId;
            oldTicket.User = ticket.User;
            oldTicket.Comments = ticket.Comments;
            
            result = ticket.TicketId;
        }

        _context.SaveChangesAsync();
        return result;
    }

    public int DeleteTicket(int id)
    {
        int result = -1;
        Ticket deletedTicket = _context.Tickets.Where(x => x.TicketId == id).FirstOrDefault() ?? null;
        
        if (deletedTicket != null)
        {
            _context.Tickets.Remove(deletedTicket);
            _context.SaveChangesAsync();
            result = deletedTicket.TicketId;
        }

        return result;
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}