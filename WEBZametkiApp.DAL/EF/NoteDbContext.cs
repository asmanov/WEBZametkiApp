using Microsoft.EntityFrameworkCore;
using WEBZametkiApp.DAL.Entities;

namespace WEBZametkiApp.DAL.EF
{
    public class NoteDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
        {

        }
    }
}
