using System;
using System.Windows.Forms;

namespace BatteryApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Enable visual styles for the app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Add application to startup
            StartupManager.AddApplicationToStartup();

            // Initialize Tray icon
            Tray.InitializeTrayIcon();

            // Initialize Popup Notifications
            Popup.InitializePopup();

            // Run the application
            Application.Run();
        }
    }
}