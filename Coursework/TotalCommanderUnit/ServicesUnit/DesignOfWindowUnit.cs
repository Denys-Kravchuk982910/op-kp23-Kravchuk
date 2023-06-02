using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Services;

namespace TotalCommanderUnit.ServicesUnit
{
    public class DesignOfWindowUnit
    {
        public void MakeLogoUnit()
        {
            //Method should output a banner of TotalCommander
            DesignOfWindow.MakeLogo();
        }

        public void MakeBackgroundUnit()
        {
            //Method should paint the background in the blue color
            DesignOfWindow.MakeBackground();
        }

        public void MakeBordersUnit()
        {
            // Method should build borders for columns of the app
            DesignOfWindow.MakeBorders();
        }

        public void MakePointersUnit()
        {
            // Method should write down the pointers in the command line
            DesignOfWindow.MakePointers(new List<string>
            {
                "1. point1",
                "2. point2",
                "3. point3",
            });
        }

        public void ClearConsoleLineUnit()
        {
            // Method should clear command line
            DesignOfWindow.ClearConsoleLine();
        }
    }
}
