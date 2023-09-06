using DBContextTourist;
using DBContextTourist.Models;
using DBContextTourist.ViewModels;
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
        public IActionResult create([FromForm] TourCompanyVM tourCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TourCompany _company = new TourCompany
            {
                Name = tourCompany.Name,
                ContactNumber = tourCompany.ContactNumber,
                Address = tourCompany.Address,
                UserId = tourCompany.UserId,
            };

            _unitOfWork.TourCompanyRepository.Add(_company);
            _unitOfWork.SaveChanges();
             var companyID=_company.Id;

            return Ok(companyID);
        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] TourCompanyVM updatedData)
        {
            var existingRecord = _unitOfWork.TourCompanyRepository.GetByID(id);

            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Name = updatedData.Name;
            existingRecord.ContactNumber = updatedData.ContactNumber;
            existingRecord.Address = updatedData.Address;
            existingRecord.UserId = updatedData.UserId;

            _unitOfWork.TourCompanyRepository.Update(existingRecord);
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
