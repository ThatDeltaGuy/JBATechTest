using Microsoft.EntityFrameworkCore;

namespace JBATechTest.DAL
{
    /// <summary>
    /// Main Data Access Layer for database
    /// </summary>
    class AppDBContext:DbContext
    {
        public DbSet<RainData> RainData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)//In Reality a full SQL server would be set up but for Demonstration purposes SQLite is used.  
            => options.UseSqlite("Data Source=../../../RainData.db");
    }
}
