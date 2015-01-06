using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using vJoyInterfaceWrap;

namespace joystickCombiner.vJoyDevice
{
    abstract class VJoyDevice
    {
        private vJoy device;
        private vJoy.JoystickState state;
        private uint id;

        public VJoyDevice(uint id)
        {
            device = new vJoy();
            this.id = id;

            if (!device.vJoyEnabled())
            {
                throw new Exception("vJoy driver not enabled");
            }

            VjdStat status = device.GetVJDStatus(id);

            if (status == VjdStat.VJD_STAT_BUSY)
                throw new Exception("vJoy device is already in use");
            else if (status == VjdStat.VJD_STAT_MISS)
                throw new Exception("vJoy device is not installed or disabled");

            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!device.AcquireVJD(id))))
                throw new Exception("Failed to acquire vJoy device " + id);
        }

        public void stop()
        {
            device.RelinquishVJD(id);
        }

        public void setAxisState(string axis, int value)
        {
            value = Math.Min(Math.Max(value, 1), 32767);

            switch(axis)
            {
                case "X":
                    state.AxisX = value;
                    break;
                case "Y":
                    state.AxisY = value;
                    break;
                case "Z":
                    state.AxisZ = value;
                    break;
                case "RotationX":
                    state.AxisXRot = value;
                    break;
                case "RotationY":
                    state.AxisYRot = value;
                    break;
                case "RotationZ":
                    state.AxisZRot = value;
                    break;
                case "Slider":
                    state.Slider = value;
                    break;
            }
        }

        public void setButtonsState(byte buttons, bool[] values)
        {
            for (byte i = 31; i >= 0 ; i--)
            {
                state.Buttons <<= 1;
                if (i < buttons && values[i])
                    state.Buttons++;
            }
            for (byte i = 63; i >= 32; i--)
            {
                state.ButtonsEx1 <<= 1;
                if (i < buttons && values[i])
                    state.ButtonsEx1++;
            }
        }

        public void update()
        {
            if (!device.UpdateVJD(id, ref state))
            {
                throw new Exception("vJoy update failed.");
            }
        }
    }
}
