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
            int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
          

            NoteResponse result = _noteBLL.CreateNote(createNoteRequest, userId);

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateNote/{notesId}")]
        public IActionResult UpdateNote( int notesId,UpdateNoteRequest updateNoteRequest)
        {
            int userId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            NoteResponse result =
                _noteBLL.UpdateNote(notesId,userId,updateNoteRequest);

            return Ok(result);
        }


        [Authorize]
        [HttpGet]
        [Route("GetAllNotes")]
        public IActionResult GetAllNotes()
        {
            int userId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            List<NoteResponse> result =
                _noteBLL.GetAllNotes(userId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("GetNoteById/{notesId}")]
        public IActionResult GetNoteById(int notesId)
        {
            int userId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            NoteResponse result =
                _noteBLL.GetNoteById(notesId, userId);

            if (result == null)
            {
                return NotFound("Note Not Found");
            }

            return Ok(result);
        }


        [Authorize]
        [HttpDelete]
        [Route("DeleteNote/{notesId}")]
        public IActionResult DeleteNote(int notesId)
        {
            int userId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            bool result = _noteBLL.DeleteNote(notesId, userId);

            if (!result)
            {
                return NotFound("Note Not Found");
            }

            return Ok("Note Deleted Successfully");
        }

        [Authorize]
        [HttpPut]
        [Route("MoveToTrash/{notesId}")]
        public IActionResult MoveToTrash(int notesId)
        {
            int userId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            bool result = _noteBLL.MoveToTrash(notesId, userId);

            if (!result)
            {
                return NotFound("Note Not Found");
            }

            return Ok("Note Moved To Trash Successfully");
        }


        [Authorize]
        [HttpGet]
        [Route("GetTrashedNotes")]
        public IActionResult GetTrashedNotes()
        {
            int userId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            List<NoteResponse> result =
                _noteBLL.GetTrashedNotes(userId);

            return Ok(result);
        }
    }
}

