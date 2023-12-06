using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using WebApplication4.Helpers;
using WebApplication4.Models;
using WebApplication4.Service;
using static System.Net.Mime.MediaTypeNames;

//using WebApplication4.Data;
//using WebApplication4.Data;
//using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopReasonsController : ControllerBase
    {
        //////PROPERTY
       private readonly IOEERepository _ioeerepository;
        ////private readonly TimedHostedService _timedHostedService;

        ////using constructor injection
        public StopReasonsController(IOEERepository oEERepository)
        {
            _ioeerepository = oEERepository;

        }

        //This part
        [HttpGet("DailyOEE")]
        public string DailyOEE()
        {


            List<OeeDaily> test = _ioeerepository.GetOEEDailyCalculationAll().ToList();

            List<OeeDaily> cleaned = test.Where(x => !ExcludeMachineID.ExcludeNonOrlofs().Contains(x.MachineId)).ToList();

            Dictionary<int, List<OeeDaily>> setsGroups = cleaned
                        .GroupBy(kvp => kvp.MachineId)
                        .ToDictionary(grp => grp.Key, grp => grp.ToList());


            foreach (KeyValuePair<int,List<OeeDaily>> entry in setsGroups)
            {
                decimal? sumofOEE = Convert.ToDecimal(0.00);
                int lastnullvalueindex = 1;
                for(int i = 0; i<entry.Value.Count; i++)
                {
                    //fill the average OEE value
                    if(entry.Value[i].OEE != null)
                    {
                        sumofOEE += entry.Value[i].OEE;
                        entry.Value[i].OEEAveragePercentage = sumofOEE / lastnullvalueindex;
                        lastnullvalueindex = i;
                    }
                    else
                    {
                        //get the last null value
                        lastnullvalueindex = lastnullvalueindex + 0;
                        entry.Value[i].OEEAveragePercentage = sumofOEE / lastnullvalueindex;
                    }
                   
                    
                }
            }

            return JsonConvert.SerializeObject(setsGroups);
        }
        //Till here

        [HttpGet("ByJob")]
        public string ByJobs()
        {
            //check what job is running today, based on those jobs get the dates
           // DateTime currdate = new DateTime(2023, 11, 08); 
            DateTime currdate = DateTime.Now;
            List<AllMachine> lom = _ioeerepository.SP_GetAllMachines().Where(x => x.TargetDate == currdate.Date).ToList();

           




            IDictionary<int, OEEbyJob> machineandjob = lom.DistinctBy(x => x.MachineId)
             .Where(x => !ExcludeMachineID.ExcludeNonOrlofs().Contains(x.MachineId))
                 .Select(i => new KeyValuePair<int, OEEbyJob>(i.MachineId, new OEEbyJob
                {
                    JobName = i.JobName1,
                    //ParentReasonCode_FullDay = Convert.ToInt32(i.ParentReasonCodeFullDay),
                    CurrentDate = currdate,
                    JobRunDates = _ioeerepository.SP_GetAllMachines().Where(x => !ExcludeMachineID.ExcludeNonOrlofs().Contains(x.MachineId) && x.JobName1 == i.JobName1 && x.ParentReasonCodeFullDay == "1")
                    .Select(x => x.TargetDate).ToArray(),
                    ListofMachines = _ioeerepository.SP_GetAllMachines().Where(x => !ExcludeMachineID.ExcludeNonOrlofs().Contains(x.MachineId) && x.JobName1 == i.JobName1 && x.ParentReasonCodeFullDay == "1")
                    .DistinctBy(x => x.MachineId)
                    .Select(x => x.MachineId).ToArray()
                })).ToDictionary(e => e.Key, e => e.Value);



            foreach (KeyValuePair<int, OEEbyJob> entry in machineandjob)
            {
               
                    //for (int i = 0; i < entry.Value.JobRunDates.Length; i++)
                    //{
                    //    var xy = _ioeerepository.SP_GetStopReasons()
                    //    .Where(x => x.StopReasonStart >= entry.Value.JobRunDates[i] && x.StopReasonEnd < entry.Value.JobRunDates[i].AddDays(1))
                    //    .Select(x => x.StopDownTime / 60).Sum(x => x.Value);
                    //entry.Value.TotalDownTime += xy;

                    //}
                for(int i = 0; i < entry.Value.ListofMachines.Length; i++)
                {
                    for(int j = 0; j <entry.Value.JobRunDates.Length; j++)
                    {
                        int xy = _ioeerepository.SP_GetStopReasons()
                            .Where(x => x.StopReasonStart >= entry.Value.JobRunDates[j] 
                            && x.StopReasonEnd < entry.Value.JobRunDates[j].AddDays(1) 
                            && x.OeeMachine == entry.Value.ListofMachines[i])
                            .Select(x => x.StopDownTime / 60).Sum(x => x.Value);
                        entry.Value.TotalDownTime += xy;

                        int pieces = _ioeerepository.GetTotalpiecesbyDate(entry.Value.ListofMachines[i], entry.Value.JobRunDates[j]).Select(x => x.ActionID).Count();
                        entry.Value.Totalpieces += (pieces * 6000);
                    }
                }

            }







            return JsonConvert.SerializeObject(machineandjob);
        }

        [HttpGet("OEEByShift")]
        public string OEEbyShift()
        {
            List<OEEResultShift> test = _ioeerepository.GetOEEbyShift().Where(x => !ExcludeMachineID.ExcludeNonOrlofs().Contains(x.MachineID)).ToList();


            Dictionary<int,OEEResultShift> oeebyjoblist = test.ToDictionary(p => p.MachineID, p => p);

            return JsonConvert.SerializeObject(oeebyjoblist);
        }

    }
}
