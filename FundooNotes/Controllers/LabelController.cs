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

        [HttpPut("Update")]
        public IActionResult UpdateLabel(UpdateLabelRequest request)
        {
            try
            {
                int userId = Convert.ToInt32(
                    User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);

                var result = _labelBLL.UpdateLabel(request, userId);

                if (result != null)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Label Updated Successfully",
                        Data = result
                    });
                }

                return BadRequest(new
                {
                    Success = false,
                    Message = "Label Not Found"
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

        [HttpDelete("Delete")]
        public IActionResult DeleteLabel(int labelId)
        {
            try
            {
                int userId = Convert.ToInt32(
                    User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);

                bool result = _labelBLL.DeleteLabel(labelId, userId);

                if (result)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Label Deleted Successfully"
                    });
                }

                return BadRequest(new
                {
                    Success = false,
                    Message = "Label Not Found"
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


        [HttpPost("AddLabelToNote")]
        public IActionResult AddLabelToNote(AddLabelToNoteRequest request)
        {
            try
            {
                int userId = Convert.ToInt32(
                    User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

                bool result = _labelBLL.AddLabelToNote(request, userId);

                if (result)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Label Added To Note Successfully"
                    });
                }

                return BadRequest(new
                {
                    Success = false,
                    Message = "Failed To Add Label To Note"
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


        [HttpDelete("RemoveFromNote")]
        public IActionResult RemoveLabelFromNote(RemoveLabelFromNoteRequest request)
        {
            try
            {
                int userId = Convert.ToInt32(
                    User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

                bool result = _labelBLL.RemoveLabelFromNote(request, userId);

                if (result)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Label Removed From Note Successfully"
                    });
                }

                return BadRequest(new
                {
                    Success = false,
                    Message = "Failed To Remove Label From Note"
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
