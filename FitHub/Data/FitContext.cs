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
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Attendance> Attendances{ get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }

    }
}
    