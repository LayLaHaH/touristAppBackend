using DBContextTourist;
using DBContextTourist.Models;
using DBContextTourist.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HotelController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var hotels = _unitOfWork.HotelRepository.GetAll().Reverse();

            return Ok(hotels);
            /* Json(new
             {
                 success = true,
                 message = "All Data is back",
                 data = hotels
             })*/
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
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "Hotels", photoName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(stream);
            }

            // Return a success response
            return Ok("Photo uploaded successfully!");
        }

        [HttpPost("create")]
        public IActionResult create([FromForm] HotelVM hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Hotel _hotel=new Hotel { 
                Id = hotel.Id,
                Address = hotel.Address ,
                Url = hotel.Url ,
                Name = hotel.Name ,
                CityId = hotel.CityId ,
                ContactNumber = hotel.ContactNumber ,
                Image = hotel.Image ,
                ClassStar = hotel.ClassStar ,
                

            };


            _unitOfWork.HotelRepository.Add(_hotel);
            _unitOfWork.SaveChanges();


            return Ok(CreatedAtAction(nameof(getAll), new { id = hotel.Id }, hotel));

        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] HotelVM updatedData)
        {
            var existingRecord = _unitOfWork.HotelRepository.GetByID(id);

            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Name = updatedData.Name;
            existingRecord.ContactNumber = updatedData.ContactNumber;
            existingRecord.Address = updatedData.Address;
            existingRecord.ClassStar = updatedData.ClassStar;
            existingRecord.Url = updatedData.Url;
            existingRecord.Image = updatedData.Image;
            existingRecord.CityId = updatedData.CityId; 

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
            Hotel hotel = _unitOfWork.HotelRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                _unitOfWork.HotelRepository.Delete(hotel);
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
            var hotels = _unitOfWork.HotelRepository.GetAll();

            // Apply the filters
            if (!string.IsNullOrEmpty(value))
            {
                hotels = hotels.Where(h => h.Name.ToLower().Contains(value.ToLower()) ||
                                           h.Address.ToLower().Contains(value.ToLower()) ||
                                           h.ClassStar.ToString().Contains(value.ToLower()));
            }

            return Json(new
            {
                success = true,
                message = "Filtered data is back",
                data = hotels
            });
        }
    }
}
