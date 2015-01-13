using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoystickCombiner.deviceReader;
using JoystickCombiner.vJoyDevice;

namespace JoystickCombiner.axis
{
    class AxisChange : Axis
    {
        private byte change;
        private short changeInterval;

        private int lastLeftState = 0;
        private int lastRightState = 0;
        private long lastTime = 0;
        private byte side = 1;

        public AxisChange(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader, VJoyDevice vJoyDevice, AxisName axisInput, AxisName axisOutput, bool centered, byte change)
            : base(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered)
        {
            this.change = change;
            this.changeInterval = Properties.Settings.Default.changeInterval;
        }

        public override int computeValue()
        {
            if (leftDeviceReader == null)
            {
                int rightState = rightDeviceReader.getAxisState(axisInput);

                return rightState / 2;
            }

            else if (rightDeviceReader == null)
            {
                int leftState = leftDeviceReader.getAxisState(axisInput);

                return leftState / 2;
            }

            else
            {
                int leftState = leftDeviceReader.getAxisState(axisInput);
                int rightState = rightDeviceReader.getAxisState(axisInput);

                if (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond > lastTime + changeInterval)
                {
                    if (side == 2 && Math.Abs(lastLeftState - leftState) > (65536 * change) / 100)
                        side = 1;
                    else if (side == 1 && Math.Abs(lastRightState - rightState) > (65536 * change) / 100)
                        side = 2;

                    lastLeftState = leftState;
                    lastRightState = rightState;
                    lastTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                }

                if (side == 1)
                    return leftState / 2;
                else
                    return rightState / 2;
            }
        }
    }
}
