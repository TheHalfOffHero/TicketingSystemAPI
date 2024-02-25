namespace TicketingSystemAPI.Models;

public class Ticket
{
    public int TicketId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public TicketStatus? Status { get; set; }

    // Foreign keys
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public ICollection<Comment> Comments { get; set; }
}

public enum TicketStatus
{
    Open,
    InProgress,
    Closed
}