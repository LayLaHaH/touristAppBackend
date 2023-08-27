
using DBContextTourist;
using Microsoft.AspNetCore.Mvc;
namespace touristApp.Controllers
{
    public class BaseController : Controller
    {
        
        protected IUnitOfWork _unitOfWork;
        
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
