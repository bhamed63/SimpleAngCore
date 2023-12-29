using System;
using System.Collections.Generic;

namespace Veri.Domain
{
    public class Entity
    {
        public int Id { get; set; }
    }
    public class Country : Entity
    {
        public Country()
        {

            this.HoliDays = new List<HoliDay>();
            this.WeekEnds = new List<WeekEnd>();
        }
        public String Name { get; set; }
        public String CurrenyType { get; set; }
        public decimal PenaltyPerDay { get; set; }
        public virtual List<WeekEnd> WeekEnds { get; set; }
        public virtual List<HoliDay> HoliDays { get; set; }

    }

    public class WeekEnd : Entity
    { 
        public DayOfWeek DayOfWeek { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

    public class HoliDay : Entity
    { 
        public DateTime Date { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}