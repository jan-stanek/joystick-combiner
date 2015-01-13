using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using JoystickCombiner.deviceReader;
using JoystickCombiner.axis;
using JoystickCombiner.vJoyDevice;

namespace JoystickCombiner.virtualDevice
{
    abstract class VirtualDevice
    {
        private LinkedList<Axis> axesList;
        protected VJoyDevice vJoyDevice;
        private DeviceReader leftDeviceReader;
        private DeviceReader rightDeviceReader;
        private BackgroundWorker backgroundWorker;
        private Thread backgroundThread;

        public VirtualDevice(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader)
        {
            axesList = new LinkedList<Axis>();
            this.leftDeviceReader = leftDeviceReader;
            this.rightDeviceReader = rightDeviceReader;
        }
        
        protected void init()
        {
            backgroundWorker = new BackgroundWorker(leftDeviceReader, rightDeviceReader, vJoyDevice, axesList);
        }

        public void start()
        {
            backgroundThread = new Thread(new ThreadStart(backgroundWorker.start));
            backgroundThread.Start();
        }

        public void stop()
        {
            backgroundThread.Abort();
            vJoyDevice.stop();
        }

        protected void addAxis(AxisName axisInput, AxisName axisOutput, AxisMethod method, byte change, bool centered)
        {
            if (axisInput != AxisName.none)
            {
                switch (method)
                {
                    case AxisMethod.WeightenedSum:
                        axesList.AddLast(new AxisWeightenedSum(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered));
                        break;
                    case AxisMethod.Change:
                        axesList.AddLast(new AxisChange(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered, change));
                        break;
                    case AxisMethod.Minimum:
                        axesList.AddLast(new AxisMinimum(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered));
                        break;
                    case AxisMethod.Maximum:
                        axesList.AddLast(new AxisMaximum(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered));
                        break;
                }
            }
        }
    }
}
