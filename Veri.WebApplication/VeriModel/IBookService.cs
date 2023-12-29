using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veri.Domain;

namespace Veri
{

    public interface IBookService
    {
        CalculatePenaltyResult Calculate(DateTime checkedOutDate, DateTime returnDate, int countryId);
    }

    public class BookService : IBookService
    {
        ICountryRepository _countryRepository;
        public BookService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public CalculatePenaltyResult Calculate(DateTime checkedOutDate, DateTime returnDate, int countryId)
        {
            var country = _countryRepository.GetCountry(countryId);
            var delay = getDalayDays(checkedOutDate, returnDate, country.WeekEnds, country.HoliDays);
            return new CalculatePenaltyResult(delay, delay * country.PenaltyPerDay, country.CurrenyType);
        }

        private int getDalayDays(DateTime checkedOutDate, DateTime returnDate, List<WeekEnd> weekEnds, List<HoliDay> holiDays)
        {
            if (returnDate.Date.Subtract(checkedOutDate.Date).TotalDays <= 10)
                return 0;

            int spentDays = 0;
            while (checkedOutDate <= returnDate)
            {
                if (!weekEnds.Any(c => c.DayOfWeek == checkedOutDate.DayOfWeek))
                {
                    if (!holiDays.Any(c => c.Date.Date == checkedOutDate))
                    {
                        spentDays++;
                    }
                }

                checkedOutDate = checkedOutDate.AddDays(1);
            }

            if (spentDays > 10)
                return spentDays - 10;
            return 0;
        }
    }

    public class CalculatePenaltyResult
    {
        public CalculatePenaltyResult(int delayDays, decimal penaltyAmount, string currenyType)
        {
            this.DelayDays = delayDays;
            this.PenaltyAmount = penaltyAmount;
            this.CurrenyType = currenyType;
        }
        public int DelayDays { get; set; }
        public decimal PenaltyAmount { get; set; }
        public String CurrenyType { get; set; }
    }
}
