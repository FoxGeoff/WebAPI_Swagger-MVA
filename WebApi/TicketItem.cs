using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class TicketItem 
    {
        public int Id { get; set; }
        public string Concert { get; set; }
        public string Artist { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class TicketContext : DbContext
    {
        public TicketContext()
        {
        }

        public TicketContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<TicketItem> TicketItems { get; set; }
    }
}
