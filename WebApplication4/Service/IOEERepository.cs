using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Models;

namespace WebApplication4.Service
{
    public interface IOEERepository
    {
        public IEnumerable<Models.OEEResultShift> GetOEEbyShift();
    }

}
