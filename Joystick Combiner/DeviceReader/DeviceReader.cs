using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.DirectInput;

namespace joystickCombiner.deviceReader
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

        public int getAxisState(string axis)
        {
            switch (axis)
            {
                case "X":
                    return device.GetCurrentState().X;
                case "Y":
                    return device.GetCurrentState().Y;
                case "Z":
                    return device.GetCurrentState().Z;
                case "RotationX":
                    return device.GetCurrentState().RotationX;
                case "RotationY":
                    return device.GetCurrentState().RotationY;
                case "RotationZ":
                    return device.GetCurrentState().RotationZ;
                case "Slider":
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
