﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpDX.DirectInput;
using Microsoft.Win32;


namespace JoystickCombiner
{
    public partial class MainForm : Form
    {
        private JoystickCombiner joystickCombiner;
        private NotifyIcon notifyIcon;

        public MainForm()
        {
            InitializeComponent();
            
            joystickCombiner = new JoystickCombiner();

            loadSettings();

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = this.Icon;
            notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);

            if (checkAutostart.Checked)
            {
                start();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void start()
        {
            disableSetting();
            try
            {
                joystickCombiner.start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Joystick Combiner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stop();
            }
        }

        private void stop()
        {
            enableSetting();
            joystickCombiner.stop();
        }

        private void disableSetting()
        {
            groupSettings.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }

        private void enableSetting()
        {
            groupSettings.Enabled = true;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void updateJoysticks()
        {
            comboLeftJoystick.Items.Clear();
            comboRightJoystick.Items.Clear();

            foreach (string device in joystickCombiner.getDevicesList(DeviceType.Joystick))
            {
                comboLeftJoystick.Items.Add(device);
                comboRightJoystick.Items.Add(device);
            }
        }

        private void updateRudders()
        {
            comboLeftRudder.Items.Clear();
            comboRightRudder.Items.Clear();

            foreach (string device in joystickCombiner.getDevicesList(DeviceType.Flight))
            {
                comboLeftRudder.Items.Add(device);
                comboRightRudder.Items.Add(device);
            }
        }

        private void selectDevices()
        {
            comboLeftJoystick.SelectedItem = Properties.Settings.Default.leftJoystick;
            comboRightJoystick.SelectedItem = Properties.Settings.Default.rightJoystick;
            comboLeftRudder.SelectedItem = Properties.Settings.Default.leftRudder;
            comboRightRudder.SelectedItem = Properties.Settings.Default.rightRudder;
        }

        private void loadSettings()
        {
            if (Properties.Settings.Default.upgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.upgrade = false;
                saveSettings();
            }

            switch (Properties.Settings.Default.active)
            {
                case 0:
                    radioActiveBoth.Checked = true;
                    break;
                case 1:
                    radioActiveLeft.Checked = true;
                    break;
                case 2:
                    radioActiveRight.Checked = true;
                    break;
            }

            checkAutostart.Checked = Properties.Settings.Default.autostart;

            updateJoysticks();
            updateRudders();
            selectDevices();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.Save();
            updateAutostart(); 
        }

        private void updateAutostart()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (Properties.Settings.Default.autostart)
                registryKey.SetValue("Joystick combiner", Application.ExecutablePath);
            else if (registryKey.GetValue("Joystick combiner") != null)
                registryKey.DeleteValue("Joystick combiner");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            start();
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void buttonLoadSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            loadSettings();
        }

        private void buttonRescan_Click(object sender, EventArgs e)
        {
            updateJoysticks();
            updateRudders();
            selectDevices();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void buttonAxes_Click(object sender, EventArgs e)
        {
            new AxesForm().ShowDialog();
        }

        private void comboLeftJoystick_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.leftJoystick = comboLeftJoystick.SelectedItem.ToString();
        }

        private void comboLeftRudder_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.leftRudder = comboLeftRudder.SelectedItem.ToString();
        }

        private void comboRightJoystick_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rightJoystick = comboRightJoystick.SelectedItem.ToString();            
        }

        private void comboRightRudder_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rightRudder = comboRightRudder.SelectedItem.ToString();
        }

        private void radioActiveBoth_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.active = 0;
            comboLeftJoystick.Enabled = true;
            comboLeftRudder.Enabled = true;
            comboRightJoystick.Enabled = true;
            comboRightRudder.Enabled = true;
        }

        private void radioActiveLeft_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.active = 1;
            comboLeftJoystick.Enabled = true;
            comboLeftRudder.Enabled = true;
            comboRightJoystick.Enabled = false;
            comboRightRudder.Enabled = false;
        }

        private void radioActiveRight_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.active = 2;
            comboLeftJoystick.Enabled = false;
            comboLeftRudder.Enabled = false;
            comboRightJoystick.Enabled = true;
            comboRightRudder.Enabled = true;
        }

        private void checkAutostart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autostart = checkAutostart.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool running = joystickCombiner.isRunning();
            if (e.CloseReason != CloseReason.WindowsShutDown && running &&
                MessageBox.Show("Do really want to stop and exit?", "Joystick Combiner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if (running)
                    joystickCombiner.stop();
                Application.Exit();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
                this.Show();
            }
        }
    }
}
