using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBZametkiApp.BLL.DTO;

namespace WEBZametkiApp.BLL.Interfaces
{
    public interface INoteService
    {
        void MakeNote(NoteDTO noteDTO);
        NoteDTO GetNote(int? id);
        IEnumerable<NoteDTO> GetNotes();
        void Dispose();
    }
}
