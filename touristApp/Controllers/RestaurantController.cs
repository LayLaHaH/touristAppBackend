using DBContextTourist;
using DBContextTourist.Models;
using DBContextTourist.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RestaurantController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var restaurants = _unitOfWork.RestaurantRepository.GetAll().Reverse();

            return Ok(restaurants);
            /* Json(new
             {
                 success = true,
                 message = "All Data is back",
                 data = restaurants
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
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "Restaurants", photoName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(stream);
            }

            // Return a success response
            return Ok("Photo uploaded successfully!");
        }

        [HttpPost("create")]
        public IActionResult create([FromForm] RestaurantVM restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Restaurant _restaurant = new Restaurant { 
                CityId = restaurant.CityId, 
                Id = restaurant.Id,
                Image=restaurant.Image,
                ClassStar=restaurant.ClassStar,
                ClosingHour=restaurant.ClosingHour,
                OpeningHour=restaurant.OpeningHour,
                Cuisine=restaurant.Cuisine,
                ContactNumber=restaurant.ContactNumber,
                Address=restaurant.Address,
                Name=restaurant.Name,
                Url=restaurant.Url,
            }; 

            _unitOfWork.RestaurantRepository.Add(_restaurant);
            _unitOfWork.SaveChanges();


            return Ok(CreatedAtAction(nameof(getAll), new { id = restaurant.Id }, restaurant));

        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] RestaurantVM updatedData)
        {
            var existingRecord = _unitOfWork.RestaurantRepository.GetByID(id);

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
            existingRecord.OpeningHour = updatedData.OpeningHour;
            existingRecord.ClosingHour = updatedData.ClosingHour;
            existingRecord.Cuisine = updatedData.Cuisine;
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
            Restaurant restaurant = _unitOfWork.RestaurantRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                _unitOfWork.RestaurantRepository.Delete(restaurant);
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
            var restaurants = _unitOfWork.RestaurantRepository.GetAll();

            // Apply the filters
            if (!string.IsNullOrEmpty(value))
            {
                restaurants = restaurants.Where(r => r.Name.ToLower().Contains(value.ToLower()) ||
                                                     r.Address.ToLower().Contains(value.ToLower()) ||
                                                     r.ClassStar.ToString().Contains(value.ToLower())||
                                                     r.Cuisine.ToLower().Contains(value.ToLower()));
            }

            return Json(new
            {
                success = true,
                message = "Filtered data is back",
                data = restaurants
            });
        }
    }
}
