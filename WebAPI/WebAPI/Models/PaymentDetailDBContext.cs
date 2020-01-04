using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Models
{
    public partial class PaymentDetailDBContext : DbContext
    {
        public PaymentDetailDBContext()
        {
        }

        public PaymentDetailDBContext(DbContextOptions<PaymentDetailDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost;Database=PaymentDetailDB;Trusted_Connection=True;User Id=sa;Password=Pa55word2019;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<PaymentDetails>(entity =>
            {
                entity.HasKey(e => e.PMId)
                    .HasName("PK_dbo.PaymentDetails");

                entity.Property(e => e.PMId).HasColumnName("PMId");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CardOwnerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CVV)
                    .IsRequired()
                    .HasColumnName("CVV")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });
        }
    }
}
