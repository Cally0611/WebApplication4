using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication4.Service
{
    public class DBOperationService : IOEERepository
    {
        //PROPERTY
        private readonly OeedashboardContext _dbContext;

        private readonly ITransientService _transientService;
        public OeedashboardContext DbContext
        {
            get { return _dbContext; }
        }

        //public ShiftsService Shift
        //{
        //    get => _shift;
        //}
        public DBOperationService(OeedashboardContext dbContext, ITransientService transientService)
        {
            _dbContext = dbContext;
            _transientService = transientService;
      

        }

        public IEnumerable<Models.Results> GetOEEStopReasons()
        {
            //List<Models.Results> query = (from a in _dbContext.Machines
            //            join b in _dbContext.AllMachines
            //            on a.Id equals b.MachineId into ab_jointable
            //            from columns in ab_jointable.DefaultIfEmpty()
            //            join c in _dbContext.OeeDetailsAlls
            //            on new { a.Id, columns.TargetDate }
            //            equals new { Id = c.OeeMachine, TargetDate = c.StopReasonStart.Date } into ac_jointable

            //            from sectable in ac_jointable.DefaultIfEmpty()
            //            where columns.TargetDate == DateTime.Parse("2023-10-05") 
            //            select new Models.Results
            //            {
            //                ID = a.Id,
            //                MachineName = a.MachineName,
            //                OeeMachine = sectable.OeeMachine,
            //                Target_Date = columns.TargetDate,
            //                JobName1 = columns.JobName1,
            //                StopReasonStart  = sectable.StopReasonStart.ToString() == null ? "NoValue" :sectable.StopReasonStart.ToString(),
            //                StopReasonEnd = sectable.StopReasonEnd.ToString() == null ? "NoValue" : sectable.StopReasonEnd.ToString(),
            //                Stop_MReason = sectable.StopMreason,
            //                Stop_SReason = sectable.StopSreason

            //            }).ToList();

            return null;

        }

        public IEnumerable<Models.OEEResultShift> GetOEEbyShift()
        {
            return _dbContext.SP_GetOEEbyShiftDetails();
        }

        public OeeDaily[] GetOEEDailyCalculationAll()
        {
            return _dbContext.SP_GetOEEDaily();
        }

        //public List<AllMachine> SP_GetJobsbyMachine(DateTime todaysdate)
        //{
        //    return _dbContext.AllMachines.OrderBy(x => x.MachineId).Where(x => x.TargetDate == todaysdate).ToList();
        //}

        public IEnumerable<AllMachine> SP_GetAllMachines()
        {
            return _dbContext.AllMachines;
        }

        public IEnumerable<OeeDetailsAll> SP_GetStopReasons()
        {
            return _dbContext.OeeDetailsAlls;
        }

        public IEnumerable<TotalPieces> GetTotalpiecesbyDate(int MachineID, DateTime jobdate)
        {
            return _dbContext.GetTotalpiecesbyDate(MachineID, jobdate);
        }

    }
}
