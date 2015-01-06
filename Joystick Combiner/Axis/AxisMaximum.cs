using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using joystickCombiner.deviceReader;
using joystickCombiner.vJoyDevice;

namespace joystickCombiner.axis
{
    class AxisMaximum : Axis
    {
        public AxisMaximum(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader, VJoyDevice vJoyDevice, string axisInput, string axisOutput, bool centered)
            : base(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered) { }

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
                int leftState = centered ? leftDeviceReader.getAxisState(axisInput) - 32768 : leftDeviceReader.getAxisState(axisInput);
                int rightState = centered ? rightDeviceReader.getAxisState(axisInput) - 32768 : rightDeviceReader.getAxisState(axisInput);

                if (centered)
                    return Math.Max(Math.Abs(leftState), Math.Abs(rightState)) * Math.Sign(leftState + rightState) / 2 + 16384;
                else
                    return Math.Max(leftState, rightState) / 2;
            }
        }
    }
}
