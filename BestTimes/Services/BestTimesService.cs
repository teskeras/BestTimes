using AutoMapper;
using BestTimes.Data;
using BestTimes.Data.Repository;
using BestTimes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestTimes.Services
{
    public class BestTimesService : IBestTimesService
    {
        private readonly IBestTimeRepository bestTimeRepository;
        private readonly IMapper mapper;

        public BestTimesService(IBestTimeRepository bestTimeRepository, IMapper mapper)
        {
            this.bestTimeRepository = bestTimeRepository;
            this.mapper = mapper;
        }

        public IEnumerable<BestTime> GetList()
        {
            return bestTimeRepository.Query().Where(x => x.Approved).ToList().OrderBy(x => x.Hours).ThenBy(x => x.Minutes).ThenBy(x => x.Seconds).ThenBy(x => x.Miliseconds);
        }

        public IEnumerable<BestTime> GetUnapproved()
        {
            return bestTimeRepository.Query().Where(x => !x.Approved).ToList();
        }

        public void CreateBestTime(BestTimeFormModel bestTimeFormModel)
        {

            var bestTime = mapper.Map<BestTime>(bestTimeFormModel);
            bestTimeRepository.Insert(bestTime);
            bestTimeRepository.Commit();
        }

        public void ApproveBestTime(int id)
        {
            var bestTime = bestTimeRepository.Query().FirstOrDefault(x => x.Id == id);
            if (bestTime == null)
            {
                return;
            }
            bestTime.Approved = true;
            bestTimeRepository.Update(bestTime);
            bestTimeRepository.Commit();
        }

        public void DeleteBestTime(int id)
        {
            var bestTime = bestTimeRepository.Query().FirstOrDefault(x => x.Id == id);
            if (bestTime == null)
            {
                return;
            }
            bestTimeRepository.Delete(bestTime);
            bestTimeRepository.Commit();
        }
    }
}
