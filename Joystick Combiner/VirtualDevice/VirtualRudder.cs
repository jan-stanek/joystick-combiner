using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using joystickCombiner.deviceReader;
using joystickCombiner.axis;
using joystickCombiner.vJoyDevice;

namespace joystickCombiner.virtualDevice
{
    class VirtualRudder : VirtualDevice
    {
        public VirtualRudder(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader) : base(leftDeviceReader, rightDeviceReader) {
            vJoyDevice = new VJoyRudder();

            init();

            addAxis((AxisName)Properties.Settings.Default.axisLeftToeAxis, AxisName.X, (AxisMethod)Properties.Settings.Default.axisLeftToeMethod, Properties.Settings.Default.axisLeftToeChange, Properties.Settings.Default.axisLeftToeCentered);
            addAxis((AxisName)Properties.Settings.Default.axisRightToeAxis, AxisName.Y, (AxisMethod)Properties.Settings.Default.axisRightToeMethod, Properties.Settings.Default.axisRightToeChange, Properties.Settings.Default.axisRightToeCentered);
            addAxis((AxisName)Properties.Settings.Default.axisRudderAxis, AxisName.RotationZ, (AxisMethod)Properties.Settings.Default.axisRudderMethod, Properties.Settings.Default.axisRudderChange, Properties.Settings.Default.axisRudderCentered);
        }
    }
}
