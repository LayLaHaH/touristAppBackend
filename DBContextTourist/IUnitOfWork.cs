using DBContextTourist.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        ICityRepo CiryRepository { get; }
        IActivityRepo ActivityRepository { get; }
        IDestinationRepo DestinationRepository { get; }
        IDestinationPicturesRepo DestinationPicturesRepository { get; }
        IExcludesRepo ExcludesRepositoriy { get; }
        IGovernorateRepo GovernorateRepository { get; }
        IHotelRepo HotelRepository { get; }
        IIncludesRepo IncludesRepository { get; }
        IItineraryRepo ItineraryRepository { get; }
        IMarketRepo MarketRepository { get; }
        IRestaurantRepo RestaurantRepository { get; }
        ITourCompanyRepo TourCompanyRepository { get; }
        ITourHasActivityRepo TourHasActivityRepository { get; }
        ITourHasDestinationRepo TourHasDestinationRepository { get; }
        ITourRepo TourRepository { get; }


    }
}
