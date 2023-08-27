using DBContextTourist;
using DBContextTourist.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GovernorateController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var governorates = _unitOfWork.GovernorateRepository.GetAll().Reverse();
            
            return Ok(governorates);
           /* Json(new
            {
                success = true,
                message = "All Data is back",
                data = governorates
            })*/
        }

        [HttpGet("governorates/{id}/markets")]
        public IActionResult GetMarketsByGovernorate(int id)
        {
            var markets = _unitOfWork.GovernorateRepository.GetMarkets(id);

            if (markets == null)
            {
                return NotFound();
            }

            return Ok(markets);
        }
        [HttpGet("governorates/{id}/restaurants")]
        public IActionResult GetRestaurantsByGovernorate(int id)
        {
            var retaurants = _unitOfWork.GovernorateRepository.GetRestaurants(id);

            if (retaurants == null)
            {
                return NotFound();
            }

            return Ok(retaurants);
        }
        [HttpGet("governorates/{id}/hotels")]
        public IActionResult GetHotelsByGovernorate(int id)
        {
            var hotels = _unitOfWork.GovernorateRepository.GetHotels(id);

            if (hotels == null)
            {
                return NotFound();
            }


            return Ok(hotels);
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
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "Governorates", photoName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(stream);
            }

            // Return a success response
            return Ok("Photo uploaded successfully!");
        }



        [HttpPost("create")]
        public IActionResult create([FromForm] Governorate governorate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.GovernorateRepository.Add(governorate);
            _unitOfWork.SaveChanges();
            

            return Ok(CreatedAtAction(nameof(getAll), new { id = governorate.Id }, governorate));

        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] Governorate updatedData)
        {
            var existingRecord = _unitOfWork.GovernorateRepository.GetByID(id);

            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Name = updatedData.Name;
            existingRecord.Description = updatedData.Description;
            existingRecord.Picture = updatedData.Picture;

            _unitOfWork.SaveChanges();

            return Json(new
            {
                success = true,
                message = "updated",
                data = existingRecord
            });
        }
        [HttpDelete("delete")]
        public IActionResult DeleteGovernorate(int id)
        {
            Governorate governorate = _unitOfWork.GovernorateRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                _unitOfWork.GovernorateRepository.Delete(governorate);
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

