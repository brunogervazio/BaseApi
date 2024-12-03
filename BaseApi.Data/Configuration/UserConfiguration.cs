using BaseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.Infra.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            builder.HasKey(c => c.Uuid);

            builder.Property(c => c.Name)
               .HasColumnName("Name")
               .HasColumnType("VARCHAR")
               .HasMaxLength(128)
               .IsRequired();

            builder.OwnsOne(c => c.Email,
                a =>
                {
                    a.Property(p => p.Value)
                       .HasColumnName("Email")
                       .HasColumnType("VARCHAR")
                       .HasMaxLength(64)
                       .IsRequired();
                });


            builder.OwnsOne(c => c.Password,
                a =>
                {
                    a.Property(p => p.EncryptedValue)
                        .HasColumnName("Password")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(128)
                        .IsRequired();
                });

            builder.Property(c => c.CreatedAt)
               .HasColumnName("CreatedAt")
               .HasColumnType("DATETIME")
               .HasDefaultValueSql("GETDATE()")
               .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();
        }
    }
}
