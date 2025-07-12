﻿using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using SANJUAN.Models;


namespace SANJUAN.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Docente> Docentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Docente)
                .WithMany()
                .HasForeignKey(c => c.IdDocente)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

