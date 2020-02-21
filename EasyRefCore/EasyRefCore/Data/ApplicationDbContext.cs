using EasyRefCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Coach> Coach { get; set; }
        public DbSet<Referee> Referee { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GameFieldSize> GameFieldSize { get; set; }
        public DbSet<GameDivision> GameDivison { get; set; }
        public DbSet<GameAge> GameAge { get; set; }
        public DbSet<GameGender> GameGender { get; set; }

        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Game>()

       .HasOne(q => q.Referee)
       .WithMany(x => x.GameReferee)
       .HasForeignKey(q => q.RefereeId)
       .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()
      .HasOne(q => q.SecondReferee)
      .WithMany(x => x.GameSecondReferee)
      .HasForeignKey(q => q.SecondRefereeId)
      .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()
      .HasOne(q => q.ThirdReferee)
      .WithMany(x => x.GameThirdReferee)
      .HasForeignKey(q => q.ThirdRefereeId)
      .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()

     .HasOne(q => q.GameFieldSize)
     .WithMany(x => x.Games)
     .HasForeignKey(q => q.GameFieldSizeId)
     .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()
      .HasOne(q => q.GameAge)
      .WithMany(x => x.Game)
      .HasForeignKey(q => q.GameAgeId)
      .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()
     .HasOne(q => q.GameGender)
     .WithMany(x => x.Games)
     .HasForeignKey(q => q.GameGenderId)
     .OnDelete(DeleteBehavior.NoAction);



            base.OnModelCreating(builder);
        }
    }


    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            
            //builder.Entity<GameRegion>().HasData(new { Id = 1, RegionName = "Dalarna" }, new { Id = 2, RegionName = "Gästrikland" }, new { Id = 3, RegionName = "Värmland" });
            //builder.Entity<GameLocation>().HasData(new { Id = 1, Location = "Hedemora", RegionId = 1 });

            //builder.Entity<GameFieldSize>().HasData(new { Id = 1, FieldSize = 5 }, new { Id = 2, FieldSize = 7 }, new { Id = 3, FieldSize = 11 });

            //builder.Entity<GameFieldSize>().HasData(new { Id = 1, FieldSize = 5 }, new { Id = 2, FieldSize = 7 }, new { Id = 3, FieldSize = 11 });

            //for (int i = 0; i < 80; i++)
            //{
            //    builder.Entity<GamePlayAge>().HasData(new { Id = i+1, Age = i+1 });
            //}

            //builder.Entity<GameGender>().HasData(new { Id = 1, Gender = 'P' }, new { Id = 2, Gender = 'F' });

        }
    }

}
