using System;
using System.Collections.Generic;
using System.Text;
using AwesomeToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeToDo.Domain.Data.Concrete.Configurations
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).HasMaxLength(30);

            builder.HasMany(s => s.ToDos)
                .WithOne(s => s.Card)
                .HasForeignKey("CardId")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
