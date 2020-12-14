using BestTimes.Data;
using BestTimes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestTimes.Services
{
    public interface IBestTimesService
    {
        IEnumerable<BestTime> GetList();
        IEnumerable<BestTime> GetUnapproved();
        void CreateBestTime(BestTimeFormModel bestTimeFormModel);
        void ApproveBestTime(int id);
        void DeleteBestTime(int id);
    }
}
