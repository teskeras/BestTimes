namespace BestTimes.Data.Repository
{
    public class BestTimeRepository : BaseRepository<BestTime>, IBestTimeRepository
    {
        public BestTimeRepository(BestTimesContext dbContext) : base(dbContext)
        {
        }
    }
}
