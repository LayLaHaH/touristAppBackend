using DBContextTourist;
using DBContextTourist.IRepository;
using DBContextTourist.Models;
using RepositoriesAndUOW.Reopsitory;
using System;

namespace RepositoriesAndUOW
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly touristsContext _touristsContext;
        public ICityRepo CiryRepository { get; }
        public IActivityRepo ActivityRepository { get; }
        public IDestinationRepo DestinationRepository { get; }
        public IDestinationPicturesRepo DestinationPicturesRepository { get; }
        public IExcludesRepo ExcludesRepositoriy { get; }
        public IGovernorateRepo GovernorateRepository { get; }
        public IHotelRepo HotelRepository { get; }
        public IIncludesRepo IncludesRepository { get; }
        public IItineraryRepo ItineraryRepository { get; }
        public IMarketRepo MarketRepository { get; }
        public IRestaurantRepo RestaurantRepository { get; }
        public ITourCompanyRepo TourCompanyRepository { get; }
        public ITourHasActivityRepo TourHasActivityRepository { get; }
        public ITourHasDestinationRepo TourHasDestinationRepository { get; }
        public ITourRepo TourRepository { get; }

        public UnitOfWork(touristsContext touristsContext)
        {
            _touristsContext = touristsContext;

            ActivityRepository = new ActivityRepo(_touristsContext);
            CiryRepository = new CityRepo(_touristsContext);
            DestinationRepository = new DestinationRepo(_touristsContext);
            DestinationPicturesRepository = new DestinationPicturesRepo(_touristsContext);
            ExcludesRepositoriy = new ExcludesRepo(_touristsContext);
            GovernorateRepository = new GovernorateRepo(_touristsContext);
            HotelRepository = new HotelRepo(_touristsContext);
            IncludesRepository = new IncludesRepo(_touristsContext);
            ItineraryRepository = new ItineraryRepo(_touristsContext);
            MarketRepository = new MarketRepo(_touristsContext);
            RestaurantRepository = new RestaurantRepo(_touristsContext);
            TourCompanyRepository = new TourCompanyRepo(_touristsContext);
            TourHasActivityRepository = new TourHasActivityRepo(_touristsContext);
            TourHasDestinationRepository = new TourHasDestinationRepo(_touristsContext);
            TourRepository = new TourRepo(_touristsContext);

        }

        public int SaveChanges()
        {
            return _touristsContext.SaveChanges();
        }

        public void Dispose()
        {
            _touristsContext.Dispose();
        }
    }
}
