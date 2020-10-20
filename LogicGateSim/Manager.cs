using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGateSim
{
    static class Manager
    {
        static public InputPin LastInputPin;
        static public OutputPin LastOutputPin;

        static public void Update()
        {
            if (LastInputPin != null && LastOutputPin != null)
            {
                LastInputPin.outputPin = LastOutputPin;
                LastInputPin = null;
                LastOutputPin = null;
            }
        }
    }
}
