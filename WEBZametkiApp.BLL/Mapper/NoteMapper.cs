using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBZametkiApp.BLL.DTO;
using WEBZametkiApp.DAL.Entities;

namespace WEBZametkiApp.BLL.Mapper
{
    public static class NoteMapper
    {
        public static NoteDTO MapToDTO(Note note)
        {
            return new NoteDTO
            {
                Id = note.Id,
                Title = note.Title,
                Body = note.Body
            };
        }

        public static Note MapToDAL(NoteDTO noteDTO)
        {
            return new Note
            {
                Id = noteDTO.Id,
                Title = noteDTO.Title,
                Body = noteDTO.Body
            };
        }
    }
}
