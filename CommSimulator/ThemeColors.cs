using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSimulator
{
    internal static class ThemeColors
    {
        #region 다크 모드
        public static Color DarkBackgroundColor = Color.FromArgb(30, 30, 30);
        public static Color DarkForegroundColor = Color.White;

        public static Color DarkButtonBackgroundColor = Color.FromArgb(50, 50, 50);
        public static Color DarkButtonForegroundColor = Color.White;
        #endregion

        public static void ApplyTheme(Control control, bool isDarkMode)
        {
            if (isDarkMode)
            {
                control.BackColor = DarkBackgroundColor;
                control.ForeColor = DarkForegroundColor;

                foreach (Control childControl in control.Controls)
                {
                    ApplyTheme(childControl, isDarkMode);
                }

                if (control is Button button)
                {
                    button.BackColor = DarkButtonBackgroundColor;
                    button.ForeColor = DarkButtonForegroundColor;
                }
            }
            else
            {
                control.BackColor = SystemColors.Control;
                control.ForeColor = SystemColors.ControlText;

                foreach (Control childControl in control.Controls)
                {
                    ApplyTheme(childControl, isDarkMode);
                }

                if (control is TextBox textBox)
                {
                    textBox.BackColor = SystemColors.Window;
                    textBox.ForeColor = SystemColors.WindowText;
                }
            }
        }
    }
}
