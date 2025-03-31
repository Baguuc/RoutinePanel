using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutinePanel.Lib
{
    class _ColorScheme
    {
        public Color COLOR_1 = Color.FromHex("#1A1A1D");
        public Color COLOR_2 = Color.FromHex("#3B1C32");
        public Color COLOR_3 = Color.FromHex("#6A1E55");
        public Color COLOR_4 = Color.FromHex("#A64D79");
        public Color COLOR_TEXT = Color.FromHex("#FAFAFA");

        public static _ColorScheme GetInstance()
        {
            return new _ColorScheme();
        }
    }
}
