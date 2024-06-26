using HRChatBot.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HRChatBot.WebAPI.Context
{
    public partial class HRChatBotContext : DbContext
    {
        public HRChatBotContext()
        {
        }

        public HRChatBotContext(DbContextOptions<HRChatBotContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        public virtual DbSet<ChatHistory> ChatHistories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatHistory>(entity =>
            {
                entity.ToTable("ChatHistory");

                entity.Property(e => e.ChatHistoryId).HasColumnName("chat_history_id");

                entity.Property(e => e.CreatedDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("created_date");

                entity.Property(e => e.FromUserId)
                    .HasColumnType("INT")
                    .HasColumnName("from_user_id");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.ToUserId)
                    .HasColumnType("INT")
                    .HasColumnName("to_user_id");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.ChatHistoryFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.ChatHistoryToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AboutMe).HasColumnName("about_me");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("created_date");

                entity.Property(e => e.DarkTheme).HasColumnName("dark_theme");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.Notifications).HasColumnName("notifications");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.ProfilePicDataUrl).HasColumnName("profile_pic_data_url");

                entity.Property(e => e.ProfilePictureUrl).HasColumnName("profile_picture_url");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
