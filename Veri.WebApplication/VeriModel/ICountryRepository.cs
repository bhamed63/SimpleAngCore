using Microsoft.EntityFrameworkCore;
using System.Linq;
using Veri.DBContext;
using Veri.Domain;

namespace Veri
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountry(int id);
    }

    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(MyDBContext dbContext)
            : base(dbContext)
        {

        }

        public Country GetCountry(int id)
        {
            return _dbContext.Countries
                .Include(c => c.WeekEnds)
                .Include(c => c.HoliDays)
                .Single(c => c.Id == id);
        }
    }
}
