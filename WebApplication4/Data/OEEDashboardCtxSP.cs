using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public partial class OeedashboardContext : DbContext
    {
      
        public virtual DbSet<OEEResultShift> OEEResults { get; set; }

        public virtual DbSet<OeeDaily> OEEDailyResults { get; set; }

        public virtual DbSet<TotalPieces> TotalPieces { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OEEResultShift>(entity => entity.HasNoKey());
            modelBuilder.Entity<OeeDaily>(entity => entity.HasNoKey());
            modelBuilder.Entity<OeeDaily>(entity => entity.Ignore("OEEAveragePercentage"));
            //modelBuilder.Entity<OeeCalculationAll>(entity => entity.Ignore("OeeLocalId")
            //.Ignore("Spoperation")
            //.Ignore("InsUpdTimeStamp"));

        }

        public IEnumerable<OEEResultShift> SP_GetOEEbyShiftDetails()
        {
            
            return OEEResults.FromSql($"EXECUTE dbo.GetOEEbyShiftDetails");
           
            
          
        }

        public OeeDaily[] SP_GetOEEDaily()
        {
            OeeDaily[] dailyoee = OEEDailyResults.FromSql($"EXECUTE dbo.GetOEEDaily").ToArray();
            return dailyoee;

        }

        public IEnumerable<TotalPieces> GetTotalpiecesbyDate(int MachineID, DateTime jobdate)
        {
            return TotalPieces.FromSql($"EXECUTE dbo.GetTotalpiecesbyDate @MachineID={MachineID}, @ActionDate={jobdate}");
          
        }

      

    }
}
