using Microsoft.EntityFrameworkCore;
using UserService.DomainLib.Entities;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
using VidensVejen.BuildingBlocksLib.Messaging.Outbox;

namespace UserService.InfrastructureLib.Persistence;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<OutboxMessage> Outbox { get; set; }
    public DbSet<InboxMessage> Inbox { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
}
