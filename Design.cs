using System;
using System.Windows.Forms;

namespace BatteryApp
{
    public static class Design
    {
        public static void CustomizeDesign(Form form)
        {
            // Customize form background color
            form.BackColor = System.Drawing.Color.LightBlue;

            // Customize the font of controls (you can modify this as needed)
            foreach (Control control in form.Controls)
            {
                control.Font = new System.Drawing.Font("Arial", 12);
            }
        }
    }
}