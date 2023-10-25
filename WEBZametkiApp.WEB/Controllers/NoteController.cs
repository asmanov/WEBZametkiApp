using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBZametkiApp.BLL.Interfaces;

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

        [HttpGet("All")]


    }
}
