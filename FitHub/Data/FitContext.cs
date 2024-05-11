using FitHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Data
{
    public class FitContext:DbContext
    {
        public FitContext(DbContextOptions<FitContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        DbSet<Member> Members { get; set; }
        DbSet<Attendance> Attendances{ get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<SubscriptionType> SubscriptionTypes { get; set; }

    }
}
    