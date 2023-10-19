using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication4.Helpers
{
    public class DateTimeHelper
    {
        //2023-10-05 - Return in this format
        internal static string ConvertDT_Datestr(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        internal static DateTime ConvertSTR_Datedt(string dt)
        {
            return DateTime.Parse(dt);
        }
    }
}
