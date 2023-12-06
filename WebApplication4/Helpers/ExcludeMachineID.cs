namespace WebApplication4.Helpers
{
    public class ExcludeMachineID
    {
        //private int[] _machineID { get;set; }

        //public int[] MachineID
        //{
        //    get { return _machineID; }
        //    set { _machineID = value; }
        //}
        public static int[] ExcludeNonOrlofs()
        {
            int[] machineIDs = new int[10] { 1, 2, 3, 4, 9, 11, 12, 13, 14, 15 };
            return machineIDs;

        }
    }
}
