namespace CSP_MapColoring
{
    partial class Main
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProblem = new System.Windows.Forms.TabPage();
            this.pnlProblem = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.grbSelectVar_Val = new System.Windows.Forms.GroupBox();
            this.clbVar_Val = new System.Windows.Forms.CheckedListBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblNumOfVertices = new System.Windows.Forms.Label();
            this.txtNumOfVertices = new System.Windows.Forms.TextBox();
            this.cmbToVertices = new System.Windows.Forms.ComboBox();
            this.cmbFromVertices = new System.Windows.Forms.ComboBox();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.lblLog = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnDomains = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBackTracking = new System.Windows.Forms.Button();
            this.btnForwardChecking = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabProblem.SuspendLayout();
            this.pnlProblem.SuspendLayout();
            this.grbSelectVar_Val.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabProblem);
            this.tabControl.Controls.Add(this.tabResult);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(978, 557);
            this.tabControl.TabIndex = 0;
            // 
            // tabProblem
            // 
            this.tabProblem.Controls.Add(this.pnlProblem);
            this.tabProblem.Location = new System.Drawing.Point(4, 27);
            this.tabProblem.Margin = new System.Windows.Forms.Padding(4);
            this.tabProblem.Name = "tabProblem";
            this.tabProblem.Padding = new System.Windows.Forms.Padding(4);
            this.tabProblem.Size = new System.Drawing.Size(970, 526);
            this.tabProblem.TabIndex = 0;
            this.tabProblem.Text = "Problem";
            this.tabProblem.UseVisualStyleBackColor = true;
            // 
            // pnlProblem
            // 
            this.pnlProblem.Controls.Add(this.btnOk);
            this.pnlProblem.Controls.Add(this.grbSelectVar_Val);
            this.pnlProblem.Controls.Add(this.lblTo);
            this.pnlProblem.Controls.Add(this.lblFrom);
            this.pnlProblem.Controls.Add(this.lblNumOfVertices);
            this.pnlProblem.Controls.Add(this.txtNumOfVertices);
            this.pnlProblem.Controls.Add(this.cmbToVertices);
            this.pnlProblem.Controls.Add(this.cmbFromVertices);
            this.pnlProblem.Location = new System.Drawing.Point(0, 0);
            this.pnlProblem.Name = "pnlProblem";
            this.pnlProblem.Size = new System.Drawing.Size(438, 526);
            this.pnlProblem.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(311, 22);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 37);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grbSelectVar_Val
            // 
            this.grbSelectVar_Val.Controls.Add(this.clbVar_Val);
            this.grbSelectVar_Val.Location = new System.Drawing.Point(29, 216);
            this.grbSelectVar_Val.Name = "grbSelectVar_Val";
            this.grbSelectVar_Val.Size = new System.Drawing.Size(163, 94);
            this.grbSelectVar_Val.TabIndex = 3;
            this.grbSelectVar_Val.TabStop = false;
            this.grbSelectVar_Val.Text = "Select Variable, Value";
            // 
            // clbVar_Val
            // 
            this.clbVar_Val.FormattingEnabled = true;
            this.clbVar_Val.Items.AddRange(new object[] {
            "MRV",
            "Most Degree",
            "LCV"});
            this.clbVar_Val.Location = new System.Drawing.Point(3, 25);
            this.clbVar_Val.Name = "clbVar_Val";
            this.clbVar_Val.Size = new System.Drawing.Size(157, 67);
            this.clbVar_Val.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(19, 128);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(24, 18);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(19, 96);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 18);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "From";
            // 
            // lblNumOfVertices
            // 
            this.lblNumOfVertices.AutoSize = true;
            this.lblNumOfVertices.Location = new System.Drawing.Point(19, 31);
            this.lblNumOfVertices.Name = "lblNumOfVertices";
            this.lblNumOfVertices.Size = new System.Drawing.Size(131, 18);
            this.lblNumOfVertices.TabIndex = 3;
            this.lblNumOfVertices.Text = "Number of Vertices:";
            // 
            // txtNumOfVertices
            // 
            this.txtNumOfVertices.Location = new System.Drawing.Point(156, 28);
            this.txtNumOfVertices.Name = "txtNumOfVertices";
            this.txtNumOfVertices.Size = new System.Drawing.Size(131, 26);
            this.txtNumOfVertices.TabIndex = 2;
            // 
            // cmbToVertices
            // 
            this.cmbToVertices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToVertices.FormattingEnabled = true;
            this.cmbToVertices.Location = new System.Drawing.Point(71, 125);
            this.cmbToVertices.Name = "cmbToVertices";
            this.cmbToVertices.Size = new System.Drawing.Size(121, 26);
            this.cmbToVertices.TabIndex = 1;
            // 
            // cmbFromVertices
            // 
            this.cmbFromVertices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromVertices.FormattingEnabled = true;
            this.cmbFromVertices.Location = new System.Drawing.Point(71, 93);
            this.cmbFromVertices.Name = "cmbFromVertices";
            this.cmbFromVertices.Size = new System.Drawing.Size(121, 26);
            this.cmbFromVertices.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.pnlResult);
            this.tabResult.Controls.Add(this.lblLog);
            this.tabResult.Controls.Add(this.rtbLog);
            this.tabResult.Location = new System.Drawing.Point(4, 27);
            this.tabResult.Margin = new System.Windows.Forms.Padding(4);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(4);
            this.tabResult.Size = new System.Drawing.Size(970, 526);
            this.tabResult.TabIndex = 1;
            this.tabResult.Text = "Solving Result";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // pnlResult
            // 
            this.pnlResult.Location = new System.Drawing.Point(8, 8);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(729, 511);
            this.pnlResult.TabIndex = 2;
            this.pnlResult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.pnlResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.pnlResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(740, 4);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(33, 18);
            this.lblLog.TabIndex = 1;
            this.lblLog.Text = "Log:";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(743, 25);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(211, 494);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // btnDomains
            // 
            this.btnDomains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDomains.Location = new System.Drawing.Point(795, 564);
            this.btnDomains.Name = "btnDomains";
            this.btnDomains.Size = new System.Drawing.Size(83, 43);
            this.btnDomains.TabIndex = 0;
            this.btnDomains.Text = "Domains";
            this.btnDomains.UseVisualStyleBackColor = true;
            this.btnDomains.Click += new System.EventHandler(this.btnDomains_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(884, 564);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 43);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBackTracking
            // 
            this.btnBackTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackTracking.Location = new System.Drawing.Point(4, 564);
            this.btnBackTracking.Name = "btnBackTracking";
            this.btnBackTracking.Size = new System.Drawing.Size(110, 43);
            this.btnBackTracking.TabIndex = 4;
            this.btnBackTracking.Text = "BackTracking";
            this.btnBackTracking.UseVisualStyleBackColor = true;
            // 
            // btnForwardChecking
            // 
            this.btnForwardChecking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForwardChecking.Location = new System.Drawing.Point(120, 564);
            this.btnForwardChecking.Name = "btnForwardChecking";
            this.btnForwardChecking.Size = new System.Drawing.Size(151, 43);
            this.btnForwardChecking.TabIndex = 6;
            this.btnForwardChecking.Text = "BT+ForwardChecking";
            this.btnForwardChecking.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 614);
            this.Controls.Add(this.btnForwardChecking);
            this.Controls.Add(this.btnBackTracking);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDomains);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "CSP solver";
            this.tabControl.ResumeLayout(false);
            this.tabProblem.ResumeLayout(false);
            this.pnlProblem.ResumeLayout(false);
            this.pnlProblem.PerformLayout();
            this.grbSelectVar_Val.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.tabResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProblem;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.Button btnDomains;
        private System.Windows.Forms.GroupBox grbSelectVar_Val;
        private System.Windows.Forms.CheckedListBox clbVar_Val;
        private System.Windows.Forms.Panel pnlProblem;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblNumOfVertices;
        private System.Windows.Forms.TextBox txtNumOfVertices;
        private System.Windows.Forms.ComboBox cmbToVertices;
        private System.Windows.Forms.ComboBox cmbFromVertices;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBackTracking;
        private System.Windows.Forms.Button btnForwardChecking;
    }
}

