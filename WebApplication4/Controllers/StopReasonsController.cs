using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Service;
//using WebApplication4.Data;
//using WebApplication4.Data;
//using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopReasonsController : ControllerBase
    {
        ////PROPERTY
        private readonly IOEERepository _ioeerepository;

        //using constructor injection
        public StopReasonsController(IOEERepository oEERepository)
        {
            _ioeerepository = oEERepository;

        }

       
        [HttpGet("Newone")]
        public string Test()
        {
            //_dBOperationService.GetOEE();
            var test = _ioeerepository.GetOEEbyShift();
            //_dBOperationService.GetOEEbyShift();
            return "helldddo";
        }
     

        //[HttpGet("Newone1")]
        //public string Test1()
        //{
        //    //_dBOperationService.GetOEE();
        //    var test = _ioeerepository.GetOEEStopReasons();
        //    //_dBOperationService.GetOEEbyShift();
        //    return "1";
        //}


        //[HttpGet(Newone]
        //public async Task<ActionResult<IEnumerable<StopReasonsOverall>>> GetOeebyShiftOnly()
        //{
        //    if (_dbContext.StopReasonsOveralls == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _dbContext.StopReasonsOveralls.ToListAsync();
        //}

        ////// GET: api/Movies
        ////[HttpGet("oeeandjob")]
        //////[HttpGet]
        ////public async Task<ActionResult<IEnumerable<StopReasonsOverall>>> GetOeeandJob()
        ////{
        ////    if (_dbContext.StopReasonsOveralls == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    return await _dbContext.StopReasonsOveralls.ToListAsync();
        ////}

        ////[HttpGet("dailyavgoee")]
        //////[HttpGet]
        ////public async Task<ActionResult<IEnumerable<StopReasonsOverall>>> GetDailyAvgOee()
        ////{
        ////    if (_dbContext.StopReasonsOveralls == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    return await _dbContext.StopReasonsOveralls.ToListAsync();
        ////}
    }
}
