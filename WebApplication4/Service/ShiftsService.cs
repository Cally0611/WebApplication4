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


        public int GetCurrentShift(DateTime now)
        {
            if(_shifts.CurrTime > _shifts.FirstShift && _shifts.CurrTime < _shifts.SecondShift)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

    }
}
