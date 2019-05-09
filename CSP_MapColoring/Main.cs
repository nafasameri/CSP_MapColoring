using System;
using System.Collections;
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
        Dictionary<int, Node> Vertices = new Dictionary<int, Node>();
        bool[,] State;
        Graphics g;
        ArrayList colors = new ArrayList();
        Domains frmDomains = new Domains();
        Dictionary<int, List<int>> Neighbors = new Dictionary<int, List<int>>();

        #region Method's
        public Main()
        {
            InitializeComponent();
        }

        private void Neighbor()
        {
            for (int i = 0; i < NumOfVertices; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < NumOfVertices; j++)
                    if (State[i, j])
                        temp.Add(j);
                Neighbors.Add(i, temp);
            }
        }
        #endregion

        #region Drag And Drop
        private bool draging = false;
        private Point dragingPoint;
        private int dragingPointIndex;
        private void mouseDown(object sender, MouseEventArgs e)
        {
            foreach (var p in Vertices)
            {
                if (p.Value.point.X + 10 >= e.X && p.Value.point.X - 10 <= e.X)
                {
                    if (p.Value.point.Y + 10 >= e.Y && p.Value.point.Y - 10 <= e.Y)
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
                dragingPoint = Vertices[dragingPointIndex].point;
                dragingPoint.X = e.X;
                dragingPoint.Y = e.Y;
                Vertices[dragingPointIndex].point = dragingPoint;
                Draw();
            }
        }
        #endregion

        #region Draw
        private Point[] SetLocationVertices()
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
            return points;
        }

        private void Draw()
        {
            g = pnlResult.CreateGraphics();
            g.Clear(pnlResult.BackColor);

            /// set weight edge in desgin
            for (int i = 0; i < NumOfVertices; i++)
                for (int j = 0; j < NumOfVertices; j++)
                    if (State[i, j])
                        g.DrawLine(new Pen(Color.DarkOrchid), Vertices[i].point, Vertices[j].point);
            /// draw nodes and indexs
            foreach (var item in Vertices)
            {
                g.FillEllipse(new SolidBrush(item.Value.color), item.Value.point.X - 10, item.Value.point.Y - 10, 20, 20);
                g.DrawString(item.Key.ToString(), this.Font, new SolidBrush(Color.Black), new Point(item.Value.point.X - 10, item.Value.point.Y - 10));
            }
        }

        private void Draw_(Color color, Node Vertice)
        {
            g.FillEllipse(new SolidBrush(color), Vertice.point.X - 10, Vertice.point.Y - 10, 20, 20);
            g.DrawString(Vertice.Name, new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.DarkViolet), new Point(Vertice.point.X - 10, Vertice.point.Y - 10));
        }
        #endregion

        #region Controls
        private void btnDomains_Click(object sender, EventArgs e)
        {
            frmDomains.Show();
            frmDomains.FormClosing += FrmDomains_FormClosing;
        }

        private void FrmDomains_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDomains.retItems(ref colors);
            foreach (var item in Vertices)
                item.Value.domain = colors;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int.TryParse(txtNumOfVertices.Text, out NumOfVertices);
            Point[] points = SetLocationVertices();
            State = new bool[NumOfVertices, NumOfVertices];
            for (int i = 0; i < NumOfVertices; i++)
                for (int j = 0; j < NumOfVertices; j++)
                    State[i, j] = false;
            for (int i = 0; i < NumOfVertices; i++)
            {
                cmbFromVertices.Items.AddRange(new object[] { i });
                cmbToVertices.Items.AddRange(new object[] { i });
                Vertices.Add(i, new Node());
                Vertices[i].Name = i.ToString();
                Vertices[i].point = points[i];
                Vertices[i].color = Color.Snow;
            }
            grbNumOfVertices.Enabled = false;
            grbEdges.Enabled = true;
            grbSelectVar_Val.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want exit this program?", "Exit!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void btnOKEdge_Click(object sender, EventArgs e)
        {
            State[cmbFromVertices.SelectedIndex, cmbToVertices.SelectedIndex] = State[cmbToVertices.SelectedIndex, cmbFromVertices.SelectedIndex] = true;
            grbNumOfVertices.Enabled = false;
            grbEdges.Enabled = true;
            grbSelectVar_Val.Enabled = true;
        }

        private void btnForwardChecking_Click(object sender, EventArgs e)
        {
            if (clbVar_Val.GetItemChecked(0) && clbVar_Val.GetItemChecked(1) && clbVar_Val.GetItemChecked(2))
            {
                rtbLog.Text += "Begin Of Solving CSP.\r\n";
                Neighbor();
                Heuristic.Graph = Vertices;

                for (int i = 0; i < NumOfVertices; i++)
                    Vertices[i].Neighbors = Neighbors[i];
                string log = string.Empty;
                Heuristic.Color(colors, ref log);

                rtbLog.Text += log;
                for (int i = 0; i < NumOfVertices; i++)
                    Vertices[i].color = (Color)Heuristic.ColoredMap[i];
                Draw();

                //if (colors.Count < Vertices.Count){rtbLog.Text = "CSP not be Solve!";return;}else
                rtbLog.Text += "End Of Solving CSP.\r\n";
            }
            //if (clbVar_Val.GetItemChecked(0)) Heuristics.MRV();
            //if (clbVar_Val.GetItemChecked(1)) Heuristics.MostDegree();
            //if (clbVar_Val.GetItemChecked(2)) Heuristics.LCV();
        }
        #endregion
    }
}
