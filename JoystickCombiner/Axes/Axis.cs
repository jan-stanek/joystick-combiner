using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoystickCombiner.DeviceReaders;
using JoystickCombiner.VJoyDevices;

namespace JoystickCombiner.Axes
{
    enum AxisName
    {
        none = 0,
        X = 1,
        Y = 2,
        Z = 3,
        RotationX = 4,
        RotationY = 5,
        RotationZ = 6,
        Slider = 7
    }

    enum AxisMethod
    {
        WeightenedSum = 0,
        Change = 1,
        Minimum = 2,
        Maximum = 3
    }

    abstract class Axis
    {
        protected DeviceReader leftDeviceReader;
        protected DeviceReader rightDeviceReader;
        protected VJoyDevice vJoyDevice;
        protected AxisName axisInput;
        protected AxisName axisOutput;
        protected bool centered;

        public Axis(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader, VJoyDevice vJoyDevice, AxisName axisInput, AxisName axisOutput, bool centered)
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
