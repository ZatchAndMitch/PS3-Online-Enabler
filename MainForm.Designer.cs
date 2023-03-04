
namespace PS3_Online_Enabler
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
            this.btnStart = new MetroFramework.Controls.MetroButton();
            this.btnMore = new MetroFramework.Controls.MetroButton();
            this.lbPort = new MetroFramework.Controls.MetroLabel();
            this.tbxPort = new MetroFramework.Controls.MetroTextBox();
            this.lbIP = new MetroFramework.Controls.MetroLabel();
            this.lbInfo = new MetroFramework.Controls.MetroLabel();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnStart.Location = new System.Drawing.Point(128, 208);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(144, 44);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnMore
            // 
            this.btnMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMore.Location = new System.Drawing.Point(304, 311);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(89, 27);
            this.btnMore.TabIndex = 2;
            this.btnMore.Text = "more tools";
            this.btnMore.UseSelectable = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbPort.Location = new System.Drawing.Point(132, 162);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(47, 25);
            this.lbPort.TabIndex = 1;
            this.lbPort.Text = "Port:";
            // 
            // tbxPort
            // 
            // 
            // 
            // 
            this.tbxPort.CustomButton.Image = null;
            this.tbxPort.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.tbxPort.CustomButton.Name = "";
            this.tbxPort.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbxPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxPort.CustomButton.TabIndex = 1;
            this.tbxPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxPort.CustomButton.UseSelectable = true;
            this.tbxPort.CustomButton.Visible = false;
            this.tbxPort.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tbxPort.Lines = new string[] {
        "8080"};
            this.tbxPort.Location = new System.Drawing.Point(185, 164);
            this.tbxPort.MaxLength = 5;
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.PasswordChar = '\0';
            this.tbxPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxPort.SelectedText = "";
            this.tbxPort.SelectionLength = 0;
            this.tbxPort.SelectionStart = 0;
            this.tbxPort.ShortcutsEnabled = true;
            this.tbxPort.Size = new System.Drawing.Size(75, 23);
            this.tbxPort.TabIndex = 1;
            this.tbxPort.Text = "8080";
            this.tbxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxPort.UseSelectable = true;
            this.tbxPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPort_KeyPress);
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbIP.Location = new System.Drawing.Point(95, 121);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(217, 25);
            this.lbIP.TabIndex = 1;
            this.lbIP.Text = "listening on IP 192.168.1.50";
            this.lbIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbIP.Visible = false;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(12, 332);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(152, 19);
            this.lbInfo.TabIndex = 8;
            this.lbInfo.Text = "v 1.0 by Zatch and Mitch";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Location = new System.Drawing.Point(304, 278);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(89, 27);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 361);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PS3 Online Enabler";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnStart;
        private MetroFramework.Controls.MetroButton btnMore;
        private MetroFramework.Controls.MetroLabel lbPort;
        private MetroFramework.Controls.MetroTextBox tbxPort;
        private MetroFramework.Controls.MetroLabel lbIP;
        private MetroFramework.Controls.MetroLabel lbInfo;
        private MetroFramework.Controls.MetroButton btnUpdate;
    }
}

