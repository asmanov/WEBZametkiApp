using Microsoft.EntityFrameworkCore;
using WEBZametkiApp.DAL.EF;
using WEBZametkiApp.DAL.Entities;
using WEBZametkiApp.DAL.Interfaces;

namespace WEBZametkiApp.DAL.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NoteDbContext db;

        public NoteRepository(NoteDbContext db)
        {
            this.db = db;
        }

        public void Create(Note entity)
        {
            db.Notes.Add(entity);
        }

        public void Delete(Note entity)
        {
            db.Notes.Remove(entity);
        }

        public IEnumerable<Note> Find(Func<Note, bool> predicate)
        {
            return db.Notes.Where(predicate).ToList();
        }

        public IEnumerable<Note> GetAll()
        {
            var result = db.Notes.ToList();
            return result;
        }

        public Note GetById(int id)
        {
            return db.Notes.Find(id);
        }

        public void Update(Note entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
