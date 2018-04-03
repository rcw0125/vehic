using System;
using System.Collections.Generic;
using System.Text;
using VehIC_Device;

namespace VehIC_WF.Device
{
    public class CommonRoadBrake : IRoadBrake
    {
        private RoadBrake roadbrake1;
        private RoadBrake roadbrake2;
        private VehIC_Device.RoadBrake roadbrake11;
        private VehIC_Device.RoadBrake roadbrake21;

        public CommonRoadBrake(RoadBrake roadbrake1, RoadBrake roadbrake2)
        {
            this.roadbrake1 = roadbrake1;
            this.roadbrake2 = roadbrake2;
        }

        public CommonRoadBrake(VehIC_Device.RoadBrake roadbrake11, VehIC_Device.RoadBrake roadbrake21)
        {
            // TODO: Complete member initialization
            this.roadbrake11 = roadbrake11;
            this.roadbrake21 = roadbrake21;
        }
        public bool KZ(int inOut)
        {
            if (inOut == 1)
            {
                return roadbrake1.KZ();
            }
            else
            {
                return roadbrake2.KZ();
            }
        }
    }
}
