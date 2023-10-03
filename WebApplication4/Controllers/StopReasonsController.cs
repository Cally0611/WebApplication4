using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using WebApplication4.Data;
//using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopReasonsController : ControllerBase
    {
        ////PROPERTY
        //private readonly OeedbcenterContext _dbContext;
        //public StopReasonsController(OeedbcenterContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //// GET: api/Movies
        ////[HttpGet]
        //[HttpGet("oeeonly")]
        //public async Task<ActionResult<IEnumerable<StopReasonsOverall>>> GetOeeOnly()
        //{
        //    if (_dbContext.StopReasonsOveralls == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _dbContext.StopReasonsOveralls.ToListAsync();
        //}

        //// GET: api/Movies
        //[HttpGet("oeeandjob")]
        ////[HttpGet]
        //public async Task<ActionResult<IEnumerable<StopReasonsOverall>>> GetOeeandJob()
        //{
        //    if (_dbContext.StopReasonsOveralls == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _dbContext.StopReasonsOveralls.ToListAsync();
        //}

        //[HttpGet("dailyavgoee")]
        ////[HttpGet]
        //public async Task<ActionResult<IEnumerable<StopReasonsOverall>>> GetDailyAvgOee()
        //{
        //    if (_dbContext.StopReasonsOveralls == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _dbContext.StopReasonsOveralls.ToListAsync();
        //}
    }
}
