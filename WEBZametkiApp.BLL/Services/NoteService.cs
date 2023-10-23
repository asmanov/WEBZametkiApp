using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBZametkiApp.BLL.DTO;
using WEBZametkiApp.BLL.Interfaces;
using WEBZametkiApp.DAL.Entities;
using WEBZametkiApp.DAL.Interfaces;

namespace WEBZametkiApp.BLL.Services
{
    public class NoteService : INoteService
    {
        IUnitOfWork Database { get; set; }

        public NoteService(IUnitOfWork database)
        {
            Database = database;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public NoteDTO GetNote(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NoteDTO> GetNotes()
        {
            throw new NotImplementedException();
        }

        public void MakeNote(NoteDTO noteDTO)
        {
            Note note = new Note()
            {
                Id = noteDTO.Id,
                Title = noteDTO.Title,
                Body = noteDTO.Body,
                CreatedDate = DateTime.Now
            };
            Database.Notes.Create(note);
            Database.Save();
        }
    }
}
