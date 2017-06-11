namespace ProgressQuestWrapper
{
    partial class WrapperForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WrapperForm));
            this.wrapperPanel = new System.Windows.Forms.Panel();
            this.autostartLabel = new System.Windows.Forms.Label();
            this.autostartStatusCheckbox = new System.Windows.Forms.CheckBox();
            this.status2 = new System.Windows.Forms.Label();
            this.syncButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.status1 = new System.Windows.Forms.Label();
            this.status3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wrapperPanel
            // 
            this.wrapperPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wrapperPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.wrapperPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.wrapperPanel.Location = new System.Drawing.Point(12, 57);
            this.wrapperPanel.Name = "wrapperPanel";
            this.wrapperPanel.Size = new System.Drawing.Size(336, 224);
            this.wrapperPanel.TabIndex = 0;
            this.wrapperPanel.SizeChanged += new System.EventHandler(this.wrapperPanel_SizeChanged);
            // 
            // autostartLabel
            // 
            this.autostartLabel.AutoSize = true;
            this.autostartLabel.Location = new System.Drawing.Point(13, 17);
            this.autostartLabel.Name = "autostartLabel";
            this.autostartLabel.Size = new System.Drawing.Size(49, 13);
            this.autostartLabel.TabIndex = 1;
            this.autostartLabel.Text = "Autostart";
            // 
            // autostartStatusCheckbox
            // 
            this.autostartStatusCheckbox.AutoSize = true;
            this.autostartStatusCheckbox.Location = new System.Drawing.Point(68, 16);
            this.autostartStatusCheckbox.Name = "autostartStatusCheckbox";
            this.autostartStatusCheckbox.Size = new System.Drawing.Size(80, 17);
            this.autostartStatusCheckbox.TabIndex = 2;
            this.autostartStatusCheckbox.Text = "checkBox1";
            this.autostartStatusCheckbox.UseVisualStyleBackColor = true;
            this.autostartStatusCheckbox.CheckedChanged += new System.EventHandler(this.autostartStatusCheckbox_CheckedChanged);
            // 
            // status2
            // 
            this.status2.AutoSize = true;
            this.status2.Location = new System.Drawing.Point(311, 22);
            this.status2.Name = "status2";
            this.status2.Size = new System.Drawing.Size(0, 13);
            this.status2.TabIndex = 3;
            // 
            // syncButton
            // 
            this.syncButton.Location = new System.Drawing.Point(154, 12);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(75, 23);
            this.syncButton.TabIndex = 4;
            this.syncButton.Text = "Synchronize";
            this.syncButton.UseVisualStyleBackColor = true;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // status1
            // 
            this.status1.AutoSize = true;
            this.status1.Location = new System.Drawing.Point(313, 4);
            this.status1.Name = "status1";
            this.status1.Size = new System.Drawing.Size(0, 13);
            this.status1.TabIndex = 5;
            // 
            // status3
            // 
            this.status3.AutoSize = true;
            this.status3.Location = new System.Drawing.Point(313, 41);
            this.status3.Name = "status3";
            this.status3.Size = new System.Drawing.Size(0, 13);
            this.status3.TabIndex = 6;
            // 
            // WrapperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 293);
            this.Controls.Add(this.status3);
            this.Controls.Add(this.status1);
            this.Controls.Add(this.syncButton);
            this.Controls.Add(this.status2);
            this.Controls.Add(this.autostartStatusCheckbox);
            this.Controls.Add(this.autostartLabel);
            this.Controls.Add(this.wrapperPanel);
            this.Name = "WrapperForm";
            this.Text = "ProgressQuest Wrapper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WrapperForm_FormClosing);
            this.Resize += new System.EventHandler(this.WrapperForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel wrapperPanel;
        private System.Windows.Forms.Label autostartLabel;
        private System.Windows.Forms.CheckBox autostartStatusCheckbox;
        private System.Windows.Forms.Label status2;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label status1;
        private System.Windows.Forms.Label status3;
    }
}

