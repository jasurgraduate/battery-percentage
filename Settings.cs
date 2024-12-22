using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace BatteryApp
{
    public static class Settings
    {
        private static int lowBatteryThreshold = 20;
        private static int highBatteryThreshold = 80;

        public static int LowBatteryThreshold => lowBatteryThreshold;
        public static int HighBatteryThreshold => highBatteryThreshold;

        public static void ShowSettingsForm()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(new MaterialForm());
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

            MaterialForm settingsForm = new MaterialForm
            {
                Text = "Settings",
                Size = new System.Drawing.Size(400, 300)
            };

            MaterialLabel lowBatteryLabel = new MaterialLabel
            {
                Text = "Low Battery Threshold:",
                Location = new System.Drawing.Point(30, 80),
                AutoSize = true
            };
            MaterialSingleLineTextField lowBatteryTextBox = new MaterialSingleLineTextField
            {
                Text = lowBatteryThreshold.ToString(),
                Location = new System.Drawing.Point(250, 80),
                Size = new System.Drawing.Size(100, 20)
            };

            MaterialLabel highBatteryLabel = new MaterialLabel
            {
                Text = "High Battery Threshold:",
                Location = new System.Drawing.Point(30, 130),
                AutoSize = true
            };
            MaterialSingleLineTextField highBatteryTextBox = new MaterialSingleLineTextField
            {
                Text = highBatteryThreshold.ToString(),
                Location = new System.Drawing.Point(250, 130),
                Size = new System.Drawing.Size(100, 20)
            };

            MaterialRaisedButton saveButton = new MaterialRaisedButton
            {
                Text = "Save",
                Location = new System.Drawing.Point(150, 200),
                Size = new System.Drawing.Size(100, 36)
            };
            saveButton.Click += (sender, e) =>
            {
                if (int.TryParse(lowBatteryTextBox.Text, out int lowThreshold) &&
                    int.TryParse(highBatteryTextBox.Text, out int highThreshold))
                {
                    lowBatteryThreshold = lowThreshold;
                    highBatteryThreshold = highThreshold;
                    settingsForm.Close();
                }
                else
                {
                    MessageBox.Show("Please enter valid numbers for the thresholds.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            settingsForm.Controls.Add(lowBatteryLabel);
            settingsForm.Controls.Add(lowBatteryTextBox);
            settingsForm.Controls.Add(highBatteryLabel);
            settingsForm.Controls.Add(highBatteryTextBox);
            settingsForm.Controls.Add(saveButton);
            settingsForm.ShowDialog();
        }
    }
}