using DBContextTourist;
using DBContextTourist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourCompanyController : BaseController
    {
        public TourCompanyController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var tourCompanies = _unitOfWork.TourCompanyRepository.GetAll().Reverse();

            return Ok(tourCompanies);
            /* Json(new
             {
                 success = true,
                 message = "All Data is back",
                 data = tourComopanies
             })*/
        }

        [HttpPost("create")]
        public IActionResult create([FromForm] TourCompany tourCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.TourCompanyRepository.Add(tourCompany);
            _unitOfWork.SaveChanges();


            return Ok(CreatedAtAction(nameof(getAll), new { id = tourCompany.Id }, tourCompany));

        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] TourCompany updatedData)
        {
            var existingRecord = _unitOfWork.TourCompanyRepository.GetByID(id);

            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Name = updatedData.Name;
            existingRecord.ContactNumber = updatedData.ContactNumber;
            existingRecord.Address = updatedData.Address;

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
            TourCompany tourCompany = _unitOfWork.TourCompanyRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                _unitOfWork.TourCompanyRepository.Delete(tourCompany);
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
