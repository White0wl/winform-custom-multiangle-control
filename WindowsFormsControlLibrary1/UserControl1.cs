using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary1
{
    public partial class UserControl1 : Button
    {
        int sides;
        int radius;

        Point center;
        List<Point> points;

        Color fillColor;
        Color borderColor;
        float angle;


        bool showRadius;
        public bool ShowRadius { get { return showRadius; } set { showRadius = value; Invalidate(); } }

        private bool showBorder;
        public bool ShowBorder { get { return showBorder; } set { showBorder = value; Invalidate(); } }

        private bool showFill;
        public bool ShowFill { get { return showFill; } set { showFill = value; Invalidate(); } }


        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; Invalidate(); }
        }


        public int Sides
        {
            get { return sides; }
            set { sides = value; Invalidate(); }
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        public float Angle
        {
            get { return angle; }
            set { angle = value; Invalidate(); }
        }

        public UserControl1()
        {
            InitializeComponent();
            sides = 3;
            radius = 5;
            fillColor = Color.Black;
            borderColor = Color.Black;
            angle = 0;
            Invalidate();
        }

        private void lineAngle(double angle)
        {
            double z = 0; int i = 0;
            while (i < sides + 1)
            {
                int x = /*center.X + */(int)(Math.Round(Math.Cos(z / 180 * Math.PI) * radius));
                int y = /*center.Y - */(int)(Math.Round(Math.Sin(z / 180 * Math.PI) * radius));
                points.Add(new Point(x, y));
                z = z + angle;
                i++;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.FromArgb(192, 255, 255)), ClientRectangle);
            center.X = ClientRectangle.Width / 2;
            center.Y = ClientRectangle.Height / 2;

            g.TranslateTransform(center.X, center.Y);

            if (sides < 3) sides = 3;
            if (radius < 1) radius = 5;

            points = new List<Point>(sides + 1);
            lineAngle((double)(360.0 / (double)sides));

            GraphicsPath gp = new GraphicsPath();

            g.RotateTransform(Angle);
            gp.AddLines(points.ToArray());

            if (ShowFill) g.FillPath(new SolidBrush(fillColor), gp);
            if (ShowRadius) g.DrawEllipse(Pens.Gray, new RectangleF(-radius, -radius, radius * 2, radius * 2));
            if (ShowBorder) g.DrawPath(new Pen(borderColor), gp);


            //int i = sides;
            //while (i > 0)
            //{
            //    g.DrawLine(new Pen(Color.Black, 2), points[i], points[i - 1]);
            //    i = i - 1;
            //}


        }
    }
}
