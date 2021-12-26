using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdevSonHali.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MovieWebApp_ASP.NET.Models;

namespace OdevSonHali.Data
{
    public class ApplicationDbContext : IdentityDbContext<YourStoryUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieWebApp_ASP.NET.Models.Comment> Comment { get; set; }
        public DbSet<MovieWebApp_ASP.NET.Models.Story> Story { get; set; }
        public DbSet<MovieWebApp_ASP.NET.Models.Category> Category { get; set; }
        public DbSet<MovieWebApp_ASP.NET.Models.Liked> Liked { get; set; }
    }
}
