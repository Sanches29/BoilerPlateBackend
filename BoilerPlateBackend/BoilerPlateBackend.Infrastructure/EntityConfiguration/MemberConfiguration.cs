using BoilerPlateBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoilerPlateBackend.Infrastructure.EntityConfiguration;
public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    //All of this could be done in the AppDbContext class, maybe its an over-engineering to separate these configurations
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Gender).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
        builder.Property(x => x.IsActive).IsRequired();

        // Seed data
        builder.HasData(
            new Member(1, "Guilherme", "Sanches", "male", "guilherme@gmail.com", true),
            new Member(2, "Maria", "Sanches", "female", "maria@gmail.com", true)
        );
    }
}
