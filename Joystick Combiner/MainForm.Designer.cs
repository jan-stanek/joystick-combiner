namespace joystickCombiner
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.comboLeftJoystick = new System.Windows.Forms.ComboBox();
            this.labelLeftJoystick = new System.Windows.Forms.Label();
            this.labelRightJoystick = new System.Windows.Forms.Label();
            this.labelLeftRudder = new System.Windows.Forms.Label();
            this.comboRightJoystick = new System.Windows.Forms.ComboBox();
            this.comboLeftRudder = new System.Windows.Forms.ComboBox();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.checkAutostart = new System.Windows.Forms.CheckBox();
            this.buttonLoadSettings = new System.Windows.Forms.Button();
            this.radioActiveBoth = new System.Windows.Forms.RadioButton();
            this.radioActiveRight = new System.Windows.Forms.RadioButton();
            this.radioActiveLeft = new System.Windows.Forms.RadioButton();
            this.labelActive = new System.Windows.Forms.Label();
            this.buttonAxes = new System.Windows.Forms.Button();
            this.buttonRescan = new System.Windows.Forms.Button();
            this.comboRightRudder = new System.Windows.Forms.ComboBox();
            this.labelRightRudder = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(258, 157);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(90, 23);
            this.buttonSaveSettings.TabIndex = 15;
            this.buttonSaveSettings.Text = "Save settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // comboLeftJoystick
            // 
            this.comboLeftJoystick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLeftJoystick.FormattingEnabled = true;
            this.comboLeftJoystick.Location = new System.Drawing.Point(85, 19);
            this.comboLeftJoystick.Name = "comboLeftJoystick";
            this.comboLeftJoystick.Size = new System.Drawing.Size(359, 21);
            this.comboLeftJoystick.TabIndex = 1;
            this.comboLeftJoystick.SelectedIndexChanged += new System.EventHandler(this.comboLeftJoystick_SelectedIndexChanged);
            // 
            // labelLeftJoystick
            // 
            this.labelLeftJoystick.AutoSize = true;
            this.labelLeftJoystick.Location = new System.Drawing.Point(6, 22);
            this.labelLeftJoystick.Name = "labelLeftJoystick";
            this.labelLeftJoystick.Size = new System.Drawing.Size(66, 13);
            this.labelLeftJoystick.TabIndex = 0;
            this.labelLeftJoystick.Text = "Left joystick:";
            // 
            // labelRightJoystick
            // 
            this.labelRightJoystick.AutoSize = true;
            this.labelRightJoystick.Location = new System.Drawing.Point(6, 76);
            this.labelRightJoystick.Name = "labelRightJoystick";
            this.labelRightJoystick.Size = new System.Drawing.Size(73, 13);
            this.labelRightJoystick.TabIndex = 4;
            this.labelRightJoystick.Text = "Right joystick:";
            // 
            // labelLeftRudder
            // 
            this.labelLeftRudder.AutoSize = true;
            this.labelLeftRudder.Location = new System.Drawing.Point(6, 49);
            this.labelLeftRudder.Name = "labelLeftRudder";
            this.labelLeftRudder.Size = new System.Drawing.Size(61, 13);
            this.labelLeftRudder.TabIndex = 2;
            this.labelLeftRudder.Text = "Left rudder:";
            // 
            // comboRightJoystick
            // 
            this.comboRightJoystick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRightJoystick.FormattingEnabled = true;
            this.comboRightJoystick.Location = new System.Drawing.Point(85, 73);
            this.comboRightJoystick.Name = "comboRightJoystick";
            this.comboRightJoystick.Size = new System.Drawing.Size(359, 21);
            this.comboRightJoystick.TabIndex = 5;
            this.comboRightJoystick.SelectedIndexChanged += new System.EventHandler(this.comboRightJoystick_SelectedIndexChanged);
            // 
            // comboLeftRudder
            // 
            this.comboLeftRudder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLeftRudder.FormattingEnabled = true;
            this.comboLeftRudder.Location = new System.Drawing.Point(85, 46);
            this.comboLeftRudder.Name = "comboLeftRudder";
            this.comboLeftRudder.Size = new System.Drawing.Size(359, 21);
            this.comboLeftRudder.TabIndex = 3;
            this.comboLeftRudder.SelectedIndexChanged += new System.EventHandler(this.comboLeftRudder_SelectedIndexChanged);
            // 
            // groupSettings
            // 
            this.groupSettings.Controls.Add(this.checkAutostart);
            this.groupSettings.Controls.Add(this.buttonLoadSettings);
            this.groupSettings.Controls.Add(this.radioActiveBoth);
            this.groupSettings.Controls.Add(this.radioActiveRight);
            this.groupSettings.Controls.Add(this.radioActiveLeft);
            this.groupSettings.Controls.Add(this.labelActive);
            this.groupSettings.Controls.Add(this.buttonAxes);
            this.groupSettings.Controls.Add(this.buttonSaveSettings);
            this.groupSettings.Controls.Add(this.buttonRescan);
            this.groupSettings.Controls.Add(this.comboRightRudder);
            this.groupSettings.Controls.Add(this.labelRightRudder);
            this.groupSettings.Controls.Add(this.labelLeftJoystick);
            this.groupSettings.Controls.Add(this.comboRightJoystick);
            this.groupSettings.Controls.Add(this.comboLeftRudder);
            this.groupSettings.Controls.Add(this.comboLeftJoystick);
            this.groupSettings.Controls.Add(this.labelRightJoystick);
            this.groupSettings.Controls.Add(this.labelLeftRudder);
            this.groupSettings.Location = new System.Drawing.Point(12, 12);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(450, 185);
            this.groupSettings.TabIndex = 0;
            this.groupSettings.TabStop = false;
            this.groupSettings.Text = "Device settings";
            // 
            // checkAutostart
            // 
            this.checkAutostart.AutoSize = true;
            this.checkAutostart.Location = new System.Drawing.Point(85, 160);
            this.checkAutostart.Name = "checkAutostart";
            this.checkAutostart.Size = new System.Drawing.Size(67, 17);
            this.checkAutostart.TabIndex = 14;
            this.checkAutostart.Text = "autostart";
            this.checkAutostart.UseVisualStyleBackColor = true;
            this.checkAutostart.CheckedChanged += new System.EventHandler(this.checkAutostart_CheckedChanged);
            // 
            // buttonLoadSettings
            // 
            this.buttonLoadSettings.Location = new System.Drawing.Point(354, 157);
            this.buttonLoadSettings.Name = "buttonLoadSettings";
            this.buttonLoadSettings.Size = new System.Drawing.Size(90, 23);
            this.buttonLoadSettings.TabIndex = 16;
            this.buttonLoadSettings.Text = "Load settings";
            this.buttonLoadSettings.UseVisualStyleBackColor = true;
            this.buttonLoadSettings.Click += new System.EventHandler(this.buttonLoadSettings_Click);
            // 
            // radioActiveBoth
            // 
            this.radioActiveBoth.AutoSize = true;
            this.radioActiveBoth.Checked = true;
            this.radioActiveBoth.Location = new System.Drawing.Point(85, 130);
            this.radioActiveBoth.Name = "radioActiveBoth";
            this.radioActiveBoth.Size = new System.Drawing.Size(101, 17);
            this.radioActiveBoth.TabIndex = 9;
            this.radioActiveBoth.TabStop = true;
            this.radioActiveBoth.Text = "both (combined)";
            this.radioActiveBoth.UseVisualStyleBackColor = true;
            this.radioActiveBoth.CheckedChanged += new System.EventHandler(this.radioActiveBoth_CheckedChanged);
            // 
            // radioActiveRight
            // 
            this.radioActiveRight.AutoSize = true;
            this.radioActiveRight.Location = new System.Drawing.Point(237, 130);
            this.radioActiveRight.Name = "radioActiveRight";
            this.radioActiveRight.Size = new System.Drawing.Size(45, 17);
            this.radioActiveRight.TabIndex = 11;
            this.radioActiveRight.TabStop = true;
            this.radioActiveRight.Text = "right";
            this.radioActiveRight.UseVisualStyleBackColor = true;
            this.radioActiveRight.CheckedChanged += new System.EventHandler(this.radioActiveRight_CheckedChanged);
            // 
            // radioActiveLeft
            // 
            this.radioActiveLeft.AutoSize = true;
            this.radioActiveLeft.Location = new System.Drawing.Point(192, 130);
            this.radioActiveLeft.Name = "radioActiveLeft";
            this.radioActiveLeft.Size = new System.Drawing.Size(39, 17);
            this.radioActiveLeft.TabIndex = 10;
            this.radioActiveLeft.Text = "left";
            this.radioActiveLeft.UseVisualStyleBackColor = true;
            this.radioActiveLeft.CheckedChanged += new System.EventHandler(this.radioActiveLeft_CheckedChanged);
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Location = new System.Drawing.Point(6, 132);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(40, 13);
            this.labelActive.TabIndex = 8;
            this.labelActive.Text = "Active:";
            // 
            // buttonAxes
            // 
            this.buttonAxes.Location = new System.Drawing.Point(288, 128);
            this.buttonAxes.Name = "buttonAxes";
            this.buttonAxes.Size = new System.Drawing.Size(75, 23);
            this.buttonAxes.TabIndex = 12;
            this.buttonAxes.Text = "Axes";
            this.buttonAxes.Click += new System.EventHandler(this.buttonAxes_Click);
            // 
            // buttonRescan
            // 
            this.buttonRescan.Location = new System.Drawing.Point(369, 127);
            this.buttonRescan.Name = "buttonRescan";
            this.buttonRescan.Size = new System.Drawing.Size(75, 23);
            this.buttonRescan.TabIndex = 13;
            this.buttonRescan.Text = "Rescan";
            this.buttonRescan.UseVisualStyleBackColor = true;
            this.buttonRescan.Click += new System.EventHandler(this.buttonRescan_Click);
            // 
            // comboRightRudder
            // 
            this.comboRightRudder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRightRudder.FormattingEnabled = true;
            this.comboRightRudder.Location = new System.Drawing.Point(85, 100);
            this.comboRightRudder.Name = "comboRightRudder";
            this.comboRightRudder.Size = new System.Drawing.Size(359, 21);
            this.comboRightRudder.TabIndex = 7;
            this.comboRightRudder.SelectedIndexChanged += new System.EventHandler(this.comboRightRudder_SelectedIndexChanged);
            // 
            // labelRightRudder
            // 
            this.labelRightRudder.AutoSize = true;
            this.labelRightRudder.Location = new System.Drawing.Point(6, 103);
            this.labelRightRudder.Name = "labelRightRudder";
            this.labelRightRudder.Size = new System.Drawing.Size(68, 13);
            this.labelRightRudder.TabIndex = 6;
            this.labelRightRudder.Text = "Right rudder:";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Lime;
            this.buttonStart.Location = new System.Drawing.Point(12, 203);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(222, 26);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Red;
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(240, 203);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(222, 26);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 241);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Joystick combiner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.ComboBox comboLeftJoystick;
        private System.Windows.Forms.Label labelLeftJoystick;
        private System.Windows.Forms.Label labelRightJoystick;
        private System.Windows.Forms.Label labelLeftRudder;
        private System.Windows.Forms.ComboBox comboRightJoystick;
        private System.Windows.Forms.ComboBox comboLeftRudder;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.ComboBox comboRightRudder;
        private System.Windows.Forms.Label labelRightRudder;
        private System.Windows.Forms.Button buttonRescan;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkAutostart;
        private System.Windows.Forms.Button buttonLoadSettings;
        private System.Windows.Forms.RadioButton radioActiveBoth;
        private System.Windows.Forms.RadioButton radioActiveRight;
        private System.Windows.Forms.RadioButton radioActiveLeft;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.Button buttonAxes;
    }
}

