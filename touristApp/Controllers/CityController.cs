using DBContextTourist;
using DBContextTourist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBContextTourist.ViewModels;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CityController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("getAll")]
        public IActionResult GetCities()
        {
            var cities = _unitOfWork.CiryRepository.GetAll().Reverse();
            /*foreach (var city in cities)
            {
                city.Governerate = _unitOfWork.GovernorateRepository.GetByID(city.GovernerateId);
            }*/
            return Ok(cities);
        }

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
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img","Cities", photoName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(stream);
            }

            // Return a success response
            return Ok("Photo uploaded successfully!");
        }



        [HttpPost("create")]
        public IActionResult Create([FromForm] CityVM city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            City _city = new City
            {
                Id = city.Id,
                Name = city.Name,
                Description = city.Description,
                Picture = city.Picture,
                GovernerateId = city.GovernerateId,
            };
            _unitOfWork.CiryRepository.Add(_city);
            _unitOfWork.SaveChanges();
            return CreatedAtAction(nameof(GetCities), new { id = city.Id }, city);

        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] CityVM updatedData)
        {
            var existingRecord = _unitOfWork.CiryRepository.GetByID(id);

            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Name = updatedData.Name;
            existingRecord.Description = updatedData.Description;
            existingRecord.Picture = updatedData.Picture;
            existingRecord.GovernerateId = updatedData.GovernerateId;

            _unitOfWork.SaveChanges();

            return Json(new
            {
                success = true,
                message = "updated",
                data = existingRecord
            });
        }
        [HttpDelete("delete")]
        public IActionResult DeleteCity(int id)
        {
            City city = _unitOfWork.CiryRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                _unitOfWork.CiryRepository.Delete(city);
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
    }
}
