using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BatteryApp
{
    public static class Popup
    {
        public static void InitializePopup()
        {
            ShowBatteryWarning();
        }

        public static void ShowBatteryWarning()
        {
            int batteryPercentage = GetBatteryPercentage();

            if (batteryPercentage <= 20)
            {
                MessageBox.Show("Battery is low! Please plug in your charger.", "Battery Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static int GetBatteryPercentage()
        {
            BatteryStatus.SYSTEM_POWER_STATUS sps = new BatteryStatus.SYSTEM_POWER_STATUS();
            BatteryStatus.GetSystemPowerStatus(ref sps);
            return sps.BatteryLifePercent;
        }
    }
}