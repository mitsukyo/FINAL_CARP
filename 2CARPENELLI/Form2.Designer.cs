namespace _2CARPENELLI
{
    partial class Form2
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
            this.memLocation = new System.Windows.Forms.TextBox();
            this.datamove_txt = new System.Windows.Forms.Label();
            this.rtl_txt = new System.Windows.Forms.Label();
            this.memoryLoc_txt = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.status_txt = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.instructionCode = new System.Windows.Forms.TextBox();
            this.panelTxt = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelShowBody = new System.Windows.Forms.Panel();
            this.rjButton1 = new _2CARPENELLI.RJButton();
            this.btnAssemble = new _2CARPENELLI.RJButton();
            this.panelTxt.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // memLocation
            // 
            this.memLocation.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.memLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.memLocation.Location = new System.Drawing.Point(20, 160);
            this.memLocation.Multiline = true;
            this.memLocation.Name = "memLocation";
            this.memLocation.Size = new System.Drawing.Size(314, 28);
            this.memLocation.TabIndex = 238;
            this.memLocation.Text = "0";
            this.memLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // datamove_txt
            // 
            this.datamove_txt.AutoSize = true;
            this.datamove_txt.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.datamove_txt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datamove_txt.Location = new System.Drawing.Point(73, 95);
            this.datamove_txt.Name = "datamove_txt";
            this.datamove_txt.Size = new System.Drawing.Size(48, 18);
            this.datamove_txt.TabIndex = 237;
            this.datamove_txt.Text = "Fetch";
            // 
            // rtl_txt
            // 
            this.rtl_txt.AutoSize = true;
            this.rtl_txt.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rtl_txt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtl_txt.Location = new System.Drawing.Point(212, 73);
            this.rtl_txt.Name = "rtl_txt";
            this.rtl_txt.Size = new System.Drawing.Size(48, 18);
            this.rtl_txt.TabIndex = 236;
            this.rtl_txt.Text = "Fetch";
            // 
            // memoryLoc_txt
            // 
            this.memoryLoc_txt.AutoSize = true;
            this.memoryLoc_txt.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.memoryLoc_txt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.memoryLoc_txt.Location = new System.Drawing.Point(250, 123);
            this.memoryLoc_txt.Name = "memoryLoc_txt";
            this.memoryLoc_txt.Size = new System.Drawing.Size(16, 18);
            this.memoryLoc_txt.TabIndex = 235;
            this.memoryLoc_txt.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label22.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Location = new System.Drawing.Point(32, 121);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(201, 20);
            this.label22.TabIndex = 234;
            this.label22.Text = "Current Memory Location:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label23.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label23.Location = new System.Drawing.Point(32, 71);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(171, 20);
            this.label23.TabIndex = 233;
            this.label23.Text = "Current RTL Statement:";
            // 
            // status_txt
            // 
            this.status_txt.AutoSize = true;
            this.status_txt.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.status_txt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status_txt.Location = new System.Drawing.Point(212, 36);
            this.status_txt.Name = "status_txt";
            this.status_txt.Size = new System.Drawing.Size(70, 18);
            this.status_txt.TabIndex = 231;
            this.status_txt.Text = "Stopped";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label24.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label24.Location = new System.Drawing.Point(32, 35);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(150, 20);
            this.label24.TabIndex = 229;
            this.label24.Text = "Current CPU Status:";
            // 
            // instructionCode
            // 
            this.instructionCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instructionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.instructionCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.instructionCode.Location = new System.Drawing.Point(20, 194);
            this.instructionCode.Multiline = true;
            this.instructionCode.Name = "instructionCode";
            this.instructionCode.Size = new System.Drawing.Size(314, 477);
            this.instructionCode.TabIndex = 224;
            // 
            // panelTxt
            // 
            this.panelTxt.AutoScroll = true;
            this.panelTxt.AutoSize = true;
            this.panelTxt.Controls.Add(this.panel1);
            this.panelTxt.Controls.Add(this.instructionCode);
            this.panelTxt.Controls.Add(this.memLocation);
            this.panelTxt.Controls.Add(this.datamove_txt);
            this.panelTxt.Controls.Add(this.label24);
            this.panelTxt.Controls.Add(this.rtl_txt);
            this.panelTxt.Controls.Add(this.status_txt);
            this.panelTxt.Controls.Add(this.memoryLoc_txt);
            this.panelTxt.Controls.Add(this.label23);
            this.panelTxt.Controls.Add(this.label22);
            this.panelTxt.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTxt.Location = new System.Drawing.Point(0, 0);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(352, 818);
            this.panelTxt.TabIndex = 239;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rjButton1);
            this.panel1.Controls.Add(this.btnAssemble);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 701);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 117);
            this.panel1.TabIndex = 239;
            // 
            // panelTop
            // 
            this.panelTop.AutoSize = true;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(37)))), ((int)(((byte)(69)))));
            this.panelTop.Controls.Add(this.button5);
            this.panelTop.Controls.Add(this.button4);
            this.panelTop.Controls.Add(this.button3);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(352, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(929, 69);
            this.panelTop.TabIndex = 240;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.SystemColors.Control;
            this.button5.Location = new System.Drawing.Point(627, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(215, 61);
            this.button5.TabIndex = 3;
            this.button5.Text = "View Trace Results";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.View_TraceResults);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(63, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(215, 61);
            this.button4.TabIndex = 2;
            this.button4.Text = "Memory And IO";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.View_MemoryAndIO);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(352, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 61);
            this.button3.TabIndex = 1;
            this.button3.Text = "View Breakpoints";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.View_Breakpoints);
            // 
            // panelShowBody
            // 
            this.panelShowBody.AutoSize = true;
            this.panelShowBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowBody.Location = new System.Drawing.Point(352, 69);
            this.panelShowBody.Name = "panelShowBody";
            this.panelShowBody.Size = new System.Drawing.Size(929, 749);
            this.panelShowBody.TabIndex = 241;
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(35, 60);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(287, 38);
            this.rjButton1.TabIndex = 60;
            this.rjButton1.Text = "VIEW SYSTEM";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // btnAssemble
            // 
            this.btnAssemble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.btnAssemble.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.btnAssemble.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAssemble.BorderRadius = 20;
            this.btnAssemble.BorderSize = 0;
            this.btnAssemble.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssemble.FlatAppearance.BorderSize = 0;
            this.btnAssemble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssemble.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAssemble.ForeColor = System.Drawing.Color.White;
            this.btnAssemble.Location = new System.Drawing.Point(35, 16);
            this.btnAssemble.Name = "btnAssemble";
            this.btnAssemble.Size = new System.Drawing.Size(287, 38);
            this.btnAssemble.TabIndex = 59;
            this.btnAssemble.Text = "ASSEMBLE";
            this.btnAssemble.TextColor = System.Drawing.Color.White;
            this.btnAssemble.UseVisualStyleBackColor = false;
            this.btnAssemble.Click += new System.EventHandler(this.btnAssemble_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(37)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1281, 818);
            this.Controls.Add(this.panelShowBody);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Click += new System.EventHandler(this.Form2_Click);
            this.panelTxt.ResumeLayout(false);
            this.panelTxt.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox memLocation;
        private System.Windows.Forms.Label datamove_txt;
        private System.Windows.Forms.Label rtl_txt;
        private System.Windows.Forms.Label memoryLoc_txt;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label status_txt;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox instructionCode;
        private System.Windows.Forms.Panel panelTxt;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelShowBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private RJButton btnAssemble;
        private RJButton rjButton1;
    }
}