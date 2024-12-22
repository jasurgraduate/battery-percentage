using Microsoft.Win32;

namespace BatteryApp
{
    public static class StartupManager
    {
        public static void AddApplicationToStartup()
        {
            string appName = "BatteryApp";
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue(appName, $"\"{appPath}\"");
        }

        public static void RemoveApplicationFromStartup()
        {
            string appName = "BatteryApp";

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue(appName, false);
        }
    }
}