using GymMembershipApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymMembershipApi.Data;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }
