using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoystickCombiner.DeviceReaders;
using JoystickCombiner.VJoyDevices;

namespace JoystickCombiner.Axes
{
    class AxisMinimum : Axis
    {
        public AxisMinimum(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader, VJoyDevice vJoyDevice, AxisName axisInput, AxisName axisOutput, bool centered)
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
                    return Math.Min(Math.Abs(leftState), Math.Abs(rightState)) * Math.Sign(leftState + rightState) * Math.Sign(leftState) * Math.Sign(rightState) / 2 + 16384;
                else
                    return Math.Min(leftState, rightState) / 2;
            }
        }
    }
}
