using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using JoystickCombiner.DeviceReaders;
using JoystickCombiner.Axes;
using JoystickCombiner.VJoyDevices;

namespace JoystickCombiner.VirtualDevices
{
    class BackgroundWorker
    {
        private DeviceReader leftDeviceReader;
        private DeviceReader rightDeviceReader;
        private VJoyDevice vJoyDevice;
        private LinkedList<Axis> axesList;

        public BackgroundWorker(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader, VJoyDevice vJoyDevice, LinkedList<Axis> axesList)
        {
            this.leftDeviceReader = leftDeviceReader;
            this.rightDeviceReader = rightDeviceReader;
            this.vJoyDevice = vJoyDevice;
            this.axesList = axesList;
        }

        public void start() 
        {
            while(true)
            {
                foreach (Axis axis in axesList)
                    axis.update();


                byte buttonsCount = leftDeviceReader == null ? rightDeviceReader.getButtonsCount() : rightDeviceReader == null ? leftDeviceReader.getButtonsCount() : Math.Min(leftDeviceReader.getButtonsCount(), rightDeviceReader.getButtonsCount());

                if (buttonsCount > 0)
                {
                    bool[] buttons = new bool[buttonsCount];

                    for (byte i = 0; i < buttonsCount; i++)
                    {
                        buttons[i] = leftDeviceReader == null ? rightDeviceReader.getButtonsState()[i] : rightDeviceReader == null ? leftDeviceReader.getButtonsState()[i] : leftDeviceReader.getButtonsState()[i] || rightDeviceReader.getButtonsState()[i];
                    }

                    vJoyDevice.setButtonsState(buttonsCount, buttons);
                }


                byte POVsCount = leftDeviceReader == null ? rightDeviceReader.getPOVsCount() : rightDeviceReader == null ? leftDeviceReader.getPOVsCount() : Math.Min(leftDeviceReader.getPOVsCount(), rightDeviceReader.getPOVsCount());

                for (byte i = 0; i < POVsCount; i++)
                {
                    uint value = leftDeviceReader == null ? rightDeviceReader.getPOVState(i) : rightDeviceReader == null ? leftDeviceReader.getPOVState(i) : Math.Min(leftDeviceReader.getPOVState(i), rightDeviceReader.getPOVState(i));
                    vJoyDevice.setPOVState(i, value);
                }


                vJoyDevice.update();

                Thread.Sleep(1);
            }
        }
    }
}
