using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JoystickCombiner.Axes;

namespace JoystickCombiner
{
    public partial class AxesForm : Form
    {
        public AxesForm()
        {
            InitializeComponent();

            loadSettings();
        }

        private void loadSettings()
        {
            textboxMode1.Text = Properties.Settings.Default.mode1Weight.ToString();
            textboxMode2.Text = Properties.Settings.Default.mode2Weight.ToString();
            textboxMode3.Text = Properties.Settings.Default.mode3Weight.ToString();
            textboxMode1Button.Text = Properties.Settings.Default.mode1Button.ToString();
            textboxMode2Button.Text = Properties.Settings.Default.mode2Button.ToString();
            textboxMode3Button.Text = Properties.Settings.Default.mode3Button.ToString();
            textboxChange.Text = Properties.Settings.Default.changeInterval.ToString();

            axisFormInit(comboXAxis, comboXMethod, textboxXChange, checkboxXCentered, Properties.Settings.Default.axisXAxis, Properties.Settings.Default.axisXMethod, Properties.Settings.Default.axisXChange, Properties.Settings.Default.axisXCentered);
            axisFormInit(comboYAxis, comboYMethod, textboxYChange, checkboxYCentered, Properties.Settings.Default.axisYAxis, Properties.Settings.Default.axisYMethod, Properties.Settings.Default.axisYChange, Properties.Settings.Default.axisYCentered);
            axisFormInit(comboTwistAxis, comboTwistMethod, textboxTwistChange, checkboxTwistCentered, Properties.Settings.Default.axisTwistAxis, Properties.Settings.Default.axisTwistMethod, Properties.Settings.Default.axisTwistChange, Properties.Settings.Default.axisTwistCentered);
            axisFormInit(comboThrottleAxis, comboThrottleMethod, textboxThrottleChange, checkboxThrottleCentered, Properties.Settings.Default.axisThrottleAxis, Properties.Settings.Default.axisThrottleMethod, Properties.Settings.Default.axisThrottleChange, Properties.Settings.Default.axisThrottleCentered);
            axisFormInit(comboRotary1Axis, comboRotary1Method, textboxRotary1Change, checkboxRotary1Centered, Properties.Settings.Default.axisRotary1Axis, Properties.Settings.Default.axisRotary1Method, Properties.Settings.Default.axisRotary1Change, Properties.Settings.Default.axisRotary1Centered);
            axisFormInit(comboRotary2Axis, comboRotary2Method, textboxRotary2Change, checkboxRotary2Centered, Properties.Settings.Default.axisRotary2Axis, Properties.Settings.Default.axisRotary2Method, Properties.Settings.Default.axisRotary2Change, Properties.Settings.Default.axisRotary2Centered);
            axisFormInit(comboSliderAxis, comboSliderMethod, textboxSliderChange, checkboxSliderCentered, Properties.Settings.Default.axisSliderAxis, Properties.Settings.Default.axisSliderMethod, Properties.Settings.Default.axisSliderChange, Properties.Settings.Default.axisSliderCentered);

            axisFormInit(comboLeftToeAxis, comboLeftToeMethod, textboxLeftToeChange, checkboxLeftToeCentered, Properties.Settings.Default.axisLeftToeAxis, Properties.Settings.Default.axisLeftToeMethod, Properties.Settings.Default.axisLeftToeChange, Properties.Settings.Default.axisLeftToeCentered);
            axisFormInit(comboRightToeAxis, comboRightToeMethod, textboxRightToeChange, checkboxRightToeCentered, Properties.Settings.Default.axisRightToeAxis, Properties.Settings.Default.axisRightToeMethod, Properties.Settings.Default.axisRightToeChange, Properties.Settings.Default.axisRightToeCentered);
            axisFormInit(comboRudderAxis, comboRudderMethod, textboxRudderChange, checkboxRudderCentered, Properties.Settings.Default.axisRudderAxis, Properties.Settings.Default.axisRudderMethod, Properties.Settings.Default.axisRudderChange, Properties.Settings.Default.axisRudderCentered);
        }

        private void axisFormInit(ComboBox axis, ComboBox method, TextBox change, CheckBox centered, byte selectedAxis, byte selectedMethod, byte changeValue, bool centeredValue)
        {
            axis.Items.AddRange(Enum.GetNames(typeof(AxisName)));
            method.Items.AddRange(Enum.GetNames(typeof(AxisMethod)));

            axis.SelectedItem = Enum.GetName(typeof(AxisName), selectedAxis);
            method.SelectedItem = Enum.GetName(typeof(AxisMethod), selectedMethod);
            change.Text = changeValue.ToString();
            methodChanged(method, change, centered);
            centered.Checked = centeredValue;
        }

        private void methodChanged(ComboBox method, TextBox change, CheckBox centered)
        {
            if (method.SelectedItem.Equals("Change"))
            {
                change.Enabled = true;
                centered.Enabled = false;
            }
            else
            {
                change.Enabled = false;
                centered.Enabled = true;
            }
        }

        private void comboXMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboXMethod, textboxXChange, checkboxXCentered);
        }

        private void comboYMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboYMethod, textboxYChange, checkboxYCentered);
        }

        private void comboTwistMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboTwistMethod, textboxTwistChange, checkboxTwistCentered);
        }

        private void comboThrottleMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboThrottleMethod, textboxThrottleChange, checkboxThrottleCentered);
        }

        private void comboRotary1Method_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboRotary1Method, textboxRotary1Change, checkboxRotary1Centered);
        }

        private void comboRotary2Method_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboRotary2Method, textboxRotary2Change, checkboxRotary2Centered);
        }

        private void comboSliderMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboSliderMethod, textboxSliderChange, checkboxSliderCentered);
        }

        private void comboLeftToeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboLeftToeMethod, textboxLeftToeChange, checkboxLeftToeCentered);
        }

        private void comboRightToeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboRightToeMethod, textboxRightToeChange, checkboxRightToeCentered);
        }

        private void comboRudderMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodChanged(comboRudderMethod, textboxRudderChange, checkboxRudderCentered);
        }

        private void AxesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.axisXMethod = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboXMethod.SelectedItem.ToString());
            Properties.Settings.Default.axisYMethod = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboYMethod.SelectedItem.ToString());
            Properties.Settings.Default.axisTwistMethod = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboTwistMethod.SelectedItem.ToString());
            Properties.Settings.Default.axisThrottleMethod = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboThrottleMethod.SelectedItem.ToString());
            Properties.Settings.Default.axisRotary1Method = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboRotary1Method.SelectedItem.ToString());
            Properties.Settings.Default.axisRotary2Method = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboRotary2Method.SelectedItem.ToString());
            Properties.Settings.Default.axisSliderMethod = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboSliderMethod.SelectedItem.ToString());
            Properties.Settings.Default.axisLeftToeMethod = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboLeftToeMethod.SelectedItem.ToString());
            Properties.Settings.Default.axisRightToeMethod = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboRightToeMethod.SelectedItem.ToString());
            Properties.Settings.Default.axisRudderMethod = (byte)(AxisMethod)Enum.Parse(typeof(AxisMethod), comboRudderMethod.SelectedItem.ToString());

            Properties.Settings.Default.axisXAxis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboXAxis.SelectedItem.ToString());
            Properties.Settings.Default.axisYAxis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboYAxis.SelectedItem.ToString());
            Properties.Settings.Default.axisTwistAxis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboTwistAxis.SelectedItem.ToString());
            Properties.Settings.Default.axisThrottleAxis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboThrottleAxis.SelectedItem.ToString());
            Properties.Settings.Default.axisRotary1Axis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboRotary1Axis.SelectedItem.ToString());
            Properties.Settings.Default.axisRotary2Axis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboRotary2Axis.SelectedItem.ToString());
            Properties.Settings.Default.axisSliderAxis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboSliderAxis.SelectedItem.ToString());
            Properties.Settings.Default.axisLeftToeAxis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboLeftToeAxis.SelectedItem.ToString());
            Properties.Settings.Default.axisRightToeAxis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboRightToeAxis.SelectedItem.ToString());
            Properties.Settings.Default.axisRudderAxis = (byte)(AxisName)Enum.Parse(typeof(AxisName), comboRudderAxis.SelectedItem.ToString());

            Properties.Settings.Default.axisXCentered = checkboxXCentered.Checked;
            Properties.Settings.Default.axisYCentered = checkboxYCentered.Checked;
            Properties.Settings.Default.axisTwistCentered = checkboxTwistCentered.Checked;
            Properties.Settings.Default.axisThrottleCentered = checkboxThrottleCentered.Checked;
            Properties.Settings.Default.axisRotary1Centered = checkboxRotary1Centered.Checked;
            Properties.Settings.Default.axisRotary2Centered = checkboxRotary2Centered.Checked;
            Properties.Settings.Default.axisSliderCentered = checkboxSliderCentered.Checked;
            Properties.Settings.Default.axisLeftToeCentered = checkboxLeftToeCentered.Checked;
            Properties.Settings.Default.axisRightToeCentered = checkboxRightToeCentered.Checked;
            Properties.Settings.Default.axisRudderCentered = checkboxRudderCentered.Checked;

            try
            {
                byte tmp;

                tmp = byte.Parse(textboxMode1.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.mode1Weight = tmp;

                tmp = byte.Parse(textboxMode2.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.mode2Weight = tmp;

                tmp = byte.Parse(textboxMode3.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.mode3Weight = tmp;
            }
            catch (FormatException)
            {
                MessageBox.Show("Mode weight must be a number 0-100", "Joystick Combiner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            try
            {
                byte tmp;

                tmp = byte.Parse(textboxXChange.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisXChange = tmp;

                tmp = byte.Parse(textboxYChange.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisYChange = tmp;

                tmp = byte.Parse(textboxTwistChange.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisTwistChange = tmp;

                tmp = byte.Parse(textboxThrottleChange.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisThrottleChange = tmp;

                tmp = byte.Parse(textboxRotary1Change.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisRotary1Change = tmp;

                tmp = byte.Parse(textboxRotary2Change.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisRotary2Change = tmp;

                tmp = byte.Parse(textboxSliderChange.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisSliderChange = tmp;

                tmp = byte.Parse(textboxLeftToeChange.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisLeftToeChange = tmp;

                tmp = byte.Parse(textboxRightToeChange.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisRightToeChange = tmp;

                tmp = byte.Parse(textboxRudderChange.Text);
                if (tmp > 100)
                    throw new FormatException();
                Properties.Settings.Default.axisRudderChange = tmp;
            }
            catch (FormatException)
            {
                MessageBox.Show("Change must be a number 0-100", "Joystick Combiner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            try
            {
                short tmp = short.Parse(textboxChange.Text);
                if (tmp < 0)
                    throw new FormatException();
                Properties.Settings.Default.changeInterval = tmp;
            }
            catch (FormatException)
            {
                MessageBox.Show("Change interval must be a number greater than 0", "Joystick Combiner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            try
            {
                byte tmp;

                tmp = byte.Parse(textboxMode1Button.Text);
                if (tmp < 1)
                    throw new FormatException();
                Properties.Settings.Default.mode1Button = tmp;

                tmp = byte.Parse(textboxMode2Button.Text);
                if (tmp < 1)
                    throw new FormatException();
                Properties.Settings.Default.mode2Button = tmp;

                tmp = byte.Parse(textboxMode3Button.Text);
                if (tmp < 1)
                    throw new FormatException();
                Properties.Settings.Default.mode3Button = tmp;
            }
            catch (FormatException)
            {
                MessageBox.Show("Mode button must be a number greater than 0", "Joystick Combiner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
        }
    }
}
