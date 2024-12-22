using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BatteryApp
{
    public static class Tray
    {
        private static NotifyIcon trayIcon;
        private static ContextMenuStrip trayMenu;

        public static void InitializeTrayIcon()
        {
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Settings", null, OnSettingsClick);
            trayMenu.Items.Add("Exit", null, OnExitClick);

            trayIcon = new NotifyIcon
            {
                Text = "Battery Percentage App",
                ContextMenuStrip = trayMenu,
                Visible = true
            };

            UpdateBatteryStatus();
        }

        public static void UpdateBatteryStatus()
        {
            int batteryPercentage = GetBatteryPercentage();
            trayIcon.Text = $"Battery: {batteryPercentage}%";
            trayIcon.Icon = CreateTextIcon(batteryPercentage.ToString());

            if (batteryPercentage <= Settings.LowBatteryThreshold)
            {
                ShowNotification("Battery is low! Please plug in your charger.", "Battery Warning");
            }
            else if (batteryPercentage >= Settings.HighBatteryThreshold)
            {
                ShowNotification("Battery is high! Consider unplugging your charger.", "Battery Alert");
            }
        }

        private static void OnSettingsClick(object sender, EventArgs e)
        {
            Settings.ShowSettingsForm();
        }

        private static void OnExitClick(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private static int GetBatteryPercentage()
        {
            BatteryStatus.SYSTEM_POWER_STATUS sps = new BatteryStatus.SYSTEM_POWER_STATUS();
            BatteryStatus.GetSystemPowerStatus(ref sps);
            return sps.BatteryLifePercent;
        }

        private static Icon CreateTextIcon(string text)
        {
            Bitmap bitmap = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                using (Font font = new Font("Arial", 13, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    g.DrawString(text, font, Brushes.White, new PointF(0, 0));
                }
            }
            IntPtr hIcon = bitmap.GetHicon();
            return Icon.FromHandle(hIcon);
        }

        private static void ShowNotification(string message, string title)
        {
            trayIcon.BalloonTipText = message;
            trayIcon.BalloonTipTitle = title;
            trayIcon.ShowBalloonTip(3000);
        }
    }
}