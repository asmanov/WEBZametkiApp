using Microsoft.AspNetCore.Mvc;
using WEBZametkiApp.BLL.DTO;
using WEBZametkiApp.BLL.Interfaces;
using WEBZametkiApp.WEB.Models;

namespace WEBZametkiApp.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        INoteService noteService;

        public NoteController(INoteService service)
        {
            noteService = service;
        }

        [HttpPost("newnote")]
        public ActionResult CreateNote(NoteViewModel noteView)
        {
            var noteDto = new NoteDTO() { Body = noteView.Body, Title = noteView.Title };
            noteService.MakeNote(noteDto);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<NoteViewModel>> GetAll()
        {
            IEnumerable<NoteDTO> noteDTOs = new List<NoteDTO>();
            noteDTOs = noteService.GetNotes();
            IEnumerable<NoteViewModel> result = new List<NoteViewModel>();
            foreach (var item in noteDTOs)
            {
                NoteViewModel noteViewModel = new NoteViewModel() { Id = item.Id, Title = item.Title, Body = item.Body, CreatedDate = item.CreatedDate };
                result = result.Concat(new[] { noteViewModel });
            }
            return Ok(result);
        }

        [HttpGet("one")]
        public ActionResult<NoteViewModel> Get(int id)
        {
            var noteDto = noteService.GetNote(id);
            NoteViewModel result = new NoteViewModel() { Id = id, Title = noteDto.Title, Body=noteDto.Body, CreatedDate = noteDto.CreatedDate };
            return Ok(result);
        }
    }
}
