﻿using Microsoft.EntityFrameworkCore;
using WebApplicationAPIDemo.Models;

namespace WebApplicationAPIDemo.Data
{
    public class APIDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public APIDbContext(DbContextOptions<APIDbContext> options):base(options) { }
 
    }
}
