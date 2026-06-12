using BussinessLogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Collaborator;
using ModelLayer.Entity;
using System.Security.Claims;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorBLL _collaboratorBLL;

        public CollaboratorController(ICollaboratorBLL collaboratorBLL)
        {
            _collaboratorBLL = collaboratorBLL;
        }

        [HttpPost("{noteId}")]
        public IActionResult AddCollaborator(int noteId, AddCollaboratorRequest request)
        {
            int ownerUserId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            bool result = _collaboratorBLL.AddCollaborator(
                noteId,
                ownerUserId,
                request);

            if (result)
            {
                return Ok(new
                {
                    success = true,
                    message = "Collaborator added successfully"
                });
            }

            return BadRequest(new
            {
                success = false,
                message = "Unable to add collaborator"
            });
        }
        [HttpGet("{noteId}")]
        public IActionResult GetCollaborators(int noteId)
        {
            int ownerUserId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            var result = _collaboratorBLL.GetCollaborators(
                noteId,
                ownerUserId);

            return Ok(result);
        }
    }
}
