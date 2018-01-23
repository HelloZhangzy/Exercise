namespace CRT310_Demo
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.cbbaund = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYesCard = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnInCard = new System.Windows.Forms.Button();
            this.btnOutCard = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCheckCard = new System.Windows.Forms.Button();
            this.btnOpenCard = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbData = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tb42Data = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(0, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(768, 525);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IC卡相关";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 153);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读卡器相关";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenCom);
            this.splitContainer1.Panel1.Controls.Add(this.cbbaund);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cbCom);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnReset);
            this.splitContainer1.Panel2.Controls.Add(this.btnOutCard);
            this.splitContainer1.Panel2.Controls.Add(this.btnInCard);
            this.splitContainer1.Panel2.Controls.Add(this.btnNo);
            this.splitContainer1.Panel2.Controls.Add(this.btnYesCard);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Size = new System.Drawing.Size(762, 116);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 15;
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(427, 3);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(142, 48);
            this.btnOpenCom.TabIndex = 19;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click_1);
            // 
            // cbbaund
            // 
            this.cbbaund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbaund.FormattingEnabled = true;
            this.cbbaund.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "56700",
            "115200"});
            this.cbbaund.Location = new System.Drawing.Point(283, 10);
            this.cbbaund.Name = "cbbaund";
            this.cbbaund.Size = new System.Drawing.Size(102, 35);
            this.cbbaund.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 27);
            this.label2.TabIndex = 17;
            this.label2.Text = "波特率";
            // 
            // cbCom
            // 
            this.cbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Items.AddRange(new object[] {
            "Com1",
            "Com2",
            "Com3",
            "Com4",
            "Com5",
            "Com6"});
            this.cbCom.Location = new System.Drawing.Point(76, 10);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(102, 35);
            this.cbCom.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 27);
            this.label1.TabIndex = 15;
            this.label1.Text = "串口";
            // 
            // btnYesCard
            // 
            this.btnYesCard.Location = new System.Drawing.Point(6, 6);
            this.btnYesCard.Name = "btnYesCard";
            this.btnYesCard.Size = new System.Drawing.Size(145, 48);
            this.btnYesCard.TabIndex = 0;
            this.btnYesCard.Text = "允许进卡";
            this.btnYesCard.UseVisualStyleBackColor = true;
            this.btnYesCard.Click += new System.EventHandler(this.btnYesCard_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(151, 6);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(145, 48);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "禁止进卡";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnInCard
            // 
            this.btnInCard.Location = new System.Drawing.Point(296, 6);
            this.btnInCard.Name = "btnInCard";
            this.btnInCard.Size = new System.Drawing.Size(145, 48);
            this.btnInCard.TabIndex = 2;
            this.btnInCard.Text = "吞卡";
            this.btnInCard.UseVisualStyleBackColor = true;
            this.btnInCard.Click += new System.EventHandler(this.btnInCard_Click);
            // 
            // btnOutCard
            // 
            this.btnOutCard.Location = new System.Drawing.Point(441, 6);
            this.btnOutCard.Name = "btnOutCard";
            this.btnOutCard.Size = new System.Drawing.Size(145, 48);
            this.btnOutCard.TabIndex = 3;
            this.btnOutCard.Text = "吐卡";
            this.btnOutCard.UseVisualStyleBackColor = true;
            this.btnOutCard.Click += new System.EventHandler(this.btnOutCard_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(586, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(145, 48);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "复位";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnOpenCard);
            this.panel1.Controls.Add(this.btnCheckCard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 77);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 411);
            this.panel2.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox2);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.tb42Data);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 216);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(762, 195);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SEL4442";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.tbData);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(762, 216);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AT88SC102";
            // 
            // btnCheckCard
            // 
            this.btnCheckCard.Location = new System.Drawing.Point(6, 15);
            this.btnCheckCard.Name = "btnCheckCard";
            this.btnCheckCard.Size = new System.Drawing.Size(145, 48);
            this.btnCheckCard.TabIndex = 0;
            this.btnCheckCard.Text = "测卡";
            this.btnCheckCard.UseVisualStyleBackColor = true;
            this.btnCheckCard.Click += new System.EventHandler(this.btnCheckCard_Click);
            // 
            // btnOpenCard
            // 
            this.btnOpenCard.Location = new System.Drawing.Point(157, 15);
            this.btnOpenCard.Name = "btnOpenCard";
            this.btnOpenCard.Size = new System.Drawing.Size(145, 48);
            this.btnOpenCard.TabIndex = 1;
            this.btnOpenCard.Text = "上电";
            this.btnOpenCard.UseVisualStyleBackColor = true;
            this.btnOpenCard.Click += new System.EventHandler(this.btnOpenCard_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "下电";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 48);
            this.button2.TabIndex = 0;
            this.button2.Text = "验密";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(9, 33);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(142, 38);
            this.tbData.TabIndex = 1;
            this.tbData.Text = "F0F0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(460, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 48);
            this.button3.TabIndex = 2;
            this.button3.Text = "读卡";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(308, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 48);
            this.button4.TabIndex = 3;
            this.button4.Text = "改密";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(611, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 48);
            this.button5.TabIndex = 4;
            this.button5.Text = "写卡";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 82);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(744, 128);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox2.Location = new System.Drawing.Point(9, 91);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(744, 96);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(611, 37);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(145, 48);
            this.button6.TabIndex = 10;
            this.button6.Text = "写卡";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(308, 37);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(145, 48);
            this.button7.TabIndex = 9;
            this.button7.Text = "改密";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(460, 37);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(145, 48);
            this.button8.TabIndex = 8;
            this.button8.Text = "读卡";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tb42Data
            // 
            this.tb42Data.Location = new System.Drawing.Point(9, 42);
            this.tb42Data.Name = "tb42Data";
            this.tb42Data.Size = new System.Drawing.Size(142, 38);
            this.tb42Data.TabIndex = 7;
            this.tb42Data.Text = "FFFFFF";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(157, 37);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(145, 48);
            this.button9.TabIndex = 6;
            this.button9.Text = "验密";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 678);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "CRT310_DLL_Demo";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.ComboBox cbbaund;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYesCard;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnInCard;
        private System.Windows.Forms.Button btnOutCard;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOpenCard;
        private System.Windows.Forms.Button btnCheckCard;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox tb42Data;
        private System.Windows.Forms.Button button9;
    }
}

