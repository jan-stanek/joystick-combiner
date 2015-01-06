using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using joystickCombiner.deviceReader;
using joystickCombiner.vJoyDevice;

namespace joystickCombiner.axis
{
    abstract class Axis
    {
        protected DeviceReader leftDeviceReader;
        protected DeviceReader rightDeviceReader;
        protected VJoyDevice vJoyDevice;
        protected string axisInput;
        protected string axisOutput;
        protected bool centered;

        public Axis(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader, VJoyDevice vJoyDevice, string axisInput, string axisOutput, bool centered)
        {
            this.leftDeviceReader = leftDeviceReader;
            this.rightDeviceReader = rightDeviceReader;
            this.vJoyDevice = vJoyDevice;
            this.axisInput = axisInput;
            this.axisOutput = axisOutput;
            this.centered = centered;
        }

        public void update()
        {
            vJoyDevice.setAxisState(axisOutput, computeValue());
        }

        public abstract int computeValue();
    }
}
