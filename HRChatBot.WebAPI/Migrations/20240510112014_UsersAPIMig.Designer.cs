﻿// <auto-generated />
using System;
using HRChatBot.WebAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRChatBot.WebAPI.Migrations
{
    [DbContext(typeof(HRChatBotContext))]
    [Migration("20240510112014_UsersAPIMig")]
    partial class UsersAPIMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HRChatBot.WebAPI.Models.ChatHistory", b =>
                {
                    b.Property<long>("ChatHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("chat_history_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ChatHistoryId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATE")
                        .HasColumnName("created_date");

                    b.Property<int>("FromUserId")
                        .HasColumnType("INT")
                        .HasColumnName("from_user_id");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<int>("ToUserId")
                        .HasColumnType("INT")
                        .HasColumnName("to_user_id");

                    b.HasKey("ChatHistoryId");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("ChatHistory", (string)null);
                });

            modelBuilder.Entity("HRChatBot.WebAPI.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UserId"));

                    b.Property<string>("AboutMe")
                        .HasColumnType("text")
                        .HasColumnName("about_me");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATE")
                        .HasColumnName("created_date");

                    b.Property<long?>("DarkTheme")
                        .HasColumnType("bigint")
                        .HasColumnName("dark_theme");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATE")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email_address");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<long?>("Notifications")
                        .HasColumnType("bigint")
                        .HasColumnName("notifications");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("ProfilePicDataUrl")
                        .HasColumnType("text")
                        .HasColumnName("profile_pic_data_url");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("text")
                        .HasColumnName("profile_picture_url");

                    b.Property<string>("Role")
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("source");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HRChatBot.WebAPI.Models.ChatHistory", b =>
                {
                    b.HasOne("HRChatBot.WebAPI.Models.User", "FromUser")
                        .WithMany("ChatHistoryFromUsers")
                        .HasForeignKey("FromUserId")
                        .IsRequired();

                    b.HasOne("HRChatBot.WebAPI.Models.User", "ToUser")
                        .WithMany("ChatHistoryToUsers")
                        .HasForeignKey("ToUserId")
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("HRChatBot.WebAPI.Models.User", b =>
                {
                    b.Navigation("ChatHistoryFromUsers");

                    b.Navigation("ChatHistoryToUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
