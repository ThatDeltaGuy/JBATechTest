using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JBATechTest.DAL
{
    class AppDBContext:DbContext
    {
        public DbSet<RainData> RainData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../../../RainData.db");
    }
}
