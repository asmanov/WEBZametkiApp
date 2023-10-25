using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBZametkiApp.BLL.DTO;
using WEBZametkiApp.BLL.Infrastructure;
using WEBZametkiApp.BLL.Interfaces;
using WEBZametkiApp.BLL.Mapper;
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
            Database.Dispose();
        }

        public NoteDTO GetNote(int? id)
        {
            if (id == null) throw new ValidationException("Have not Note Id", "");
            Note note = Database.Notes.GetById(id.Value);
            if (note == null)
            {
                throw new ValidationException("Note don't found", "");
            }
            NoteDTO noteDTO = NoteMapper.MapToDTO(note);
            return noteDTO;
        }

        public IEnumerable<NoteDTO> GetNotes()
        {
            var notes = Database.Notes.GetAll();
            IEnumerable<NoteDTO> notesDTO = new List<NoteDTO>();
            foreach (var item in notes)
            {
                notesDTO.Append(NoteMapper.MapToDTO(item));
            }
            return notesDTO;
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
