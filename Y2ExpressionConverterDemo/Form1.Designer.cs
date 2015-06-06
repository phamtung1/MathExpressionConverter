namespace Y2_Expression_Converter_Demo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtInfixExpression = new System.Windows.Forms.TextBox();
            this.btnStartPause = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlExpression = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlStack = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlOutput = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFinalExpression = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radInfix2Prefix = new System.Windows.Forms.RadioButton();
            this.radInfix2Postfix = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnStepForward = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bsTreePanel1 = new WindowsFormsApplication2.BSTreePanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInfixExpression
            // 
            this.txtInfixExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfixExpression.Location = new System.Drawing.Point(127, 22);
            this.txtInfixExpression.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInfixExpression.Name = "txtInfixExpression";
            this.txtInfixExpression.Size = new System.Drawing.Size(707, 22);
            this.txtInfixExpression.TabIndex = 0;
            this.txtInfixExpression.Text = "1+1+(2+3)";
            // 
            // btnStartPause
            // 
            this.btnStartPause.Location = new System.Drawing.Point(283, 6);
            this.btnStartPause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(86, 27);
            this.btnStartPause.TabIndex = 1;
            this.btnStartPause.Text = "Start";
            this.btnStartPause.UseVisualStyleBackColor = true;
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(19, 318);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(833, 246);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Token";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stack";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Output";
            this.columnHeader3.Width = 150;
            // 
            // pnlExpression
            // 
            this.pnlExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExpression.AutoScroll = true;
            this.pnlExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExpression.Location = new System.Drawing.Point(19, 31);
            this.pnlExpression.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlExpression.Name = "pnlExpression";
            this.pnlExpression.Size = new System.Drawing.Size(821, 39);
            this.pnlExpression.TabIndex = 3;
            this.pnlExpression.WrapContents = false;
            // 
            // pnlStack
            // 
            this.pnlStack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStack.AutoScroll = true;
            this.pnlStack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStack.Location = new System.Drawing.Point(19, 98);
            this.pnlStack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStack.Name = "pnlStack";
            this.pnlStack.Size = new System.Drawing.Size(821, 39);
            this.pnlStack.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlOutput
            // 
            this.pnlOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOutput.AutoScroll = true;
            this.pnlOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOutput.Location = new System.Drawing.Point(19, 165);
            this.pnlOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(821, 39);
            this.pnlOutput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Final Expression ";
            // 
            // txtFinalExpression
            // 
            this.txtFinalExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinalExpression.BackColor = System.Drawing.Color.LightCyan;
            this.txtFinalExpression.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinalExpression.ForeColor = System.Drawing.Color.Maroon;
            this.txtFinalExpression.Location = new System.Drawing.Point(135, 274);
            this.txtFinalExpression.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFinalExpression.Name = "txtFinalExpression";
            this.txtFinalExpression.Size = new System.Drawing.Size(586, 23);
            this.txtFinalExpression.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(766, 7);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(86, 22);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(691, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Delay (ms):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Infix Expression:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(378, 6);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 27);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Infix Expression (formatted): ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Stack:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Output:";
            // 
            // radInfix2Prefix
            // 
            this.radInfix2Prefix.AutoSize = true;
            this.radInfix2Prefix.Location = new System.Drawing.Point(135, 12);
            this.radInfix2Prefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radInfix2Prefix.Name = "radInfix2Prefix";
            this.radInfix2Prefix.Size = new System.Drawing.Size(108, 20);
            this.radInfix2Prefix.TabIndex = 11;
            this.radInfix2Prefix.Text = "Infix to Prefix";
            this.radInfix2Prefix.UseVisualStyleBackColor = true;
            this.radInfix2Prefix.CheckedChanged += new System.EventHandler(this.radInfix2Prefix_CheckedChanged);
            // 
            // radInfix2Postfix
            // 
            this.radInfix2Postfix.AutoSize = true;
            this.radInfix2Postfix.Checked = true;
            this.radInfix2Postfix.Location = new System.Drawing.Point(19, 12);
            this.radInfix2Postfix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radInfix2Postfix.Name = "radInfix2Postfix";
            this.radInfix2Postfix.Size = new System.Drawing.Size(114, 20);
            this.radInfix2Postfix.TabIndex = 11;
            this.radInfix2Postfix.TabStop = true;
            this.radInfix2Postfix.Text = "Infix to Postfix";
            this.radInfix2Postfix.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pnlOutput);
            this.panel1.Controls.Add(this.pnlStack);
            this.panel1.Controls.Add(this.pnlExpression);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(13, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 222);
            this.panel1.TabIndex = 12;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(729, 273);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(124, 28);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export As HTML";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnStepForward
            // 
            this.btnStepForward.Location = new System.Drawing.Point(472, 6);
            this.btnStepForward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStepForward.Name = "btnStepForward";
            this.btnStepForward.Size = new System.Drawing.Size(104, 27);
            this.btnStepForward.TabIndex = 13;
            this.btnStepForward.Text = "Step Forward";
            this.btnStepForward.UseVisualStyleBackColor = true;
            this.btnStepForward.Click += new System.EventHandler(this.btnStepForward_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(679, 708);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(199, 16);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://yinyangit.wordpress.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 91);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(869, 613);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radInfix2Prefix);
            this.tabPage1.Controls.Add(this.txtFinalExpression);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnStepForward);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnStartPause);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.btnExport);
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.radInfix2Postfix);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(861, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Expression Converter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bsTreePanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(861, 584);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Expression Tree";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.Location = new System.Drawing.Point(840, 20);
            this.btnGo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(35, 25);
            this.btnGo.TabIndex = 17;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(124, 59);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(16, 16);
            this.lblResult.TabIndex = 18;
            this.lblResult.Text = "_";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Result:";
            // 
            // bsTreePanel1
            // 
            this.bsTreePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bsTreePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bsTreePanel1.InfixExpression = null;
            this.bsTreePanel1.Location = new System.Drawing.Point(10, 7);
            this.bsTreePanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bsTreePanel1.Name = "bsTreePanel1";
            this.bsTreePanel1.Size = new System.Drawing.Size(842, 598);
            this.bsTreePanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 727);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInfixExpression);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Y2 Expression Converter Demo 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfixExpression;
        private System.Windows.Forms.Button btnStartPause;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.FlowLayoutPanel pnlExpression;
        private System.Windows.Forms.FlowLayoutPanel pnlStack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel pnlOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFinalExpression;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radInfix2Prefix;
        private System.Windows.Forms.RadioButton radInfix2Postfix;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnStepForward;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private WindowsFormsApplication2.BSTreePanel bsTreePanel1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label8;
    }
}

