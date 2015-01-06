using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using joystickCombiner.deviceReader;
using joystickCombiner.axis;
using joystickCombiner.vJoyDevice;

namespace joystickCombiner.virtualDevice
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

        protected void addAxis(string axisInput, string axisOutput, byte method, byte change, bool centered)
        {
            if (!axisInput.Equals("none"))
            {
                switch (method)
                {
                    case 0:
                        axesList.AddLast(new AxisWeightenedSum(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered));
                        break;
                    case 1:
                        axesList.AddLast(new AxisChange(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered, change));
                        break;
                    case 2:
                        axesList.AddLast(new AxisMinimum(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered));
                        break;
                    case 3:
                        axesList.AddLast(new AxisMaximum(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered));
                        break;
                }
            }
        }
    }
}
