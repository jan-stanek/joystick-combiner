using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.DirectInput;

using JoystickCombiner.deviceReader;
using JoystickCombiner.virtualDevice;

namespace JoystickCombiner
{
    class JoystickCombiner
    {
        private DirectInput directInput;

        private JoystickReader leftJoystickReader;
        private JoystickReader rightJoystickReader;
        private RudderReader leftRudderReader;
        private RudderReader rightRudderReader;

        private VirtualJoystick virtualJoystick;
        private VirtualRudder virtualRudder;

        private bool running = false;
        
        public JoystickCombiner()
        {
            directInput = new DirectInput();
        }

        public void start()
        {
            setDeviceReaders(Properties.Settings.Default.active);

            if (leftJoystickReader != null || rightJoystickReader != null)
            {
                virtualJoystick = new VirtualJoystick(leftJoystickReader, rightJoystickReader);
                virtualJoystick.start();
            }
            else
                throw new Exception("No joystick selected.");

            if (leftRudderReader != null || rightRudderReader != null)
            {
                virtualRudder = new VirtualRudder(leftRudderReader, rightRudderReader);
                virtualRudder.start();
            }
            else
                throw new Exception("No rudder pedals selected.");

            running = true;
        }

        public void stop()
        {
            if (virtualJoystick != null)
                virtualJoystick.stop();
            if (virtualRudder != null)
                virtualRudder.stop();

            if (leftJoystickReader != null)
                leftJoystickReader.stop();
            if (leftRudderReader != null)
                leftRudderReader.stop();
            if (rightJoystickReader != null)
                rightJoystickReader.stop();
            if (rightRudderReader != null)
                rightRudderReader.stop();

            running = false;
        }

        public LinkedList<string> getDevicesList(DeviceType deviceType)
        {
            LinkedList<string> devices = new LinkedList<string>();
            devices.AddLast("none");
            //foreach (var deviceInstance in directInput.GetDevices(deviceType, DeviceEnumerationFlags.AttachedOnly))
            foreach (var deviceInstance in directInput.GetDevices())
                devices.AddLast(deviceInstance.InstanceName + " {" + deviceInstance.InstanceGuid.ToString() + "}");
            return devices;
        }

        public bool isRunning()
        {
            return running;
        }

        private void setDeviceReaders(byte active)
        {
            string guid;

            switch (active)
            {
                case 0:
                    if ((guid = parseGuid(Properties.Settings.Default.leftJoystick)) != null)
                        leftJoystickReader = new JoystickReader(directInput, guid);
                    if ((guid = parseGuid(Properties.Settings.Default.leftRudder)) != null)
                        leftRudderReader = new RudderReader(directInput, guid);
                    if ((guid = parseGuid(Properties.Settings.Default.rightJoystick)) != null)
                        rightJoystickReader = new JoystickReader(directInput, guid);
                    if ((guid = parseGuid(Properties.Settings.Default.rightRudder)) != null)
                        rightRudderReader = new RudderReader(directInput, guid);
                    break;
                case 1:
                    if ((guid = parseGuid(Properties.Settings.Default.leftJoystick)) != null)
                        leftJoystickReader = new JoystickReader(directInput, guid);
                    if ((guid = parseGuid(Properties.Settings.Default.leftRudder)) != null)
                        leftRudderReader = new RudderReader(directInput, guid);
                    rightJoystickReader = null;
                    rightRudderReader = null;
                    break;
                case 2:
                    leftJoystickReader = null;
                    leftRudderReader = null;
                    if ((guid = parseGuid(Properties.Settings.Default.rightJoystick)) != null)
                        rightJoystickReader = new JoystickReader(directInput, guid);
                    if ((guid = parseGuid(Properties.Settings.Default.rightRudder)) != null)
                        rightRudderReader = new RudderReader(directInput, guid);
                    break;
            }
        }

        private string parseGuid(string device)
        {
            if (device == "none" || device == "")
                return null;
            return device.Split('{', '}')[1];
        }
    }
}
