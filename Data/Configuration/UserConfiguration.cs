using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Models;

namespace ToDo.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .UseIdentityColumn();
            
            builder
                .Property(u => u.Name)
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property(u => u.Nickname)
                .HasMaxLength(25)
                .IsRequired();

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Email)
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property(u => u.CreationDate)
                .IsRequired();

            builder
                .Property(u => u.CreationDate)
                .HasDefaultValue(DateTime.Now);

            builder
                .ToTable("Users");
        }
    }
}