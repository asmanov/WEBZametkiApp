using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WEBZametkiApp.DAL.EF;
using WEBZametkiApp.DAL.Entities;
using WEBZametkiApp.DAL.Interfaces;

namespace WEBZametkiApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly NoteDbContext db;
        private NoteRepository notesRepository;

        public EFUnitOfWork(DbContextOptions<NoteDbContext> options)
        {
            this.db = new NoteDbContext(options);
        }

        public IRepository<Note> Notes
        {
            get
            {
                if (notesRepository == null)
                    notesRepository = new NoteRepository(db);
                return notesRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
