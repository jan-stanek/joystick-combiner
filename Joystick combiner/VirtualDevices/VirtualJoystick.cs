using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoystickCombiner.DeviceReaders;
using JoystickCombiner.Axes;
using JoystickCombiner.VJoyDevices;

namespace JoystickCombiner.VirtualDevices
{
    class VirtualJoystick : VirtualDevice
    {
        public VirtualJoystick(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader) : base(leftDeviceReader, rightDeviceReader)
        {
            vJoyDevice = new VJoyJoystick();

            init();

            addAxis((AxisName)Properties.Settings.Default.axisXAxis, AxisName.X, (AxisMethod)Properties.Settings.Default.axisXMethod, Properties.Settings.Default.axisXChange, Properties.Settings.Default.axisXCentered);
            addAxis((AxisName)Properties.Settings.Default.axisYAxis, AxisName.Y, (AxisMethod)Properties.Settings.Default.axisYMethod, Properties.Settings.Default.axisYChange, Properties.Settings.Default.axisYCentered);
            addAxis((AxisName)Properties.Settings.Default.axisTwistAxis, AxisName.RotationZ, (AxisMethod)Properties.Settings.Default.axisTwistMethod, Properties.Settings.Default.axisTwistChange, Properties.Settings.Default.axisTwistCentered);
            addAxis((AxisName)Properties.Settings.Default.axisThrottleAxis, AxisName.Z, (AxisMethod)Properties.Settings.Default.axisThrottleMethod, Properties.Settings.Default.axisThrottleChange, Properties.Settings.Default.axisThrottleCentered);
            addAxis((AxisName)Properties.Settings.Default.axisRotary1Axis, AxisName.RotationX, (AxisMethod)Properties.Settings.Default.axisRotary1Method, Properties.Settings.Default.axisRotary1Change, Properties.Settings.Default.axisRotary1Centered);
            addAxis((AxisName)Properties.Settings.Default.axisRotary2Axis, AxisName.RotationY, (AxisMethod)Properties.Settings.Default.axisRotary2Method, Properties.Settings.Default.axisRotary2Change, Properties.Settings.Default.axisRotary2Centered);
            addAxis((AxisName)Properties.Settings.Default.axisSliderAxis, AxisName.Slider, (AxisMethod)Properties.Settings.Default.axisSliderMethod, Properties.Settings.Default.axisSliderChange, Properties.Settings.Default.axisSliderCentered);
        }
    }
}
