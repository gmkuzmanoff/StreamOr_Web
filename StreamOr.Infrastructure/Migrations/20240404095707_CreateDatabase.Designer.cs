﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StreamOr.Infrastructure.Data;

#nullable disable

namespace StreamOr.Infrastructure.Migrations
{
    [DbContext(typeof(StreamorDbContext))]
    [Migration("20240404095707_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6cdaa3da-3bf5-452c-97d2-8e6d808f4284",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7dcc7086-1be9-4999-af88-23e5146b5c2c",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEGTNdNmR4pm51/9xaOCC9XeEw9gtInNjLwU+1nmUpRQuhVKi/Kz8tWuHUsPh5YQAPg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "60982efc-a4df-407d-8661-95e7c2086873",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7705b1e5-0e51-424e-a2b7-805abc814d5b",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@gmail.com",
                            NormalizedUserName = "user@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEK8uKhDSFfdNaTh62mvCu2Dt6sWaz6nOhw1VXVD8wXD6F7/AnRl9aWQ4P5B9i5DH2A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a71e6fa1-699c-4761-967e-9b35d5df5d5c",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StreamOr.Infrastructure.Data.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Group Identity");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Group Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasComment("Table Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rock & Metal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rap & Soul"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Electronic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Reggie & Ragga"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Jazz"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ambient & Chillout"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Retro"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Chrismas"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Pop"
                        },
                        new
                        {
                            Id = 10,
                            Name = "News & Talk"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Religion"
                        });
                });

            modelBuilder.Entity("StreamOr.Infrastructure.Data.Models.Radio", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Radio Identity");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date on Adding");

                    b.Property<int>("Bitrate")
                        .HasColumnType("int")
                        .HasComment("Radio Bitrate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Radio Description");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Radio Genre");

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasComment("Group Identity");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit")
                        .HasComment("Radio Priority");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Radio Logo");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Owner Identity");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Radio Title");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Radio Url");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Radios");

                    b.HasComment("Table Radios");

                    b.HasData(
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://insomniafm.cloudrad.io/;@shoutcast",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5440),
                            Bitrate = 128,
                            Description = "",
                            Genre = "electronic",
                            GroupId = 3,
                            IsFavorite = true,
                            LogoUrl = "https://i1.sndcdn.com/avatars-000628757292-l5ks2r-t240x240.jpg",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "INSOMNIAFM | Electronic Music",
                            Url = "http://insomniafm.cloudrad.io/;@shoutcast"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://listen.openstream.co/6524/audio",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5482),
                            Bitrate = 192,
                            Description = "Unspecified description",
                            Genre = "Downtempo, New Age, House, Electronic",
                            GroupId = 6,
                            IsFavorite = false,
                            LogoUrl = "",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "Deep Planet on MixLive.ie",
                            Url = "http://listen.openstream.co/6524/audio"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://radiointerface.ru:1250/stream",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5486),
                            Bitrate = 192,
                            Description = "PROGRESSIVE SPIRIT RADIO DJ @TRANSPIRIT",
                            Genre = "CHILLOUT PROGRESSIVE SPIRIT TRANCE PSY AMBIENT",
                            GroupId = 6,
                            IsFavorite = false,
                            LogoUrl = "",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "PROGRESSIVE SPIRIT RADIO",
                            Url = "http://radiointerface.ru:1250/stream"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://relay.friskyradio.com/deep_mp3_high",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5489),
                            Bitrate = 320,
                            Description = "",
                            Genre = "Progressive",
                            GroupId = 3,
                            IsFavorite = true,
                            LogoUrl = "https://cdn-profiles.tunein.com/s2107/images/logoq.png?t=637685581510000000",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "Frisky Radio | Deep",
                            Url = "http://relay.friskyradio.com/deep_mp3_high"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://stream.overdrivelive.net:8000/alternative_128.mp3",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5494),
                            Bitrate = 128,
                            Description = "",
                            Genre = "Alternative",
                            GroupId = 1,
                            IsFavorite = true,
                            LogoUrl = "https://static2.mytuner.mobi/media/tvos_radios/Ue6Sq9DTW5.png",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "Overdrive Live! Station",
                            Url = "http://stream.overdrivelive.net:8000/alternative_128.mp3"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/rock/mp3-192",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5509),
                            Bitrate = 192,
                            Description = "80s80s Rock",
                            Genre = "80s Retro Rock",
                            GroupId = 1,
                            IsFavorite = false,
                            LogoUrl = "https://images.80s80s.de/files/media/image/file/80s80s_rock_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=736&amp;h=414&amp;dpr=1.25&amp;auto=format",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "80s80s Rock",
                            Url = "http://streams.80s80s.de/rock/mp3-192"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/wave/mp3-192/streams/streema",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5513),
                            Bitrate = 192,
                            Description = "80s80s Wave",
                            Genre = "80s Retro Wave",
                            GroupId = 3,
                            IsFavorite = false,
                            LogoUrl = "https://images.80s80s.de/files/media/image/file/80s80s_wave_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "80s80s Wave",
                            Url = "http://streams.80s80s.de/wave/mp3-192/streams/streema"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/hiphop/mp3-192/streams/streema",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5498),
                            Bitrate = 192,
                            Description = "80s80s HipHop",
                            Genre = "80s Retro Hiphop",
                            GroupId = 2,
                            IsFavorite = false,
                            LogoUrl = "https://images.80s80s.de/files/2022-05/80s80sHIPHOP_radio_logo.png?rect=0%2C0%2C3840%2C2160&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "80s80s HipHop",
                            Url = "http://streams.80s80s.de/hiphop/mp3-192/streams/streema"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/love/mp3-192/streams/streema",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5502),
                            Bitrate = 192,
                            Description = "80s80s Love",
                            Genre = "80s Retro",
                            GroupId = 7,
                            IsFavorite = false,
                            LogoUrl = "https://images.80s80s.de/files/media/image/file/80s80s-hero-love-16-9_1.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=300&amp;h=169&amp;dpr=3&amp;fm=webp",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "80s80s Love",
                            Url = "http://streams.80s80s.de/love/mp3-192/streams/streema"
                        },
                        new
                        {
                            Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/party/mp3-192/streams/streema",
                            AddedOn = new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5506),
                            Bitrate = 192,
                            Description = "80s80s Partyhits",
                            Genre = "80s Retro Partyhits",
                            GroupId = 7,
                            IsFavorite = false,
                            LogoUrl = "https://images.80s80s.de/files/media/image/file/80s80s_party_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp",
                            OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                            Title = "80s80s Partyhits",
                            Url = "http://streams.80s80s.de/party/mp3-192/streams/streema"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StreamOr.Infrastructure.Data.Models.Radio", b =>
                {
                    b.HasOne("StreamOr.Infrastructure.Data.Models.Group", "Group")
                        .WithMany("Radios")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("StreamOr.Infrastructure.Data.Models.Group", b =>
                {
                    b.Navigation("Radios");
                });
#pragma warning restore 612, 618
        }
    }
}