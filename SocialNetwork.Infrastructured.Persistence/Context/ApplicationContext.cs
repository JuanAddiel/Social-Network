using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Domain.Common;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructured.Persistence.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry  in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Juan";
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now;
                        entry.Entity.UpdatedBy = "Juan";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Friend>().ToTable("friends");
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Comment>().ToTable("comments");

            modelBuilder.Entity<User>().HasKey(u=> u.Id);
            modelBuilder.Entity<User>().Property(u=>u.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(u=>u.LastName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(u=>u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u=>u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u=>u.Birthdate).IsRequired();
            modelBuilder.Entity<User>().Property(u=>u.Sexo).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Property(u=>u.Photo);

            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            modelBuilder.Entity<Post>().Property(u=>u.Content).IsRequired();
            modelBuilder.Entity<Post>().Property(p => p.imgUrl);
            modelBuilder.Entity<User>().HasMany<Post>(u => u.Posts).WithOne(p=>p.User).HasForeignKey(p=>p.UserId);

            modelBuilder.Entity<Comment>().HasKey(p => p.Id);
            modelBuilder.Entity<Comment>().Property(p => p.Content).IsRequired();
            modelBuilder.Entity<Post>().HasMany<Comment>(c => c.comments).WithOne(p=>p.Post).HasForeignKey(c=>c.PostId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany<Post>(c => c.Posts).WithOne(p=>p.User).HasForeignKey(c=>c.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Friend>().HasKey(p => p.Id);
            modelBuilder.Entity<Friend>().Property(f=>f.FriendshipDate).IsRequired();
            modelBuilder.Entity<User>().HasMany<Friend>(f => f.Friends).WithOne(f => f.User).HasForeignKey(f => f.UserIdFirst).HasForeignKey(f => f.UserIdLast);

        }
    }
}
