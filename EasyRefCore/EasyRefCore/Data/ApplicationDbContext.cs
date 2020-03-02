using EasyRefCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");


            builder.Entity<IdentityRole<int>>().ToTable("Roles");




            builder.Entity<IdentityUserRole<int>>().ToTable("UserRole");

                

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
        }





        public DbSet<Game> Game { get; set; }
        public DbSet<GameFieldSize> GameFieldSize { get; set; }
        public DbSet<GameDivision> GameDivison { get; set; }
        public DbSet<GameAge> GameAge { get; set; }
        public DbSet<GameGender> GameGender { get; set; }


    }
          
        }
    


   


