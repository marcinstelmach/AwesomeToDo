using AwesomeToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeToDo.Domain.Data.Concrete.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Email).HasMaxLength(30);
            builder.HasIndex(s => s.Email);
            builder.Property(s => s.FirstName).HasMaxLength(30);
            builder.Property(s => s.LastName).HasMaxLength(30);

            builder.HasMany(s => s.Cards)
                .WithOne(s => s.User)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
