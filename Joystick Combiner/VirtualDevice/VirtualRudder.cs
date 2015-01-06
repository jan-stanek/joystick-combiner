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

            addAxis(Properties.Settings.Default.axisLeftToeAxis, "X", Properties.Settings.Default.axisLeftToeMethod, Properties.Settings.Default.axisLeftToeChange, Properties.Settings.Default.axisLeftToeCentered);
            addAxis(Properties.Settings.Default.axisRightToeAxis, "Y", Properties.Settings.Default.axisRightToeMethod, Properties.Settings.Default.axisRightToeChange, Properties.Settings.Default.axisRightToeCentered);
            addAxis(Properties.Settings.Default.axisRudderAxis, "RotationZ", Properties.Settings.Default.axisRudderMethod, Properties.Settings.Default.axisRudderChange, Properties.Settings.Default.axisRudderCentered);
        }
    }
}
