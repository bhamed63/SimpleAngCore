using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Veri.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPatch("{id}")]
        public CalculatePenaltyResponse Put(int id, [FromBody] CalculatePenaltyRequest value)
        {
            var result = _bookService.Calculate(value.CheckedOutDate, value.ReturnDate, id);
            return new CalculatePenaltyResponse() { CountryId = id, 
                DelayDays = result.DelayDays,
                PenaltyAmount = result.PenaltyAmount, 
                CurrenyType = result.CurrenyType };
        }
    }

    public class CalculatePenaltyRequest
    {
        public DateTime CheckedOutDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CountryId { get; set; }
    }

    public class CalculatePenaltyResponse
    {
        public decimal PenaltyAmount { get; set; }
        public int CountryId { get; set; }
        public int DelayDays { get; set; }
        public String CurrenyType { get; set; }
    }
}
