namespace _2CARPENELLI
{
    partial class ViewBreakPoints
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
            this.label1 = new System.Windows.Forms.Label();
            this.breakLine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.breakBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new _2CARPENELLI.RJButton();
            this.btnAdd = new _2CARPENELLI.RJButton();
            this.panelBodyBreakpoint = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelBodyBreakpoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(53, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "Address or Line:";
            // 
            // breakLine
            // 
            this.breakLine.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.breakLine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.breakLine.Location = new System.Drawing.Point(181, 23);
            this.breakLine.Multiline = true;
            this.breakLine.Name = "breakLine";
            this.breakLine.Size = new System.Drawing.Size(309, 26);
            this.breakLine.TabIndex = 56;
            this.breakLine.Text = "0";
            this.breakLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(42, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 44);
            this.label2.TabIndex = 53;
            this.label2.Text = "BREAKPOINTS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // breakBox
            // 
            this.breakBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.breakBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.breakBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.breakBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.breakBox.FormattingEnabled = true;
            this.breakBox.ItemHeight = 25;
            this.breakBox.Location = new System.Drawing.Point(50, 99);
            this.breakBox.Name = "breakBox";
            this.breakBox.Size = new System.Drawing.Size(836, 425);
            this.breakBox.TabIndex = 58;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.breakLine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 592);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 104);
            this.panel1.TabIndex = 59;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.btnDelete.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.btnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDelete.BorderRadius = 20;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(732, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 40);
            this.btnDelete.TabIndex = 59;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.Delete_Breakpoint);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.btnAdd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.btnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAdd.BorderRadius = 20;
            this.btnAdd.BorderSize = 0;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(567, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.TabIndex = 58;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.Add_Breakpoint);
            // 
            // panelBodyBreakpoint
            // 
            this.panelBodyBreakpoint.Controls.Add(this.breakBox);
            this.panelBodyBreakpoint.Controls.Add(this.label2);
            this.panelBodyBreakpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBodyBreakpoint.Location = new System.Drawing.Point(0, 0);
            this.panelBodyBreakpoint.Name = "panelBodyBreakpoint";
            this.panelBodyBreakpoint.Size = new System.Drawing.Size(938, 696);
            this.panelBodyBreakpoint.TabIndex = 60;
            // 
            // ViewBreakPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(37)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(938, 696);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBodyBreakpoint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewBreakPoints";
            this.Text = "ViewBreakPoints";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBodyBreakpoint.ResumeLayout(false);
            this.panelBodyBreakpoint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox breakLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox breakBox;
        private System.Windows.Forms.Panel panel1;
        private RJButton btnAdd;
        private RJButton btnDelete;
        private System.Windows.Forms.Panel panelBodyBreakpoint;
    }
}