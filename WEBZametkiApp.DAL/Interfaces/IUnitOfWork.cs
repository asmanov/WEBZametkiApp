using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBZametkiApp.DAL.Entities;

namespace WEBZametkiApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Note> Notes { get; }
        void Save();
    }
}
