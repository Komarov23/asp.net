using lab1.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatTimeController : Controller
    {
        private readonly TimeOfDayService _timeOfDayService;

        public WhatTimeController(TimeOfDayService timeOfDayService)
        {
            _timeOfDayService = timeOfDayService;
        }

        [HttpGet]
        public IActionResult GetWhatTime()
        {
            string timeOfDay = _timeOfDayService.GetTimeOfDay();
            return Ok($"Доброї пори доби. {timeOfDay}!");
        }
    }
}
