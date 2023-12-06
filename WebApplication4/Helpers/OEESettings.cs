using System;

namespace WebApplication4.Helpers
{
    public class OEESettings
    {
        public decimal? CalculateAvailability(int? Uptime, int? Downtime)
        {
            if(Uptime > 0 && Downtime > 0)
            {
                return (Convert.ToDecimal(Uptime) / Convert.ToDecimal(Downtime + Uptime)) * 100;
            }
            else if(Uptime == 0 && Downtime == 0)
            {
                return 0;
            }
            else if(Uptime > 0 && Downtime == 0)
            {
                return (Convert.ToDecimal(Uptime) / Convert.ToDecimal(Uptime)) * 100;
            }
            else
            {
                return null;
            }
        }

        public decimal? CalculatePerformance(int? Uptime, int? Totalpieces)
        {
            if (Uptime > 0 && Totalpieces > 0)
            {
                return ((Convert.ToDecimal(Totalpieces) / Convert.ToDecimal(Uptime)) / Convert.ToDecimal(166.7)) * 100;
            }
            else if (Uptime == 0 || Totalpieces == 0)
            {
                return 0;
            }
            else
            {
                return null;
            }
        }

        public decimal? CalculateOEEPercentage(decimal? Availability, decimal? Quality, decimal? Performance)
        {
            if(Availability != null && Quality != null && Performance != null) 
            {
                return ((Availability * Quality * Performance)/ 1000000)*100;
                    
            }
            else
            {
                return null;
            }
        }
    }
}
