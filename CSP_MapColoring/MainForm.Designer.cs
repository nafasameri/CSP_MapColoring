namespace CSP_MapColoring
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProblem = new System.Windows.Forms.TabPage();
            this.pnlProblem = new System.Windows.Forms.Panel();
            this.btnRandomGenerateGraph = new System.Windows.Forms.Button();
            this.grbSelectValue = new System.Windows.Forms.GroupBox();
            this.rbtnFirstToEnd = new System.Windows.Forms.RadioButton();
            this.rbtnLCV = new System.Windows.Forms.RadioButton();
            this.rbtnEndToFirst = new System.Windows.Forms.RadioButton();
            this.grbEdges = new System.Windows.Forms.GroupBox();
            this.btnOKEdge = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cmbToVertices = new System.Windows.Forms.ComboBox();
            this.cmbFromVertices = new System.Windows.Forms.ComboBox();
            this.grbSelectVariable = new System.Windows.Forms.GroupBox();
            this.clbVariable = new System.Windows.Forms.CheckedListBox();
            this.grbNumOfVertices = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtNumOfVertices = new System.Windows.Forms.TextBox();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.lblLog = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnDomains = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBackTracking = new System.Windows.Forms.Button();
            this.btnArcConsistency = new System.Windows.Forms.Button();
            this.btnForwardChecking = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabProblem.SuspendLayout();
            this.pnlProblem.SuspendLayout();
            this.grbSelectValue.SuspendLayout();
            this.grbEdges.SuspendLayout();
            this.grbSelectVariable.SuspendLayout();
            this.grbNumOfVertices.SuspendLayout();
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
            this.tabProblem.BackColor = System.Drawing.SystemColors.Control;
            this.tabProblem.Controls.Add(this.pnlProblem);
            this.tabProblem.Controls.Add(this.grbSelectValue);
            this.tabProblem.Controls.Add(this.grbEdges);
            this.tabProblem.Controls.Add(this.grbSelectVariable);
            this.tabProblem.Controls.Add(this.grbNumOfVertices);
            this.tabProblem.ForeColor = System.Drawing.Color.Black;
            this.tabProblem.Location = new System.Drawing.Point(4, 27);
            this.tabProblem.Margin = new System.Windows.Forms.Padding(4);
            this.tabProblem.Name = "tabProblem";
            this.tabProblem.Padding = new System.Windows.Forms.Padding(4);
            this.tabProblem.Size = new System.Drawing.Size(970, 526);
            this.tabProblem.TabIndex = 0;
            this.tabProblem.Text = "Problem";
            // 
            // pnlProblem
            // 
            this.pnlProblem.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProblem.Controls.Add(this.btnRandomGenerateGraph);
            this.pnlProblem.Location = new System.Drawing.Point(238, 8);
            this.pnlProblem.Name = "pnlProblem";
            this.pnlProblem.Size = new System.Drawing.Size(732, 511);
            this.pnlProblem.TabIndex = 12;
            this.pnlProblem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.pnlProblem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.pnlProblem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // btnRandomGenerateGraph
            // 
            this.btnRandomGenerateGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandomGenerateGraph.Location = new System.Drawing.Point(553, 465);
            this.btnRandomGenerateGraph.Name = "btnRandomGenerateGraph";
            this.btnRandomGenerateGraph.Size = new System.Drawing.Size(172, 43);
            this.btnRandomGenerateGraph.TabIndex = 11;
            this.btnRandomGenerateGraph.Text = "Random Generate Graph";
            this.btnRandomGenerateGraph.UseVisualStyleBackColor = true;
            this.btnRandomGenerateGraph.Click += new System.EventHandler(this.btnRandomGenerateGraph_Click);
            // 
            // grbSelectValue
            // 
            this.grbSelectValue.Controls.Add(this.rbtnFirstToEnd);
            this.grbSelectValue.Controls.Add(this.rbtnLCV);
            this.grbSelectValue.Controls.Add(this.rbtnEndToFirst);
            this.grbSelectValue.Enabled = false;
            this.grbSelectValue.Location = new System.Drawing.Point(8, 429);
            this.grbSelectValue.Name = "grbSelectValue";
            this.grbSelectValue.Size = new System.Drawing.Size(224, 90);
            this.grbSelectValue.TabIndex = 13;
            this.grbSelectValue.TabStop = false;
            this.grbSelectValue.Text = "Select Value";
            // 
            // rbtnFirstToEnd
            // 
            this.rbtnFirstToEnd.AutoSize = true;
            this.rbtnFirstToEnd.Location = new System.Drawing.Point(12, 23);
            this.rbtnFirstToEnd.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.rbtnFirstToEnd.Name = "rbtnFirstToEnd";
            this.rbtnFirstToEnd.Size = new System.Drawing.Size(102, 22);
            this.rbtnFirstToEnd.TabIndex = 3;
            this.rbtnFirstToEnd.TabStop = true;
            this.rbtnFirstToEnd.Text = "First To End";
            this.rbtnFirstToEnd.UseVisualStyleBackColor = true;
            // 
            // rbtnLCV
            // 
            this.rbtnLCV.AutoSize = true;
            this.rbtnLCV.Location = new System.Drawing.Point(12, 63);
            this.rbtnLCV.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.rbtnLCV.Name = "rbtnLCV";
            this.rbtnLCV.Size = new System.Drawing.Size(49, 22);
            this.rbtnLCV.TabIndex = 2;
            this.rbtnLCV.TabStop = true;
            this.rbtnLCV.Text = "LCV";
            this.rbtnLCV.UseVisualStyleBackColor = true;
            // 
            // rbtnEndToFirst
            // 
            this.rbtnEndToFirst.AutoSize = true;
            this.rbtnEndToFirst.Location = new System.Drawing.Point(12, 43);
            this.rbtnEndToFirst.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.rbtnEndToFirst.Name = "rbtnEndToFirst";
            this.rbtnEndToFirst.Size = new System.Drawing.Size(102, 22);
            this.rbtnEndToFirst.TabIndex = 1;
            this.rbtnEndToFirst.TabStop = true;
            this.rbtnEndToFirst.Text = "End To First";
            this.rbtnEndToFirst.UseVisualStyleBackColor = true;
            // 
            // grbEdges
            // 
            this.grbEdges.Controls.Add(this.btnOKEdge);
            this.grbEdges.Controls.Add(this.lblTo);
            this.grbEdges.Controls.Add(this.lblFrom);
            this.grbEdges.Controls.Add(this.cmbToVertices);
            this.grbEdges.Controls.Add(this.cmbFromVertices);
            this.grbEdges.Enabled = false;
            this.grbEdges.Location = new System.Drawing.Point(8, 161);
            this.grbEdges.Name = "grbEdges";
            this.grbEdges.Size = new System.Drawing.Size(224, 174);
            this.grbEdges.TabIndex = 2;
            this.grbEdges.TabStop = false;
            this.grbEdges.Text = "Edges";
            // 
            // btnOKEdge
            // 
            this.btnOKEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOKEdge.Location = new System.Drawing.Point(104, 122);
            this.btnOKEdge.Name = "btnOKEdge";
            this.btnOKEdge.Size = new System.Drawing.Size(92, 37);
            this.btnOKEdge.TabIndex = 0;
            this.btnOKEdge.Text = "Ok";
            this.btnOKEdge.UseVisualStyleBackColor = true;
            this.btnOKEdge.Click += new System.EventHandler(this.btnOKEdge_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(23, 81);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(24, 18);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(23, 49);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 18);
            this.lblFrom.TabIndex = 8;
            this.lblFrom.Text = "From";
            // 
            // cmbToVertices
            // 
            this.cmbToVertices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToVertices.FormattingEnabled = true;
            this.cmbToVertices.Location = new System.Drawing.Point(75, 78);
            this.cmbToVertices.Name = "cmbToVertices";
            this.cmbToVertices.Size = new System.Drawing.Size(121, 26);
            this.cmbToVertices.TabIndex = 1;
            // 
            // cmbFromVertices
            // 
            this.cmbFromVertices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromVertices.FormattingEnabled = true;
            this.cmbFromVertices.Location = new System.Drawing.Point(75, 46);
            this.cmbFromVertices.Name = "cmbFromVertices";
            this.cmbFromVertices.Size = new System.Drawing.Size(121, 26);
            this.cmbFromVertices.TabIndex = 0;
            // 
            // grbSelectVariable
            // 
            this.grbSelectVariable.Controls.Add(this.clbVariable);
            this.grbSelectVariable.Enabled = false;
            this.grbSelectVariable.Location = new System.Drawing.Point(8, 342);
            this.grbSelectVariable.Name = "grbSelectVariable";
            this.grbSelectVariable.Size = new System.Drawing.Size(224, 81);
            this.grbSelectVariable.TabIndex = 3;
            this.grbSelectVariable.TabStop = false;
            this.grbSelectVariable.Text = "Select Variable";
            // 
            // clbVariable
            // 
            this.clbVariable.CheckOnClick = true;
            this.clbVariable.FormattingEnabled = true;
            this.clbVariable.Items.AddRange(new object[] {
            "MRV",
            "Most Degree"});
            this.clbVariable.Location = new System.Drawing.Point(3, 28);
            this.clbVariable.Name = "clbVariable";
            this.clbVariable.Size = new System.Drawing.Size(218, 46);
            this.clbVariable.TabIndex = 0;
            // 
            // grbNumOfVertices
            // 
            this.grbNumOfVertices.Controls.Add(this.btnOk);
            this.grbNumOfVertices.Controls.Add(this.txtNumOfVertices);
            this.grbNumOfVertices.Location = new System.Drawing.Point(8, 7);
            this.grbNumOfVertices.Name = "grbNumOfVertices";
            this.grbNumOfVertices.Size = new System.Drawing.Size(224, 149);
            this.grbNumOfVertices.TabIndex = 6;
            this.grbNumOfVertices.TabStop = false;
            this.grbNumOfVertices.Text = "Vertices";
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(104, 88);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 37);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNumOfVertices
            // 
            this.txtNumOfVertices.Location = new System.Drawing.Point(26, 45);
            this.txtNumOfVertices.Name = "txtNumOfVertices";
            this.txtNumOfVertices.Size = new System.Drawing.Size(170, 26);
            this.txtNumOfVertices.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.BackColor = System.Drawing.SystemColors.Control;
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
            // 
            // pnlResult
            // 
            this.pnlResult.BackColor = System.Drawing.SystemColors.Control;
            this.pnlResult.Location = new System.Drawing.Point(8, 8);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(615, 511);
            this.pnlResult.TabIndex = 2;
            this.pnlResult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.pnlResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.pnlResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(629, 4);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(33, 18);
            this.lblLog.TabIndex = 1;
            this.lblLog.Text = "Log:";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(629, 25);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(334, 494);
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
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(884, 564);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 43);
            this.btnExit.TabIndex = 5;
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
            this.btnBackTracking.TabIndex = 1;
            this.btnBackTracking.Text = "BackTracking";
            this.btnBackTracking.UseVisualStyleBackColor = true;
            this.btnBackTracking.Click += new System.EventHandler(this.btnBackTracking_Click);
            // 
            // btnArcConsistency
            // 
            this.btnArcConsistency.Enabled = false;
            this.btnArcConsistency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArcConsistency.Location = new System.Drawing.Point(277, 564);
            this.btnArcConsistency.Name = "btnArcConsistency";
            this.btnArcConsistency.Size = new System.Drawing.Size(151, 43);
            this.btnArcConsistency.TabIndex = 4;
            this.btnArcConsistency.Text = "BT+Arc Consistency";
            this.btnArcConsistency.UseVisualStyleBackColor = true;
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
            this.btnForwardChecking.Click += new System.EventHandler(this.btnForwardChecking_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(979, 614);
            this.Controls.Add(this.btnForwardChecking);
            this.Controls.Add(this.btnArcConsistency);
            this.Controls.Add(this.btnBackTracking);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDomains);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CSP solver";
            this.tabControl.ResumeLayout(false);
            this.tabProblem.ResumeLayout(false);
            this.pnlProblem.ResumeLayout(false);
            this.grbSelectValue.ResumeLayout(false);
            this.grbSelectValue.PerformLayout();
            this.grbEdges.ResumeLayout(false);
            this.grbEdges.PerformLayout();
            this.grbSelectVariable.ResumeLayout(false);
            this.grbNumOfVertices.ResumeLayout(false);
            this.grbNumOfVertices.PerformLayout();
            this.tabResult.ResumeLayout(false);
            this.tabResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProblem;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.GroupBox grbNumOfVertices;
        private System.Windows.Forms.GroupBox grbEdges;
        private System.Windows.Forms.GroupBox grbSelectVariable;
        private System.Windows.Forms.GroupBox grbSelectValue;
        private System.Windows.Forms.CheckedListBox clbVariable;
        private System.Windows.Forms.TextBox txtNumOfVertices;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnDomains;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBackTracking;
        private System.Windows.Forms.Button btnOKEdge;
        private System.Windows.Forms.Button btnArcConsistency;
        private System.Windows.Forms.Button btnForwardChecking;
        private System.Windows.Forms.Button btnRandomGenerateGraph;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.ComboBox cmbToVertices;
        private System.Windows.Forms.ComboBox cmbFromVertices;
        private System.Windows.Forms.Panel pnlProblem;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.RadioButton rbtnEndToFirst;
        private System.Windows.Forms.RadioButton rbtnLCV;
        private System.Windows.Forms.RadioButton rbtnFirstToEnd;
    }
}

