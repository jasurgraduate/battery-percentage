using System.Runtime.InteropServices;

namespace BatteryApp
{
    public static class BatteryStatus
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetSystemPowerStatus(ref SYSTEM_POWER_STATUS systemPowerStatus);

        public struct SYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }
    }
}