using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StreamOr.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace StreamOr.Infrastructure.Data
{
    public class StreamorDbContext : IdentityDbContext
    {
        public StreamorDbContext(DbContextOptions<StreamorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Radio> Radios { get; set; }
        public DbSet<Group> Groups { get; set; }

        private List<IdentityUser> SeedUsers()
        {
            List<IdentityUser> users = new List<IdentityUser>();
            var hasher = new PasswordHasher<IdentityUser>();

            var admin = new IdentityUser()
            {
                Id = "6cdaa3da-3bf5-452c-97d2-8e6d808f4284",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com"
            };

            admin.PasswordHash =
                 hasher.HashPassword(admin, "Admin123");

            users.Add(admin);

            var user = new IdentityUser()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01",
                UserName = "user@gmail.com",
                NormalizedUserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "user@gmail.com"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "User123");

            users.Add(user);

            return users;
        }
        private List<Group> SeedGroups()
        {
            List<Group> groups = new List<Group>();
            groups.Add(new Group() { Id = 1, Name = "Rock & Metal" });
            groups.Add(new Group() { Id = 2, Name = "Rap & Soul" });
            groups.Add(new Group() { Id = 3, Name = "Electronic" });
            groups.Add(new Group() { Id = 4, Name = "Reggie & Ragga" });
            groups.Add(new Group() { Id = 5, Name = "Jazz" });
            groups.Add(new Group() { Id = 6, Name = "Ambient & Chillout" });
            groups.Add(new Group() { Id = 7, Name = "Retro" });
            groups.Add(new Group() { Id = 8, Name = "Chrismas" });
            groups.Add(new Group() { Id = 9, Name = "Pop" });
            groups.Add(new Group() { Id = 10, Name = "News & Talk" });
            groups.Add(new Group() { Id = 11, Name = "Religion" });
            return groups;
        }
        private List<Radio> SeedRadios()
        {
            List<Radio> radios = new List<Radio>();
            var insomniaFm = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://insomniafm.cloudrad.io/;@shoutcast",
                Url = "http://insomniafm.cloudrad.io/;@shoutcast",
                Title = "INSOMNIAFM | Electronic Music",
                Description = "",
                IsFavorite = true,
                AddedOn = DateTime.Now,
                LogoUrl = "https://i1.sndcdn.com/avatars-000628757292-l5ks2r-t240x240.jpg",
                Genre = "electronic",
                Bitrate = 128,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 3
            };
            var deepPlanet = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://listen.openstream.co/6524/audio",
                Url = "http://listen.openstream.co/6524/audio",
                Title = "Deep Planet on MixLive.ie",
                Description = "Unspecified description",
                IsFavorite = false,
                AddedOn = DateTime.Now,
                LogoUrl = "",
                Genre = "Downtempo, New Age, House, Electronic",
                Bitrate = 192,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 6
            };
            var progSpirit = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://radiointerface.ru:1250/stream",
                Url = "http://radiointerface.ru:1250/stream",
                Title = "PROGRESSIVE SPIRIT RADIO",
                Description = "PROGRESSIVE SPIRIT RADIO DJ @TRANSPIRIT",
                IsFavorite = false,
                AddedOn = DateTime.Now,
                LogoUrl = "",
                Genre = "CHILLOUT PROGRESSIVE SPIRIT TRANCE PSY AMBIENT",
                Bitrate = 192,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 6
            };
            var friskyDeep = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://relay.friskyradio.com/deep_mp3_high",
                Url = "http://relay.friskyradio.com/deep_mp3_high",
                Title = "Frisky Radio | Deep",
                Description = "",
                IsFavorite = true,
                AddedOn = DateTime.Now,
                LogoUrl = "https://cdn-profiles.tunein.com/s2107/images/logoq.png?t=637685581510000000",
                Genre = "Progressive",
                Bitrate = 320,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 3
            };
            var overdrive = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://stream.overdrivelive.net:8000/alternative_128.mp3",
                Url = "http://stream.overdrivelive.net:8000/alternative_128.mp3",
                Title = "Overdrive Live! Station",
                Description = "",
                IsFavorite = true,
                AddedOn = DateTime.Now,
                LogoUrl = "https://static2.mytuner.mobi/media/tvos_radios/Ue6Sq9DTW5.png",
                Genre = "Alternative",
                Bitrate = 128,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 1
            };
            var hiphop = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/hiphop/mp3-192/streams/streema",
                Url = "http://streams.80s80s.de/hiphop/mp3-192/streams/streema",
                Title = "80s80s HipHop",
                Description = "80s80s HipHop",
                IsFavorite = false,
                AddedOn = DateTime.Now,
                LogoUrl = "https://images.80s80s.de/files/2022-05/80s80sHIPHOP_radio_logo.png?rect=0%2C0%2C3840%2C2160&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp",
                Genre = "80s Retro Hiphop",
                Bitrate = 192,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 2
            };
            var love = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/love/mp3-192/streams/streema",
                Url = "http://streams.80s80s.de/love/mp3-192/streams/streema",
                Title = "80s80s Love",
                Description = "80s80s Love",
                IsFavorite = false,
                AddedOn = DateTime.Now,
                LogoUrl = "https://images.80s80s.de/files/media/image/file/80s80s-hero-love-16-9_1.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=300&amp;h=169&amp;dpr=3&amp;fm=webp",
                Genre = "80s Retro",
                Bitrate = 192,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 7
            };
            var party = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/party/mp3-192/streams/streema",
                Url = "http://streams.80s80s.de/party/mp3-192/streams/streema",
                Title = "80s80s Partyhits",
                Description = "80s80s Partyhits",
                IsFavorite = false,
                AddedOn = DateTime.Now,
                LogoUrl = "https://images.80s80s.de/files/media/image/file/80s80s_party_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp",
                Genre = "80s Retro Partyhits",
                Bitrate = 192,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 7
            };
            var rock = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/rock/mp3-192",
                Url = "http://streams.80s80s.de/rock/mp3-192",
                Title = "80s80s Rock",
                Description = "80s80s Rock",
                IsFavorite = false,
                AddedOn = DateTime.Now,
                LogoUrl = "https://images.80s80s.de/files/media/image/file/80s80s_rock_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=736&amp;h=414&amp;dpr=1.25&amp;auto=format",
                Genre = "80s Retro Rock",
                Bitrate = 192,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 1
            };
            var wave = new Radio()
            {
                Id = "1f579891-5c86-4f06-8834-fe31d1591b01-http://streams.80s80s.de/wave/mp3-192/streams/streema",
                Url = "http://streams.80s80s.de/wave/mp3-192/streams/streema",
                Title = "80s80s Wave",
                Description = "80s80s Wave",
                IsFavorite = false,
                AddedOn = DateTime.Now,
                LogoUrl = "https://images.80s80s.de/files/media/image/file/80s80s_wave_16x9.jpg?rect=center%2Cmiddle%2C1920%2C1080&amp;fit=crop&amp;crop=faces&amp;w=400&amp;h=225&amp;dpr=3&amp;fm=webp",
                Genre = "80s Retro Wave",
                Bitrate = 192,
                OwnerId = "1f579891-5c86-4f06-8834-fe31d1591b01",
                GroupId = 3
            };
            radios.Add(insomniaFm);
            radios.Add(deepPlanet);
            radios.Add(progSpirit);
            radios.Add(friskyDeep);
            radios.Add(overdrive);
            radios.Add(rock);
            radios.Add(wave);
            radios.Add(hiphop);
            radios.Add(love);
            radios.Add(party);
            return radios;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>()
                .HasData(SeedUsers());

            builder.Entity<Radio>()
                .HasData(SeedRadios());

            builder.Entity<Group>()
                .HasData(SeedGroups());

            base.OnModelCreating(builder);
        }
    }
}
