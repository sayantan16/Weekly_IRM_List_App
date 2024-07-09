using Microsoft.EntityFrameworkCore;
using WeeklyIRMListApp.Models;
using System;
using System.Collections.Generic;
using WeeklyIRMListApp.Models.ModelDTO;

namespace WeeklyIRMListApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public virtual DbSet<WeeklyIrmlist> WeeklyIrmlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeeklyIrmlist>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("WeeklyIRMList");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Applications)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.BuildType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ChangeTicket)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ElevatedPermission)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.IssueType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.MiddlewareTask)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PrerequisiteTicket)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Remarks)
                    .IsUnicode(false);
                entity.Property(e => e.Reporter)
                    .IsUnicode(false);
                entity.Property(e => e.ReviewStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Summary)
                    .IsUnicode(false);
                entity.Property(e => e.TakeoffsOwner)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WeeklyIrmlistDto>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Applications)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.BuildType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ChangeTicket)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ElevatedPermission)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.IssueType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.MiddlewareTask)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PrerequisiteTicket)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Remarks)
                    .IsUnicode(false);
                entity.Property(e => e.Reporter)
                    .IsUnicode(false);
                entity.Property(e => e.ReviewStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Summary)
                    .IsUnicode(false);
                entity.Property(e => e.TakeoffsOwner)
                    .HasMaxLength(50);
            });
        }
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
