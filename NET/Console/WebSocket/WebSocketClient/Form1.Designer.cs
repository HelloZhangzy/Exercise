namespace WebSocketClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbconfirmed = new System.Windows.Forms.CheckBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEUI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtData = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblen = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblen);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.cbAuto);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cbconfirmed);
            this.panel1.Controls.Add(this.txtData);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtEUI);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 100);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(319, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Disconnect";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "loriot.io",
            "loraflow.io"});
            this.comboBox1.Location = new System.Drawing.Point(44, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(171, 20);
            this.comboBox1.TabIndex = 13;
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(640, 67);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(48, 16);
            this.cbAuto.TabIndex = 12;
            this.cbAuto.Text = "Auto";
            this.cbAuto.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(557, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbconfirmed
            // 
            this.cbconfirmed.AutoSize = true;
            this.cbconfirmed.Checked = true;
            this.cbconfirmed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbconfirmed.Location = new System.Drawing.Point(436, 36);
            this.cbconfirmed.Name = "cbconfirmed";
            this.cbconfirmed.Size = new System.Drawing.Size(78, 16);
            this.cbconfirmed.TabIndex = 10;
            this.cbconfirmed.Text = "confirmed";
            this.cbconfirmed.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(43, 65);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(471, 21);
            this.txtData.TabIndex = 9;
            this.txtData.Text = "FFFFFFFF";
            this.txtData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtData_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(303, 37);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(91, 21);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // txtEUI
            // 
            this.txtEUI.Location = new System.Drawing.Point(43, 37);
            this.txtEUI.Name = "txtEUI";
            this.txtEUI.Size = new System.Drawing.Size(172, 21);
            this.txtEUI.TabIndex = 5;
            this.txtEUI.Text = "3339343768356218";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "EUI";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cloud";
            // 
            // rtxtData
            // 
            this.rtxtData.ContextMenuStrip = this.contextMenuStrip1;
            this.rtxtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtData.Location = new System.Drawing.Point(0, 100);
            this.rtxtData.Name = "rtxtData";
            this.rtxtData.Size = new System.Drawing.Size(796, 556);
            this.rtxtData.TabIndex = 2;
            this.rtxtData.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 26);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.清空ToolStripMenuItem.Text = "Clear";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // lblen
            // 
            this.lblen.AutoSize = true;
            this.lblen.Location = new System.Drawing.Point(520, 68);
            this.lblen.Name = "lblen";
            this.lblen.Size = new System.Drawing.Size(0, 12);
            this.lblen.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 656);
            this.Controls.Add(this.rtxtData);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebSocketClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbAuto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbconfirmed;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEUI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblen;
    }
}

