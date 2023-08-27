using DBContextTourist;
using DBContextTourist.Models;
using DBContextTourist.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : BaseController
    {
       
        public TourController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        [HttpGet("getAll2")]
        public IActionResult getAll2()
        {
            var tours = _unitOfWork.TourRepository.GetAll2()
                        .Include(t => t.Excludes)
                        .Include(t => t.Includes)
                        .Include(t => t.Itineraries)
                        .Include(t => t.TourHasActivities)
                            .ThenInclude(tha => tha.Activity)
                        .Include(t => t.TourHasDestinations)
                            .ThenInclude(thd => thd.Dest)
                                .ThenInclude(pic=>pic.DestinationPictures)
                        .AsEnumerable()
                        .Reverse();

            return Ok(tours);
        }

        [HttpGet("{id}/destination-pictures")]
        public IActionResult GetDestinationPictures(int id)
        {
            var destinationIds = _unitOfWork.TourHasDestinationRepository.GetAll()
                                   ;
            var destIds=new List<int>();
            foreach (var destinationId in destinationIds)
                if(destinationId.TourId==id)
                    destIds.Add(destinationId.DestId);

            var pictures = _unitOfWork.DestinationPicturesRepository.GetAll();
            var pictureNames=new List<string>();
            foreach (var destId in destIds)
            {
                foreach (var picture in pictures)
                {
                    if (picture.DestId == destId)
                        pictureNames.Add(picture.Picture);
                }
            }

            return Ok(pictureNames);
        }

        [HttpPost("create")]
        public IActionResult create([FromForm] TourVM tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tour _tour = new Tour { 
                CompanyId = tour.CompanyId,
                Id = tour.Id,
                Name = tour.Name,
                DaysNnights = tour.DaysNnights,
                Cost = tour.Cost,
                Theme = tour.Theme,
                IsPrivate = tour.IsPrivate,
                GuidLanguage=tour.GuidLanguage,
                
            };
            _unitOfWork.TourRepository.Add(_tour);
            _unitOfWork.SaveChanges();

            for (int i = 0; i < tour.InsertedIncludes.Count; i++)
            {
                var include = new Include();
                include.TourId = _tour.Id;
                include.Includes = tour.InsertedIncludes[i];
                _unitOfWork.IncludesRepository.Add(include);
                _unitOfWork.SaveChanges();
            }
            for (int i = 0; i < tour.SelectedDestinations.Count; i++)
            {
                var tourDest = new TourHasDestination();
                tourDest.TourId = _tour.Id;
                tourDest.DestId = tour.SelectedDestinations[i];
                _unitOfWork.TourHasDestinationRepository.Add(tourDest);
                _unitOfWork.SaveChanges();
            }
            for (int i = 0; i < tour.SelectedActivities.Count; i++)
            {
                var tourAct = new TourHasActivity();
                tourAct.TourId = _tour.Id;
                tourAct.ActivityId = tour.SelectedActivities[i];
                _unitOfWork.TourHasActivityRepository.Add(tourAct);
                _unitOfWork.SaveChanges();
            }
            
            for (int i = 0; i < tour.InsertedExcludes.Count; i++)
            {
                var excludes = new Exclude();
                excludes.TourId = _tour.Id;
                excludes.Excludes = tour.InsertedExcludes[i];
                _unitOfWork.ExcludesRepositoriy.Add(excludes);
                _unitOfWork.SaveChanges();
            }
            for (int i = 0; i < tour.InsertedItineraries.Count; i++)
            {
                var itinerary = new Itinerary();
                itinerary.TourId = _tour.Id;
                itinerary.EachDayDescription = tour.InsertedItineraries[i];
                _unitOfWork.ItineraryRepository.Add(itinerary);
                _unitOfWork.SaveChanges();
            }

            return Ok(CreatedAtAction(nameof(getAll2), new { id = tour.Id }, tour));

        }

       
        [HttpPut("update")]
        public IActionResult update(int id, [FromForm] TourVM tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tour _tour = _unitOfWork.TourRepository.GetByID(id);
            if (_tour == null)
            {
                return NotFound();
            }

            _tour.CompanyId = tour.CompanyId;
            _tour.Name = tour.Name;
            _tour.DaysNnights = tour.DaysNnights;
            _tour.Cost = tour.Cost;
            _tour.Theme = tour.Theme;
            _tour.IsPrivate = tour.IsPrivate;
            _tour.GuidLanguage = tour.GuidLanguage;

            _unitOfWork.TourRepository.Update(_tour);
            _unitOfWork.SaveChanges();

            // Delete existing includes, destinations, activities, excludes, and itineraries
            _unitOfWork.IncludesRepository.DeleteByTourId(_tour.Id);
            _unitOfWork.TourHasDestinationRepository.DeleteByTourId(_tour.Id);
            _unitOfWork.TourHasActivityRepository.DeleteByTourId(_tour.Id);
            _unitOfWork.ExcludesRepositoriy.DeleteByTourId(_tour.Id);
            _unitOfWork.ItineraryRepository.DeleteByTourId(_tour.Id);
            _unitOfWork.SaveChanges();

            // Add new includes, destinations, activities, excludes, and itineraries
            for (int i = 0; i < tour.InsertedIncludes.Count; i++)
            {
                var include = new Include();
                include.TourId = _tour.Id;
                include.Includes = tour.InsertedIncludes[i];
                _unitOfWork.IncludesRepository.Add(include);
                _unitOfWork.SaveChanges();
            }
            for (int i = 0; i < tour.SelectedDestinations.Count; i++)
            {
                var tourDest = new TourHasDestination();
                tourDest.TourId = _tour.Id;
                tourDest.DestId = tour.SelectedDestinations[i];
                _unitOfWork.TourHasDestinationRepository.Add(tourDest);
                _unitOfWork.SaveChanges();
            }
            for (int i = 0; i < tour.SelectedActivities.Count; i++)
            {
                var tourAct = new TourHasActivity();
                tourAct.TourId = _tour.Id;
                tourAct.ActivityId = tour.SelectedActivities[i];
                _unitOfWork.TourHasActivityRepository.Add(tourAct);
                _unitOfWork.SaveChanges();
            }

            for (int i = 0; i < tour.InsertedExcludes.Count; i++)
            {
                var excludes = new Exclude();
                excludes.TourId = _tour.Id;
                excludes.Excludes = tour.InsertedExcludes[i];
                _unitOfWork.ExcludesRepositoriy.Add(excludes);
                _unitOfWork.SaveChanges();
            }
            for (int i = 0; i < tour.InsertedItineraries.Count; i++)
            {
                var itinerary = new Itinerary();
                itinerary.TourId = _tour.Id;
                itinerary.EachDayDescription = tour.InsertedItineraries[i];
                _unitOfWork.ItineraryRepository.Add(itinerary);
                _unitOfWork.SaveChanges();
            }

            return Ok(_tour);
        }





        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            Tour tour = _unitOfWork.TourRepository.GetByID(id);
            if (ModelState.IsValid)
            {
                // Delete existing includes, destinations, activities, excludes, and itineraries
                _unitOfWork.IncludesRepository.DeleteByTourId(tour.Id);
                _unitOfWork.TourHasDestinationRepository.DeleteByTourId(tour.Id);
                _unitOfWork.TourHasActivityRepository.DeleteByTourId(tour.Id);
                _unitOfWork.ExcludesRepositoriy.DeleteByTourId(tour.Id);
                _unitOfWork.ItineraryRepository.DeleteByTourId(tour.Id);
                _unitOfWork.TourRepository.Delete(tour);
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
