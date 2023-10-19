using WebApplication4.Models;

namespace WebApplication4.Service
{
    public interface ITransientService
    {
        //method that returns SHift type
    

        public int GetCurrentShift(DateTime currtime);
       
    }
}
