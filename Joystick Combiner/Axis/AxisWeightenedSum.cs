using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoystickCombiner.deviceReader;
using JoystickCombiner.vJoyDevice;

namespace JoystickCombiner.axis
{
    class AxisWeightenedSum : Axis
    {
        private byte[] modesWeights;
        private byte[] modesButtons;

        static byte leftMode = 0;
        static byte rightMode = 0;
       
        public AxisWeightenedSum(DeviceReader leftDeviceReader, DeviceReader rightDeviceReader, VJoyDevice vJoyDevice, AxisName axisInput, AxisName axisOutput, bool centered)
            : base(leftDeviceReader, rightDeviceReader, vJoyDevice, axisInput, axisOutput, centered) 
        {
            modesWeights = new byte[3];
            modesWeights[0] = Properties.Settings.Default.mode1Weight;
            modesWeights[1] = Properties.Settings.Default.mode2Weight;
            modesWeights[2] = Properties.Settings.Default.mode3Weight;

            modesButtons = new byte[3];
            modesButtons[0] = Properties.Settings.Default.mode1Button;
            modesButtons[1] = Properties.Settings.Default.mode2Button;
            modesButtons[2] = Properties.Settings.Default.mode3Button;
        }

        public override int computeValue()
        {
            if (leftDeviceReader == null)
            {
                int rightState = centered ? rightDeviceReader.getAxisState(axisInput) - 32768 : rightDeviceReader.getAxisState(axisInput);

                updateMode(rightDeviceReader, 2);

                if (centered)
                    return (rightState * modesWeights[rightMode]) / 200 + 16384;
                else
                    return (rightState * modesWeights[rightMode]) / 200;
            }
            
            else if (rightDeviceReader == null)
            {
                int leftState = centered ? leftDeviceReader.getAxisState(axisInput) - 32768 : leftDeviceReader.getAxisState(axisInput);

                updateMode(leftDeviceReader, 1);

                if (centered)
                    return (leftState * modesWeights[leftMode]) / 200 + 16384;
                else
                    return (leftState * modesWeights[leftMode]) / 200;
            }
            
            else
            {
                int leftState = centered ? leftDeviceReader.getAxisState(axisInput) - 32768 : leftDeviceReader.getAxisState(axisInput);
                int rightState = centered ? rightDeviceReader.getAxisState(axisInput) - 32768 : rightDeviceReader.getAxisState(axisInput);
                
                updateMode(leftDeviceReader, 1);
                updateMode(rightDeviceReader, 2);

                if (centered)
                    return (leftState * modesWeights[leftMode] + rightState * modesWeights[rightMode]) / 200 + 16384;
                else
                    return (leftState * modesWeights[leftMode] + rightState * modesWeights[rightMode]) / 200;
            }
        }

        private void updateMode(DeviceReader device, short side)
        {
            if (device.GetType() == typeof(JoystickReader))
            {
                for (byte i = 0; i < 3; i++)
                {
                    if (device.getButtonState(modesButtons[i]))
                    {
                        switch (side)
                        {
                            case 1:
                                leftMode = i;
                                break;
                            case 2:
                                rightMode = i;
                                break;
                        }
                        break;
                    }
                }
            }
        }
    }
}
