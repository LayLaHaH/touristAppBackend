using DBContextTourist;
using DBContextTourist.Models;
using DBContextTourist.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DestinationController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        /* [HttpGet("getAll")]
         public IActionResult getAll()
         {
             var destinations = _unitOfWork.DestinationRepository.GetAll().Reverse();

             return Ok(destinations);

         }*/

        [HttpGet("getAll2")]
        public IActionResult getAll2()
        {
            var tours = _unitOfWork.DestinationRepository.GetAll2()
                        .Include(t => t.DestinationPictures)
                        .AsEnumerable()
                        .Reverse();

            return Ok(tours);
        }
        [HttpPost("upload-photos")]
        public async Task<IActionResult> UploadPhotos()
        {
            // Check if the request contains any files
            if (Request.Form.Files.Count == 0)
            {
                return BadRequest("No photos found in request");
            }

            try
            {
                // Get the list of photo files from the request
                var photoFiles = Request.Form.Files.ToList();

                // Save each photo to disk
                foreach (var photoFile in photoFiles)
                {
                    var fileName = photoFile.FileName;
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "Destinations", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photoFile.CopyToAsync(stream);
                    }
                }

                // Return a success response
                return Ok("Photos uploaded successfully!");
            }
            catch (Exception ex)
            {
                // Return an error response if something went wrong
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost("create")]
        public IActionResult create([FromForm] DestinationVM destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Destination _destination=new Destination { 
                Address = destination.Address ,
                Name = destination.Name ,
                Theme = destination.Theme ,
                Description = destination.Description ,
                CityId = destination.CityId ,
                Id = destination.Id ,

            };

            _unitOfWork.DestinationRepository.Add(_destination);
            _unitOfWork.SaveChanges();

            for (int i = 0; i < destination.selectedPictures.Count; i++)
            {
                var DestinationPictures = new DestinationPicture();
                DestinationPictures.DestId = _destination.Id;
                DestinationPictures.Picture = destination.selectedPictures[i];
                _unitOfWork.DestinationPicturesRepository.Add(DestinationPictures);
                _unitOfWork.SaveChanges();
            }


            return Ok(CreatedAtAction(nameof(getAll2), new { id = destination.Id }, destination));

        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] DestinationVM updatedData)
        {
            var existingRecord = _unitOfWork.DestinationRepository.GetByID(id);

            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Name = updatedData.Name;
            existingRecord.Description = updatedData.Description;
            existingRecord.Address = updatedData.Address;
            existingRecord.Theme = updatedData.Theme;
            existingRecord.CityId = updatedData.CityId;

            _unitOfWork.DestinationRepository.Update(existingRecord);
            _unitOfWork.SaveChanges();

            // Delete existing Destination pictures
            _unitOfWork.DestinationPicturesRepository.DeleteByDestinationId(existingRecord.Id);

            //add new pictures
            for (int i = 0; i < updatedData.selectedPictures.Count; i++)
            {
                var DestinationPictures = new DestinationPicture();
                DestinationPictures.DestId = existingRecord.Id;
                DestinationPictures.Picture = updatedData.selectedPictures[i];
                _unitOfWork.DestinationPicturesRepository.Add(DestinationPictures);
                _unitOfWork.SaveChanges();
            }

            return Ok(existingRecord);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            Destination destination = _unitOfWork.DestinationRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                _unitOfWork.DestinationPicturesRepository.DeleteByDestinationId(destination.Id);
                _unitOfWork.DestinationRepository.Delete(destination);
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
