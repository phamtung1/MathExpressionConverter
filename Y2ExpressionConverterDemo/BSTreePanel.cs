using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Text.RegularExpressions;
using Y2_Expression_Converter;

namespace WindowsFormsApplication2
{
    partial class BSTreePanel : UserControl
    {
        #region Properties

        const int RADIUS = 25;
        const int DIAMETER = RADIUS * 2;        
        const int VER_DISTANCE = 100;

        Pen _pen;
        LinearGradientBrush _circleBrush;
        LinearGradientBrush _squareBrush;

        Font _font;

        private BinaryTreeNode _root;

        private string _infixExpression;

        public string InfixExpression
        {
            get { return _infixExpression; }
            set
            {
                _infixExpression = value;
                try
                {
                    if (String.IsNullOrEmpty(_infixExpression))
                        _root = null;
                    else
                    {                        
                        _root = Y2Expression.Infix2ExpressionTree(_infixExpression);

                        //MessageBox.Show(Y2Expression.EvaluateExpressionTree(_root).ToString());
                    }

                    BeginDraw();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
        }

        float _leftRoot;
        float _minLeft;
        float _maxLeft;
        int _nodeCount;


        public Image Image
        {
            get { return pictureBox1.Image; }
        }

        Graphics _g;
        #endregion

        public BSTreePanel()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
            _circleBrush = new LinearGradientBrush(new Rectangle(0, 0, 100, VER_DISTANCE),
Color.LightSkyBlue, Color.White, LinearGradientMode.Vertical);
            _circleBrush.SetBlendTriangularShape(.3f);
            _squareBrush = new LinearGradientBrush(new Rectangle(0, 0, 100, VER_DISTANCE),
        Color.LightCoral, Color.White, LinearGradientMode.Vertical);
            _squareBrush.SetBlendTriangularShape(.3f);
            _pen = new Pen(Color.DarkBlue, 2);
            _font = new Font("Arial", 18);


        }

        private void BSTreePanel_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
        
        private void BeginDraw()
        {                      
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            if (_root == null)
                return;

            _nodeCount = 0;
            _minLeft = 0;
            _maxLeft = 0;
            int horDistance=300;
            CalculateSize(PointF.Empty, _root, horDistance);
            if (_nodeCount < 12)
                horDistance = _nodeCount * 30;
            int width = (int)(_maxLeft - _minLeft)+DIAMETER*2;
            _leftRoot =  -1*_minLeft+DIAMETER;           

            Image img = new Bitmap(width,(GetHeight(_root)+1)*VER_DISTANCE);

            if (_g != null)
            {
                _g.Dispose();                
            }    

            pictureBox1.Image = img;
            _g = Graphics.FromImage(pictureBox1.Image);
              
            _g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawTreeNode(_g, new PointF(_leftRoot, VER_DISTANCE), _root, horDistance);
        }

        private int GetHeight(BinaryTreeNode node)
        {
            if (node == null)
                return 0;
            else
                return 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));
        }
        private void CalculateSize(PointF p, BinaryTreeNode node, int horizontalDistance)
        {
            _nodeCount++;
            if (horizontalDistance > DIAMETER)
                horizontalDistance -= DIAMETER;
            if (node != null)
            {
                float left = p.X - RADIUS;
                float top = p.Y - RADIUS;

                if (node.LeftChild != null)
                {
                    PointF p1 = p;

                    p1.X -= horizontalDistance;
                    p1.Y += VER_DISTANCE;

                    if (p1.X < _minLeft)
                        _minLeft = p1.X;
                    if (p1.X > _maxLeft)
                        _maxLeft= p1.X;   

                    CalculateSize(p1, node.LeftChild, horizontalDistance);                   
                }
                if (node.RightChild != null)
                {
                    PointF p1 = p;

                    p1.X += horizontalDistance;
                    p1.Y += VER_DISTANCE;

                    if (p1.X < _minLeft)
                        _minLeft = p1.X;
                    if (p1.X > _maxLeft)
                        _maxLeft = p1.X;   

                    CalculateSize(p1, node.RightChild, horizontalDistance);

                    
                }
            }
        }

        private void DrawTreeNode(Graphics g, PointF p, BinaryTreeNode node, int horizontalDistance)
        {
            if (horizontalDistance > DIAMETER)
                horizontalDistance -= DIAMETER;
            if (node != null)
            {
                float left = p.X - RADIUS;
                float top = p.Y - RADIUS;

                if (node.LeftChild != null)
                {
                    PointF p1 = p;
                    PointF p2 = p;

                    p2.X -= horizontalDistance;

                    p2.Y += VER_DISTANCE;

                    g.DrawLine(_pen, p1, p2);

                    DrawTreeNode(g, p2, node.LeftChild, horizontalDistance);

                    if (p2.X < _minLeft)
                        _minLeft = p2.X;
                    if (p2.X > _maxLeft)
                        _maxLeft = p2.X;
                }
                if (node.RightChild != null)
                {
                    PointF p1 = p;
                    PointF p2 = p;

                    p2.X += horizontalDistance;

                    p2.Y += VER_DISTANCE;

                    g.DrawLine(_pen, p1, p2);

                    DrawTreeNode(g, p2, node.RightChild, horizontalDistance);

                    if (p2.X < _minLeft)
                        _minLeft = p2.X;
                    if (p2.X > _maxLeft)
                        _maxLeft = p2.X;
                }
                if (node.IsLeaf)
                {
                    g.FillRectangle(_squareBrush, left, top, DIAMETER, DIAMETER);
                    g.DrawRectangle(_pen, left, top, DIAMETER, DIAMETER);
                }
                else
                {
                    g.FillEllipse(_circleBrush, left, top, DIAMETER, DIAMETER);
                    g.DrawEllipse(_pen, left, top, DIAMETER, DIAMETER);
                }
                string text = node.Value.ToString();
                SizeF size = g.MeasureString(text, _font);

                g.DrawString(text, _font, Brushes.Black, left + RADIUS-size.Width/2, top + RADIUS-size.Height/2);

            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Dock == DockStyle.Fill)
                pictureBox1.Dock = DockStyle.None;

            pictureBox1.Width = (int)(pictureBox1.Width * 1.5);
            pictureBox1.Height = (int)(pictureBox1.Height * 1.5);

        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Dock == DockStyle.Fill)
                pictureBox1.Dock = DockStyle.None;

            pictureBox1.Width = (int)(pictureBox1.Width / 1.5);
            pictureBox1.Height = (int)(pictureBox1.Height / 1.5);

        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Size = pictureBox1.Parent.Size;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            showAllToolStripMenuItem.Checked = pictureBox1.Dock == DockStyle.Fill;
        }




    }
}

