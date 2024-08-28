using BoilerPlateBackend.Domain.Entities;
using BoilerPlateBackend.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateBackend.Infrastructure.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //could be done directly here
        builder.ApplyConfiguration(new MemberConfiguration());
    }
}
