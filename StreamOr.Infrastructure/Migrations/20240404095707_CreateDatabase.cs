using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamOr.Infrastructure.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Group Identity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Group Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                },
                comment: "Table Groups");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Radio Identity"),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Radio Url"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Radio Title"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Radio Description"),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false, comment: "Radio Priority"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on Adding"),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Radio Logo"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Radio Genre"),
                    Bitrate = table.Column<int>(type: "int", nullable: false, comment: "Radio Bitrate"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Owner Identity"),
                    GroupId = table.Column<int>(type: "int", nullable: false, comment: "Group Identity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radios_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Radios_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table Radios");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1f579891-5c86-4f06-8834-fe31d1591b01", 0, "7705b1e5-0e51-424e-a2b7-805abc814d5b", "user@gmail.com", false, false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEK8uKhDSFfdNaTh62mvCu2Dt6sWaz6nOhw1VXVD8wXD6F7/AnRl9aWQ4P5B9i5DH2A==", null, false, "a71e6fa1-699c-4761-967e-9b35d5df5d5c", false, "user@gmail.com" },
                    { "6cdaa3da-3bf5-452c-97d2-8e6d808f4284", 0, "7dcc7086-1be9-4999-af88-23e5146b5c2c", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEGTNdNmR4pm51/9xaOCC9XeEw9gtInNjLwU+1nmUpRQuhVKi/Kz8tWuHUsPh5YQAPg==", null, false, "60982efc-a4df-407d-8661-95e7c2086873", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock & Metal" },
                    { 2, "Rap & Soul" },
                    { 3, "Electronic" },
                    { 4, "Reggie & Ragga" },
                    { 5, "Jazz" },
                    { 6, "Ambient & Chillout" },
                    { 7, "Retro" },
                    { 8, "Chrismas" },
                    { 9, "Pop" },
                    { 10, "News & Talk" },
                    { 11, "Religion" }
                });

            migrationBuilder.InsertData(
                table: "Radios",
                columns: new[] { "Id", "AddedOn", "Bitrate", "Description", "Genre", "GroupId", "IsFavorite", "LogoUrl", "OwnerId", "Title", "Url" },
                values: new object[,]
                {
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://insomniafm.cloudrad.io/;@shoutcast", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5440), 128, "", "electronic", 3, true, "https://i1.sndcdn.com/avatars-000628757292-l5ks2r-t240x240.jpg", "1f579891-5c86-4f06-8834-fe31d1591b01", "INSOMNIAFM | Electronic Music", "http://insomniafm.cloudrad.io/;@shoutcast" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://listen.openstream.co/6524/audio", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5482), 192, "Unspecified description", "Downtempo, New Age, House, Electronic", 6, false, "", "1f579891-5c86-4f06-8834-fe31d1591b01", "Deep Planet on MixLive.ie", "http://listen.openstream.co/6524/audio" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://radiointerface.ru:1250/stream", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5486), 192, "PROGRESSIVE SPIRIT RADIO DJ @TRANSPIRIT", "CHILLOUT PROGRESSIVE SPIRIT TRANCE PSY AMBIENT", 6, false, "", "1f579891-5c86-4f06-8834-fe31d1591b01", "PROGRESSIVE SPIRIT RADIO", "http://radiointerface.ru:1250/stream" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://relay.friskyradio.com/deep_mp3_high", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5489), 320, "", "Progressive", 3, true, "https://cdn-profiles.tunein.com/s2107/images/logoq.png?t=637685581510000000", "1f579891-5c86-4f06-8834-fe31d1591b01", "Frisky Radio | Deep", "http://relay.friskyradio.com/deep_mp3_high" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://stream.overdrivelive.net:8000/alternative_128.mp3", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5494), 128, "", "Alternative", 1, true, "https://static2.mytuner.mobi/media/tvos_radios/Ue6Sq9DTW5.png", "1f579891-5c86-4f06-8834-fe31d1591b01", "Overdrive Live! Station", "http://stream.overdrivelive.net:8000/alternative_128.mp3" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/hiphop/mp3-192/streams/streema", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5498), 192, "80s80s HipHop", "80s Retro Hiphop", 2, false, "https://images.80s80s.de/files/2022-05/80s80sHIPHOP_radio_logo.png?rect=0%2C0%2C3840%2C2160&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp", "1f579891-5c86-4f06-8834-fe31d1591b01", "80s80s HipHop", "http://streams.80s80s.de/hiphop/mp3-192/streams/streema" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/love/mp3-192/streams/streema", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5502), 192, "80s80s Love", "80s Retro", 7, false, "https://images.80s80s.de/files/media/image/file/80s80s-hero-love-16-9_1.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=300&amp;h=169&amp;dpr=3&amp;fm=webp", "1f579891-5c86-4f06-8834-fe31d1591b01", "80s80s Love", "http://streams.80s80s.de/love/mp3-192/streams/streema" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/party/mp3-192/streams/streema", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5506), 192, "80s80s Partyhits", "80s Retro Partyhits", 7, false, "https://images.80s80s.de/files/media/image/file/80s80s_party_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp", "1f579891-5c86-4f06-8834-fe31d1591b01", "80s80s Partyhits", "http://streams.80s80s.de/party/mp3-192/streams/streema" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/rock/mp3-192", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5509), 192, "80s80s Rock", "80s Retro Rock", 1, false, "https://images.80s80s.de/files/media/image/file/80s80s_rock_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=736&amp;h=414&amp;dpr=1.25&amp;auto=format", "1f579891-5c86-4f06-8834-fe31d1591b01", "80s80s Rock", "http://streams.80s80s.de/rock/mp3-192" },
                    { "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/wave/mp3-192/streams/streema", new DateTime(2024, 4, 4, 12, 57, 7, 388, DateTimeKind.Local).AddTicks(5513), 192, "80s80s Wave", "80s Retro Wave", 3, false, "https://images.80s80s.de/files/media/image/file/80s80s_wave_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp", "1f579891-5c86-4f06-8834-fe31d1591b01", "80s80s Wave", "http://streams.80s80s.de/wave/mp3-192/streams/streema" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Radios_GroupId",
                table: "Radios",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Radios_OwnerId",
                table: "Radios",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Radios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
