using BussinessLogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Notes;

namespace FundooNotes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {


        private readonly INoteBLL _noteBLL;

        public NoteController(INoteBLL noteBLL)
        {
            _noteBLL = noteBLL;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateNote(CreateNoteRequest createNoteRequest)
        {
            //int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            int userId = 21;

            NoteResponse result = _noteBLL.CreateNote(createNoteRequest, userId);

            return Ok(result);
        }
    }
}

