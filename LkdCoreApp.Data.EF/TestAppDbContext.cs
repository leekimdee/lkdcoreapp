using LkdCoreApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LkdCoreApp.Data.EF
{
    public class TestAppDbContext : IdentityDbContext
    {
        public TestAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Image> Images { get; set; }
        public DbSet<ImageAlbum> ImageAlbums { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
