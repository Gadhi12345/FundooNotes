using BussinessLogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Notes;
using System.Linq;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController:ControllerBase
    {
        
          private readonly ILabelBLL _labelBLL;

            public LabelController(ILabelBLL labelBLL)
            {
                _labelBLL = labelBLL;
            }



        [HttpPost("Create")]
        public IActionResult CreateLabel(CreateLabelRequest request)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault
                              (c => c.Type == "UserId")?.Value);

                var result = _labelBLL.CreateLabel(request, userId);

                if (result != null)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Label Created Successfully",
                        Data = result
                    });
                }

                return BadRequest(new
                {
                    Success = false,
                    Message = "Label Creation Failed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
