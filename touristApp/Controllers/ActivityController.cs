using DBContextTourist;
using DBContextTourist.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ActivityController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ActivityController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var activities = _unitOfWork.ActivityRepository.GetAll().Reverse();
            return Ok(activities);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Company")]
        [HttpPost("upload-photo")]
        public async Task<IActionResult> UploadPhoto()
        {
            // Check if the request contains a file
            if (Request.Form.Files.Count == 0)
            {
                return BadRequest("No photo found in request");
            }

            // Get the photo file and its name from the request
            var photoFile = Request.Form.Files[0];
            var photoName = Request.Form["photoName"];

            // Save the photo to disk
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "Activities", photoName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(stream);
            }

            // Return a success response
            return Ok("Photo uploaded successfully!");
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.ActivityRepository.Add(activity);
            _unitOfWork.SaveChanges();
            

            return CreatedAtAction(nameof(GetAll), new { id = activity.Id }, activity);

        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] Activity updatedData)
        {
            var existingRecord = _unitOfWork.ActivityRepository.GetByID(id);

            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Name = updatedData.Name;
            existingRecord.Description = updatedData.Description;
            existingRecord.Image = updatedData.Image;
            existingRecord.Price = updatedData.Price;
            existingRecord.StartTime = updatedData.StartTime;
            existingRecord.CloseTime = updatedData.CloseTime;
            existingRecord.StartingDay = updatedData.StartingDay;
            existingRecord.EndingDay = updatedData.EndingDay;
            
            _unitOfWork.SaveChanges();

            return Json(new
            {
                success = true,
                message = "updated",
                data = existingRecord
            });
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            Activity activity = _unitOfWork.ActivityRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                _unitOfWork.ActivityRepository.Delete(activity);
                _unitOfWork.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "deleted"

                }); ;
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet("search")]
        public IActionResult Search(string value)
        {
            var activities = _unitOfWork.ActivityRepository.GetAll();

            // Apply the filters
            if (!string.IsNullOrEmpty(value))
            {
                activities = activities.Where(h => h.Name.ToLower().Contains(value.ToLower()));
            }

            return Json(new
            {
                success = true,
                message = "Filtered data is back",
                data = activities
            });
        }
    }
}
