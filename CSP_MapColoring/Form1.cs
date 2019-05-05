using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSP_MapColoring
{
    public partial class Main : Form
    {
        private int NumOfVertices;
        Dictionary<int, Point> Vertices = new Dictionary<int, Point>();
        bool[,] State;
        Graphics g;
        
        public Main()
        {
            InitializeComponent();
            SetLocationVertices();
            State = new bool[NumOfVertices, NumOfVertices];
            for (int i = 0; i < NumOfVertices; i++)
                for (int j = 0; j < NumOfVertices; j++)
                    State[i, j] = false;
        }

        #region Drag And Drop
        private bool draging = false;
        private Point dragingPoint;
        private int dragingPointIndex;
        private void mouseDown(object sender, MouseEventArgs e)
        {
            foreach (var p in Vertices)
            {
                if (p.Value.X + 10 >= e.X && p.Value.X - 10 <= e.X)
                {
                    if (p.Value.Y + 10 >= e.Y && p.Value.Y - 10 <= e.Y)
                    {
                        Cursor = Cursors.SizeAll;
                        draging = true;
                        dragingPointIndex = p.Key;
                        return;
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            draging = false;
            Cursor = Cursors.Default;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (draging)
            {
                dragingPoint = Vertices[dragingPointIndex];
                dragingPoint.X = e.X;
                dragingPoint.Y = e.Y;
                Vertices[dragingPointIndex] = dragingPoint;
                Draw(Color.AliceBlue);
            }
        }
        #endregion

        private void SetLocationVertices()
        {
            Point[] points = new Point[15];
            points[0] = new Point(380, 30);
            points[1] = new Point(180, 30);
            points[2] = new Point(50, 180);
            points[3] = new Point(50, 330);
            points[4] = new Point(180, 460);
            points[5] = new Point(380, 460);
            points[6] = new Point(510, 330);
            points[7] = new Point(510, 180);
            points[8] = new Point(280, 90);
            points[9] = new Point(150, 150);
            points[10] = new Point(400, 150);
            points[11] = new Point(150, 350);
            points[12] = new Point(400, 350);
            points[13] = new Point(280, 420);
            points[14] = new Point(280, 255);

            /// Creat Vertices      
            for (int i = 0; i < NumOfVertices; i++)
                try { Vertices.Add(i, points[i]); } catch { }
        }

        private void Draw(Color color)
        {
            g = pnlResult.CreateGraphics();
            g.Clear(pnlResult.BackColor);

            /// set weight edge in desgin
            for (int i = 0; i < NumOfVertices; i++)
                for (int j = 0; j < NumOfVertices; j++)
                    if (State[i, j])
                        g.DrawLine(new Pen(Color.DarkOrchid), Vertices[i], Vertices[j]);
            /// draw nodes and indexs
            foreach (var item in Vertices)
            {
                g.FillEllipse(new SolidBrush(color), item.Value.X - 10, item.Value.Y - 10, 20, 20);
                g.DrawString(item.Key.ToString(), new Font(FontFamily.GenericSansSerif, 15), new SolidBrush(Color.DarkViolet), item.Value);
            }
        }

        #region Controls
        private void btnDomains_Click(object sender, EventArgs e)
        {
            Domains frmDomains = new Domains();
            frmDomains.Show();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int.TryParse(txtNumOfVertices.Text, out NumOfVertices);
            for (int i = 0; i < NumOfVertices; i++)
            {
                cmbFromVertices.Items.AddRange(new object[] { i });
                cmbToVertices.Items.AddRange(new object[] { i });
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want exit this program?", "Exit!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
                Application.Exit();
        }
        #endregion
    }
}
