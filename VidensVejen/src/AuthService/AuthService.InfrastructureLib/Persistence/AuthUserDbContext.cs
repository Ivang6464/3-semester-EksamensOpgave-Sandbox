using AuthService.DomainLib.Entities;
using Microsoft.EntityFrameworkCore;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
using VidensVejen.BuildingBlocksLib.Messaging.Outbox;

namespace AuthService.InfrastructureLib.Persistence;

public class AuthUserDbContext : DbContext
{
    public DbSet<AuthUser> AuthUsers { get; set; }
    public DbSet<AccessPermission> Permissions { get; set; }
    public DbSet<OutboxMessage> Outbox { get; set; }
    public DbSet<InboxMessage> Inbox { get; set; }

    public AuthUserDbContext(DbContextOptions<AuthUserDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthUserDbContext).Assembly);
    }
}
