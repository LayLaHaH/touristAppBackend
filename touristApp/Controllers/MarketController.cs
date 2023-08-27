using DBContextTourist;
using DBContextTourist.Models;
using DBContextTourist.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MarketController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet("getAll")]
        public IActionResult GetMarkets()
        {
            var markets = _unitOfWork.MarketRepository.GetAll().Reverse();
            return Ok(markets);
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
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "Markets", photoName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(stream);
            }

            // Return a success response
            return Ok("Photo uploaded successfully!");
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] MarketVM market)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Market _market=new Market { 
                CityId = market.CityId ,
                Id = market.Id ,
                Image=market.Image ,
                Name=market.Name ,
                Description=market.Description ,
            };

            _unitOfWork.MarketRepository.Add(_market);
            _unitOfWork.SaveChanges();
          

            return CreatedAtAction(nameof(GetMarkets), new { id = market.Id }, market);

        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] MarketVM updatedData)
        {
            var existingRecord = _unitOfWork.MarketRepository.GetByID(id);

            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Name = updatedData.Name;
            existingRecord.Description = updatedData.Description;
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
            Market market = _unitOfWork.MarketRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                _unitOfWork.MarketRepository.Delete(market);
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
            var markets = _unitOfWork.MarketRepository.GetAll();

            // Apply the filters
            if (!string.IsNullOrEmpty(value))
            {
                markets = markets.Where(m => m.Name.ToLower().Contains(value.ToLower()));
            }

            return Json(new
            {
                success = true,
                message = "Filtered data is back",
                data = markets
            });
        }
    }
}
