using System;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace WebApi
{
    public class SampleData
    {
       
        internal static void InitialData(IServiceProvider applicationServices, ILoggerFactory loggerFactory, TicketContext context)
        {
            if (context.TicketItems.Count() == 0)
            {
                context.TicketItems.Add(new TicketItem { Artist = "Lenoard Cohn" });
                context.SaveChanges();
            }
        }
    }
}