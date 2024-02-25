namespace TicketingSystemAPI.Models;

public class Comment
{
    public int CommentId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    // Foreign keys
    public int TicketId { get; set; }
    public virtual Ticket Ticket { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }
}