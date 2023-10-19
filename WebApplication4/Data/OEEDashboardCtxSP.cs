using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public partial class OeedashboardContext : DbContext
    {

        public virtual DbSet<OEEResultShift> OEEResults { get; set; }

        // We’ll add subsequent changes here


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OEEResultShift>(entity => entity.HasNoKey());
        }

        public IEnumerable<OEEResultShift> SP_GetOEEbyShiftDetails(string currdate, int shiftno)
        {
            var test = OEEResults
                .FromSql($"EXECUTE dbo.GetOEEbyShiftDetails @CurrDate={currdate}, @CurrShift={shiftno}")
          
                .ToArray();
            return test;
          
        }
    }
}
