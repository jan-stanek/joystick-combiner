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
    class VirtualJoystick : VirtualDevice
    {
        public VirtualJoystick(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader) : base(leftDeviceReader, rightDeviceReader)
        {
            vJoyDevice = new VJoyJoystick();

            init();

            addAxis(Properties.Settings.Default.axisXAxis, "X", Properties.Settings.Default.axisXMethod, Properties.Settings.Default.axisXChange, Properties.Settings.Default.axisXCentered);
            addAxis(Properties.Settings.Default.axisYAxis, "Y", Properties.Settings.Default.axisYMethod, Properties.Settings.Default.axisYChange, Properties.Settings.Default.axisYCentered);
            addAxis(Properties.Settings.Default.axisTwistAxis, "RotationZ", Properties.Settings.Default.axisTwistMethod, Properties.Settings.Default.axisTwistChange, Properties.Settings.Default.axisTwistCentered);
            addAxis(Properties.Settings.Default.axisThrottleAxis, "Z", Properties.Settings.Default.axisThrottleMethod, Properties.Settings.Default.axisThrottleChange, Properties.Settings.Default.axisThrottleCentered);
            addAxis(Properties.Settings.Default.axisRotary1Axis, "RotationX", Properties.Settings.Default.axisRotary1Method, Properties.Settings.Default.axisRotary1Change, Properties.Settings.Default.axisRotary1Centered);
            addAxis(Properties.Settings.Default.axisRotary2Axis, "RotationY", Properties.Settings.Default.axisRotary2Method, Properties.Settings.Default.axisRotary2Change, Properties.Settings.Default.axisRotary2Centered);
            addAxis(Properties.Settings.Default.axisSliderAxis, "Slider", Properties.Settings.Default.axisSliderMethod, Properties.Settings.Default.axisSliderChange, Properties.Settings.Default.axisSliderCentered);
        }
    }
}
