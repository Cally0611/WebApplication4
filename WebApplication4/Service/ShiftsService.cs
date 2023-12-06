using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using WebApplication4.Models;

namespace WebApplication4.Service
{
    public class ShiftsService : ITransientService
    {

        private readonly Shift _shifts;

        
        public ShiftsService(IOptions<Shift> shifts)
        {
            _shifts = shifts.Value;
        }


        public int GetCurrentShift()
        {
            if(_shifts.CurrTime > _shifts.FirstShift && _shifts.CurrTime < _shifts.SecondShift)
            {
                return _shifts.ShiftType = 1;
            }
            else
            {
                return _shifts.ShiftType = 2;
            }
        }


        public DateTime GetDateBasedonShift()
        {
            if (_shifts.CurrTime > _shifts.FirstShift && _shifts.CurrTime < _shifts.SecondShift)
            {
                return _shifts.DateBasedonShift = DateTime.Now.Date;
            }
            else if (_shifts.CurrTime > _shifts.SecondShift && _shifts.CurrTime < _shifts.SharpMidnight)
            {
                return _shifts.DateBasedonShift = DateTime.Now.Date;
            }
            else 
            {
                return _shifts.DateBasedonShift= DateTime.Now.AddDays(-1).Date;

            }

        }
       



    }
}
