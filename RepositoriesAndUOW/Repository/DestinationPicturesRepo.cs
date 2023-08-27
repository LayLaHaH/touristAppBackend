using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class DestinationPicturesRepo : BaseRepo<DestinationPicture>, IDestinationPicturesRepo
    {
        public DestinationPicturesRepo(touristsContext touristsContext) : base(touristsContext)
        {
        }

        public void DeleteByDestinationId(int destId)
        {
            var pictures = _touristsContext.Set<DestinationPicture>().Where(i => i.DestId == destId);
            _touristsContext.Set<DestinationPicture>().RemoveRange(pictures);
        }
    }
}
