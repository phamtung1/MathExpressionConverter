using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y2_Expression_Converter;
using System.IO;
using System.Diagnostics;

namespace Y2_Expression_Converter_Demo
{
    public partial class Form1 : Form
    {
        Image _imgHightLight = Properties.Resources.highlightCircle;
        Image _imgNormal = Properties.Resources.NormalCircle;

        const int CONTROL_SIZE = 30;
        bool _isInProcess = false;
        bool _isInfix2Prefix = false;       
        Control _preCtl, _nextCtl;

        public Form1()
        {
            InitializeComponent();

            this.Text = Application.ProductName + " " + Application.ProductVersion;

        }

        private void btnStartPause_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtInfixExpression.Text.Trim()))
                return;

            if (!timer1.Enabled)
            {
                if (!_isInProcess)
                {
                    string infix = txtInfixExpression.Text;
                    infix = ExprHelper.FormatExpression(infix);

                    IEnumerable<string> tokens;
                    //if (_isInfix2Prefix)
                    //{
                    //    infix = infix.Replace("(", "#");
                    //    infix = infix.Replace(")", "(");
                    //    infix = infix.Replace("#", ")");

                    //    tokens = infix.Split(' ').Reverse();

                    //}
                    //else
                        tokens = infix.Split(' ');

                    foreach (string s in tokens)
                    {
                        Label lbl = new Label();
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Text = s;
                        lbl.BackgroundImageLayout = ImageLayout.Stretch;
                        lbl.BackgroundImage = Properties.Resources.NormalCircle;

                        lbl.Width = CONTROL_SIZE;
                        lbl.Height = CONTROL_SIZE;

                        pnlExpression.Controls.Add(lbl);
                    }
                    listView1.Items.Clear();
                    txtFinalExpression.Clear();

                }
                btnStartPause.Text = "Pause";
                timer1.Interval = (int)numericUpDown1.Value;
            }
            else
            {
                if (_isInProcess)
                    btnStartPause.Text = "Resume";
                else
                    btnStartPause.Text = "Start";
            }
            _isInProcess = true;
            timer1.Enabled = !timer1.Enabled;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!_isInProcess)
                return;
            pnlExpression.Controls.Clear();
            pnlOutput.Controls.Clear();
            pnlStack.Controls.Clear();


            btnStartPause.Text = "Start";
            _isInProcess = false;
            timer1.Stop();
            btnExport.Enabled = true;

        }

        private void ProcessPostfix(Control ctl)
        {
            if (ExprHelper.IsOperator(ctl.Text))
            {

                if (_preCtl != null && ExprHelper.IsOperator(_preCtl.Text))
                {
                    if (ctl.Text == "-")
                    {
                        _nextCtl.Text = ctl.Text + _nextCtl.Text;
                        Output(_nextCtl);
                    }
                    else if (ExprHelper.IsUnaryFunction(ctl.Text))
                    {
                        PushStack(ctl);
                    }
                }
                else
                {
                    while (pnlStack.Controls.Count > 0 &&
                        ExprHelper.GetPriority(ctl.Text) <= ExprHelper.GetPriority(PeekStack().Text))
                        Output(PopStack());
                    PushStack(ctl);
                }
            }

            else if (ctl.Text == "(")
                PushStack(ctl);
            else if (ctl.Text == ")")
            {
                Control x = PopStack();
                while (x.Text != "(")
                {
                    Output(x);
                    x = PopStack();
                }
            }
            else // IsOperand
            {
                Output(ctl);
            }

        }

        Control PeekStack()
        {
            return pnlStack.Controls[pnlStack.Controls.Count - 1];
        }
        Control PopStack()
        {
            Control ctl = pnlStack.Controls[pnlStack.Controls.Count - 1];
            pnlStack.Controls.Remove(ctl);

            return ctl;
        }
        void PushStack(Control ctl)
        {
            pnlStack.Controls.Add(ctl);

            if (pnlStack.Controls.Count > 1)
                pnlStack.Controls[pnlStack.Controls.Count - 2].BackgroundImage = _imgNormal;
        }
        void Output(Control ctl)
        {
            pnlOutput.Controls.Add(ctl);

            if (pnlOutput.Controls.Count > 1)
                pnlOutput.Controls[pnlOutput.Controls.Count - 2].BackgroundImage = _imgNormal;
        }

        void AddToListView(Control ctl)
        {
            string s = String.Empty;
            if (ctl != null)
                s = ctl.Text;
            ListViewItem item = listView1.Items.Add(s);
            StringBuilder str = new StringBuilder();

            // stack
            foreach (Control c in pnlStack.Controls)
                str.Append(c.Text).Append(" ");

            s = str.ToString().Trim();
            if (s == String.Empty)
                s = "{Empty}";

            item.SubItems.Add(s);

            // output
            str = new StringBuilder();
            foreach (Control c in pnlOutput.Controls)
                str.Append(c.Text).Append(" ");

            s = str.ToString().Trim();
            if (s == String.Empty)
                s = "{Empty}";
            item.SubItems.Add(s);

            if (listView1.Items.Count > 1)
                listView1.Items[listView1.Items.Count - 2].Selected = false;

            item.Selected = true;

            listView1.TopItem = item;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            StepForward();
        }

        private void radInfix2Prefix_CheckedChanged(object sender, EventArgs e)
        {
            // Ko cho phép đổi nếu đang In Process
            if (!_isInProcess)
                _isInfix2Prefix = radInfix2Prefix.Checked;

            radInfix2Prefix.Checked = _isInfix2Prefix;
            radInfix2Postfix.Checked = !_isInfix2Prefix;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "HTML (*.html)|*.html";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StringBuilder str = new StringBuilder("<html><head><title>");
                str.Append(Application.ProductName).Append(" ").Append(Application.ProductVersion);
                str.AppendLine("</title></head><body>");
                str.AppendLine("<table border=\"1\">");
                str.AppendLine("<tr>");
                str.AppendLine("<th>Token</th>");
                str.AppendLine("<th>Stack</th>");
                str.AppendLine("<th>Output</th>");
                str.AppendLine("</tr>");

                foreach (ListViewItem item in listView1.Items)
                {
                    str.AppendLine("<tr>");
                    str.Append("<td>").Append(item.Text).AppendLine("</td>");
                    str.Append("<td>").Append(item.SubItems[1].Text).AppendLine("</td>");
                    str.Append("<td>").Append(item.SubItems[2].Text).AppendLine("</td>");
                    str.AppendLine("</tr>");
                }
                str.AppendLine("</table>");
                str.AppendLine("</body></html>");

                try
                {
                    StreamWriter writer = new StreamWriter(dlg.FileName);

                    writer.Write(str.ToString());
                    //writer.Flush();
                    writer.Close();
                    writer.Dispose();

                    if (DialogResult.Yes ==
                        MessageBox.Show(
                        @"The file was exported successfully.
Do you want to open the file now?", "Exported Successfully!",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {

                        Process.Start(dlg.FileName);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnStepForward_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                btnStartPause_Click(null, null);
                btnStartPause.Text = "Resume";
                timer1.Stop();
                StepForward();
            }

        }

        private void StepForward()
        {
            try
            {
                if (pnlExpression.Controls.Count > 0)
                {
                    Control ctl = pnlExpression.Controls[0];
                    ctl.BackgroundImage = _imgHightLight;

                    pnlExpression.Controls.Remove(ctl);

                    if (pnlExpression.Controls.Count > 0)
                        _nextCtl = pnlExpression.Controls[0];

                    ProcessPostfix(ctl);

                    AddToListView(ctl);

                    _preCtl = ctl;
                }
                else if (pnlStack.Controls.Count > 0)
                {
                    Control ctl = PopStack();
                    Output(ctl);

                    // last 
                    if (pnlExpression.Controls.Count == 0 && pnlStack.Controls.Count == 0)
                        AddToListView(null);
                }
                else if (pnlOutput.Controls.Count > 0) // final expression
                {
                    int index = 0;
                    if (_isInfix2Prefix)
                        index = pnlOutput.Controls.Count - 1;

                    if (pnlOutput.Controls.Count > 1)
                        pnlOutput.Controls[pnlOutput.Controls.Count - 1].BackgroundImage = _imgHightLight;

                    Control ctl = pnlOutput.Controls[index];

                    txtFinalExpression.Text += ctl.Text + " ";
                    pnlOutput.Controls.Remove(ctl);

                    ctl.Dispose();
                }
                else
                {
                    btnReset_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(linkLabel1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string str = ExprHelper.FormatExpression(txtInfixExpression.Text);
            txtInfixExpression.Text=str.Replace(" ","");
            bsTreePanel1.InfixExpression = txtInfixExpression.Text;
            if (tabControl1.SelectedIndex == 0)
                btnStartPause_Click(null, null);
            Console.WriteLine(Y2Expression.Infix2Prefix(txtInfixExpression.Text));

            try
            {
                if(_isInfix2Prefix)
                    lblResult.Text = Y2Expression.EvaluatePrefix(Y2Expression.Infix2Prefix(txtInfixExpression.Text)).ToString();
                else
                    lblResult.Text = Y2Expression.EvaluatePostfix(Y2Expression.Infix2Postfix(txtInfixExpression.Text)).ToString();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                btnGo_Click(null, null);

        }


    }
}
