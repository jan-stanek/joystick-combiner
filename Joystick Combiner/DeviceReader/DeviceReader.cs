using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.DirectInput;

using JoystickCombiner.axis;

namespace JoystickCombiner.deviceReader
{
    abstract class DeviceReader
    {
        protected DirectInput directInput;
        protected Joystick device;
        
        public DeviceReader(DirectInput directInput, String guid)
        {
            this.directInput = directInput;
            device = new Joystick(directInput, Guid.Parse(guid));
            if (device == null)
                throw new Exception("Device not found.");
            device.Acquire();
        }

        public int getAxisState(AxisName axis)
        {
            switch (axis)
            {
                case AxisName.X:
                    return device.GetCurrentState().X;
                case AxisName.Y:
                    return device.GetCurrentState().Y;
                case AxisName.Z:
                    return device.GetCurrentState().Z;
                case AxisName.RotationX:
                    return device.GetCurrentState().RotationX;
                case AxisName.RotationY:
                    return device.GetCurrentState().RotationY;
                case AxisName.RotationZ:
                    return device.GetCurrentState().RotationZ;
                case AxisName.Slider:
                    return device.GetCurrentState().Sliders[0];
            }
            return 0;
        }

        public byte getButtonsCount()
        {
            return (byte)device.Capabilities.ButtonCount;
        }

        public bool[] getButtonsState()
        {
            return device.GetCurrentState().Buttons;
        }

        public bool getButtonState(byte button)
        {
            if (button >= getButtonsCount() || button <= 0)
                throw new Exception("Button is not present.");
            return getButtonsState()[button - 1];
        }

        public void stop()
        {
            device.Unacquire();   
        }
    }
}
