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
                foreach(Axis axis in axesList)
                    axis.update();

                byte buttonsCount = Math.Min(leftDeviceReader.getButtonsCount(), rightDeviceReader.getButtonsCount());
                
                if (buttonsCount > 0)
                {
                    bool[] buttons = new bool[buttonsCount];

                    for (byte i = 0; i < buttonsCount; i++)
                    {
                        buttons[i] = leftDeviceReader.getButtonsState()[i] || rightDeviceReader.getButtonsState()[i];
                    }

                    vJoyDevice.setButtonsState(buttonsCount, buttons);
                }
                
                vJoyDevice.update();
                Thread.Sleep(1);
            }
        }
    }
}
