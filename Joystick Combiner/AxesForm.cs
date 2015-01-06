using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace joystickCombiner
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

        private void axisFormInit(ComboBox axis, ComboBox method, TextBox change, CheckBox centered, string selectedAxis, byte selectedMethod, byte changeValue, bool centeredValue)
        {
            axis.Items.Add("none");
            axis.Items.Add("X");
            axis.Items.Add("Y");
            axis.Items.Add("Z");
            axis.Items.Add("RotationX");
            axis.Items.Add("RotationY");
            axis.Items.Add("RotationZ");
            axis.Items.Add("Slider");

            method.Items.Add("Weightened sum");
            method.Items.Add("Change");
            method.Items.Add("Minimum");
            method.Items.Add("Maximum");

            axis.SelectedItem = selectedAxis;
            method.SelectedIndex = selectedMethod;
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
            Properties.Settings.Default.axisXMethod = (byte)comboXMethod.SelectedIndex;
            methodChanged(comboXMethod, textboxXChange, checkboxXCentered);
        }

        private void comboYMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisYMethod = (byte)comboYMethod.SelectedIndex;
            methodChanged(comboYMethod, textboxYChange, checkboxYCentered);
        }

        private void comboTwistMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisTwistMethod = (byte)comboTwistMethod.SelectedIndex;
            methodChanged(comboTwistMethod, textboxTwistChange, checkboxTwistCentered);
        }

        private void comboThrottleMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisThrottleMethod = (byte)comboThrottleMethod.SelectedIndex;
            methodChanged(comboThrottleMethod, textboxThrottleChange, checkboxThrottleCentered);
        }

        private void comboRotary1Method_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRotary1Method = (byte)comboRotary1Method.SelectedIndex;
            methodChanged(comboRotary1Method, textboxRotary1Change, checkboxRotary1Centered);
        }

        private void comboRotary2Method_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRotary2Method = (byte)comboRotary2Method.SelectedIndex;
            methodChanged(comboRotary2Method, textboxRotary2Change, checkboxRotary2Centered);
        }

        private void comboSliderMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisSliderMethod = (byte)comboSliderMethod.SelectedIndex;
            methodChanged(comboSliderMethod, textboxSliderChange, checkboxSliderCentered);
        }

        private void comboLeftToeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisLeftToeMethod = (byte)comboLeftToeMethod.SelectedIndex;
            methodChanged(comboLeftToeMethod, textboxLeftToeChange, checkboxLeftToeCentered);
        }

        private void comboRightToeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRightToeMethod = (byte)comboRightToeMethod.SelectedIndex;
            methodChanged(comboRightToeMethod, textboxRightToeChange, checkboxRightToeCentered);
        }

        private void comboRudderMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRudderMethod = (byte)comboRudderMethod.SelectedIndex;
            methodChanged(comboRudderMethod, textboxRudderChange, checkboxRudderCentered);
        }

        private void comboXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisXAxis = comboXAxis.SelectedItem.ToString();
        }

        private void comboYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisYAxis = comboYAxis.SelectedItem.ToString();
        }

        private void comboTwistAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisTwistAxis = comboTwistAxis.SelectedItem.ToString();
        }

        private void comboThrottleAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisThrottleAxis = comboThrottleAxis.SelectedItem.ToString();
        }

        private void comboRotary1Axis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRotary1Axis = comboRotary1Axis.SelectedItem.ToString();
        }

        private void comboRotary2Axis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRotary2Axis = comboRotary2Axis.SelectedItem.ToString();
        }

        private void comboSliderAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisSliderAxis = comboSliderAxis.SelectedItem.ToString();
        }

        private void comboLeftToeAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisLeftToeAxis = comboLeftToeAxis.SelectedItem.ToString();
        }

        private void comboRightToeAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRightToeAxis = comboRightToeAxis.SelectedItem.ToString();
        }

        private void comboRudderAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRudderAxis = comboRudderAxis.SelectedItem.ToString();
        }

        private void checkboxXCentered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisXCentered = checkboxXCentered.Checked;
        }

        private void checkboxYCentered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisYCentered = checkboxYCentered.Checked;
        }

        private void checkboxTwistCentered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisTwistCentered = checkboxTwistCentered.Checked;
        }

        private void checkboxThrottleCentered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisThrottleCentered = checkboxThrottleCentered.Checked;
        }

        private void checkboxRotary1Centered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRotary1Centered = checkboxRotary1Centered.Checked;
        }

        private void checkboxRotary2Centered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRotary2Centered = checkboxRotary2Centered.Checked;
        }

        private void checkboxSliderCentered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisSliderCentered = checkboxSliderCentered.Checked;
        }

        private void checkboxLeftToeCentered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisLeftToeCentered = checkboxLeftToeCentered.Checked;
        }

        private void checkboxRightToeCentered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRightToeCentered = checkboxRightToeCentered.Checked;
        }

        private void checkboxRudderCentered_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRudderCentered = checkboxRudderCentered.Checked;
        }

        private void textboxMode1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mode1Weight = byte.Parse(textboxMode1.Text);
        }

        private void textboxMode2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mode2Weight = byte.Parse(textboxMode2.Text);
        }

        private void textboxMode3_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mode3Weight = byte.Parse(textboxMode3.Text);
        }

        private void textboxXChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisXChange = byte.Parse(textboxXChange.Text);
        }

        private void textboxYChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisYChange = byte.Parse(textboxYChange.Text);
        }

        private void textboxTwistChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisTwistChange = byte.Parse(textboxTwistChange.Text);
        }

        private void textboxThrottleChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisThrottleChange = byte.Parse(textboxThrottleChange.Text);
        }

        private void textboxRotary1Change_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRotary1Change = byte.Parse(textboxRotary1Change.Text);
        }

        private void textboxRotary2Change_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRotary2Change = byte.Parse(textboxRotary2Change.Text);
        }

        private void textboxSliderChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisSliderChange = byte.Parse(textboxSliderChange.Text);
        }

        private void textboxLeftToeChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisLeftToeChange = byte.Parse(textboxLeftToeChange.Text);
        }

        private void textboxRightToeChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRightToeChange = byte.Parse(textboxRightToeChange.Text);
        }

        private void textboxRudderChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.axisRudderChange = byte.Parse(textboxRudderChange.Text);
        }

        private void textboxChange_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.changeInterval = short.Parse(textboxChange.Text);
        }

        private void textboxMode1Button_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mode1Button = byte.Parse(textboxMode1Button.Text);
        }

        private void textboxMode2Button_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mode2Button = byte.Parse(textboxMode2Button.Text);
        }

        private void textboxMode3Button_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mode3Button = byte.Parse(textboxMode3Button.Text);
        }
    }
}
