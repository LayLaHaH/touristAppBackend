using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface IDestinationPicturesRepo : IBaseRepo<DestinationPicture>
    {
        void DeleteByDestinationId(int destId);

    }
}
