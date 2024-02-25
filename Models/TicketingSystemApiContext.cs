using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketingSystemAPI.Models
{
    public class TicketingSystemApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseNpgsql("Host=localhost;Database=TicketingDatabase;Username=postgres;Password=postgres");
         }
    }
}





// namespace ShiftLoggerAPI.Models
// {
//     public class ShiftLoggerContext : DbContext
//     {
//         public DbSet<Employee> Employees { get; set; }
//         public DbSet<Shift> Shifts { get; set; }
//
//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             optionsBuilder.UseNpgsql("Host=localhost;Database=ShiftLogger;Username=postgres;Password=postgres");
//         }
//     }
// }
