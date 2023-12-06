using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Models;

namespace WebApplication4.Service
{
    //implemented by DBOperationService
    public interface IOEERepository
    {
        public IEnumerable<Models.OEEResultShift> GetOEEbyShift();

        public OeeDaily[] GetOEEDailyCalculationAll();

        //public List<AllMachine> SP_GetJobsbyMachine(DateTime todaysdate);

        public IEnumerable<AllMachine> SP_GetAllMachines();

        public IEnumerable<OeeDetailsAll> SP_GetStopReasons();

        public IEnumerable<TotalPieces> GetTotalpiecesbyDate(int MachineID, DateTime jobdate);
    }

}
