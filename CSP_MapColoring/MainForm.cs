using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CSP_MapColoring
{
    public partial class MainForm : Form
    {
        private int NumOfVertices;
        private string log;
        private bool[,] State;
        Graphics g;
        DomainsForm frmDomains;
        Dictionary<int, Node> Graph = new Dictionary<int, Node>();
        Dictionary<int, List<int>> Neighbors = new Dictionary<int, List<int>>();
        List<Color> colors = new List<Color>();
        BackTracking BT = new BackTracking();
        Heuristic heuristic = new Heuristic();
        Random random = new Random();
        DateTime start = new DateTime();
        DateTime finish = new DateTime();


        #region Method's
        public MainForm()
        {
            InitializeComponent();
            //Analysis();
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

        private void Begin()
        {
            log = string.Empty;
            rtbLog.Text = "Begin Of Solving CSP.\r\n";
            for (int i = 0; i < NumOfVertices; i++)
                State[i, i] = false;
            if (Neighbors.Count == 0) Neighbor();
            for (int i = 0; i < NumOfVertices; i++)
                Graph[i].Neighbors = Neighbors[i];
            BT.Graph = heuristic.Graph = Graph;
            BT.heuristic = heuristic;
        }

        private void End()
        {
            rtbLog.Text += log;
            for (int i = 0; i < NumOfVertices; i++)
                Graph[i].color = BT.ColoredMap[i];
            Draw(pnlResult);
            rtbLog.Text += "End Of Solving CSP.\r\n";
            //if (colors.Count < Vertices.Count){rtbLog.Text = "CSP not be Solve!";return;}else
        }

        private void Analysis()
        {
            #region Defintion
            int len = 20;
            string path = @"E:\New folder\20 LCV FC.txt";
            object[,] dateTimes = new object[len, (len * (len - 1)) / 2];
            Dictionary<int, Node> graph = new Dictionary<int, Node>();
            BackTracking backTracking = new BackTracking();
            Heuristic _heuristic = new Heuristic();
            colors.Add(Color.MidnightBlue);
            colors.Add(Color.IndianRed);
            colors.Add(Color.Bisque);
            colors.Add(Color.Violet);
            colors.Add(Color.Tomato);
            colors.Add(Color.MediumVioletRed);
            colors.Add(Color.DarkKhaki);
            colors.Add(Color.Lime);
            colors.Add(Color.PaleGreen);
            colors.Add(Color.PaleTurquoise);
            colors.Add(Color.Khaki);
            colors.Add(Color.DeepPink);
            colors.Add(Color.Gold);
            colors.Add(Color.Olive);
            colors.Add(Color.Crimson);
            colors.Add(Color.Linen);
            colors.Add(Color.AntiqueWhite);
            colors.Add(Color.Azure);
            colors.Add(Color.Blue);
            colors.Add(Color.Cornsilk);

            State = new bool[len, len];
            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                    State[i, j] = false;
            #endregion

            DateTime time = DateTime.Now;
            for (int i = 0; i < len; i++)
            {
                graph.Add(i, new Node(i, Color.Snow, colors));

                for (int j = 0; j < (i * (i - 1)) / 2; j++) 
                {
                    int row = random.Next(0, i);
                    int col = random.Next(0, i);
                    State[row, col] = State[col, row] = true;
                    for (int k = 0; k < len; k++)
                        State[k, k] = false;

                    Neighbors.Clear();
                    for (int k = 0; k < len; k++)
                    {
                        List<int> temp = new List<int>();
                        for (int l = 0; l < len; l++)
                            if (State[k, l])
                                temp.Add(l);
                        Neighbors.Add(k, temp);
                    }
                    for (int k = 0; k < i; k++)
                        graph[k].Neighbors = Neighbors[k];

                    backTracking.Graph = _heuristic.Graph = graph;
                    backTracking.heuristic = _heuristic;

                    start = DateTime.Now;
                    backTracking.BT(colors, true, false, true, ref log);
                    finish = DateTime.Now;
                    dateTimes[i, j] = (finish - start);
                }
            }
            DateTime time2 = DateTime.Now;

            #region write the file
            File.WriteAllText(path, (time2 - time).ToString() + "\r\n\t");
            for (int i = 0; i < len; i++)
                File.AppendAllText(path, i.ToString() + "\t\t\t");
            for (int j = 0; j < (len * (len - 1)) / 2; j++)
            {
                File.AppendAllText(path, "\r\n" + j.ToString());
                for (int i = 0; i < len; i++)
                    if (dateTimes[i, j] != null)
                        File.AppendAllText(path, "\t\t" + dateTimes[i, j].ToString());
                    else
                        File.AppendAllText(path, "\t\t00:00:00");
            }
            #endregion
        }
        #endregion

        #region Drag And Drop
        private bool draging = false;
        private Point dragingPoint;
        private int dragingPointIndex;
        private void mouseDown(object sender, MouseEventArgs e)
        {
            foreach (var p in Graph)
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
                dragingPoint = Graph[dragingPointIndex].point;
                dragingPoint.X = e.X;
                dragingPoint.Y = e.Y;
                Graph[dragingPointIndex].point = dragingPoint;
                Draw(pnlResult);
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

        private void Draw(Control elm)
        {
            g = elm.CreateGraphics();
            g.Clear(elm.BackColor);

            /// set weight edge in desgin
            for (int i = 0; i < NumOfVertices; i++)
                for (int j = 0; j < NumOfVertices; j++)
                    if (State[i, j])
                        g.DrawLine(new Pen(Color.DarkOrchid), Graph[i].point, Graph[j].point);
            /// draw nodes and indexs
            foreach (var item in Graph)
            {
                g.FillEllipse(new SolidBrush(item.Value.color), item.Value.point.X - 10, item.Value.point.Y - 10, 20, 20);
                g.DrawString(item.Key.ToString(), this.Font, new SolidBrush(Color.Black), new Point(item.Value.point.X - 10, item.Value.point.Y - 10));
            }
        }

        private void Draw_(Color color, Node Vertice)
        {
            g.FillEllipse(new SolidBrush(color), Vertice.point.X - 10, Vertice.point.Y - 10, 20, 20);
            g.DrawString(Vertice.Name.ToString(), new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.DarkViolet), new Point(Vertice.point.X - 10, Vertice.point.Y - 10));
        }
        #endregion

        #region Controls
        private void btnDomains_Click(object sender, EventArgs e)
        {
            frmDomains = new DomainsForm();
            frmDomains.Show();
            frmDomains.FormClosing += FrmDomains_FormClosing;
        }

        private void FrmDomains_FormClosing(object sender, FormClosingEventArgs e)
        {
            colors = frmDomains.retItems();
            foreach (var item in Graph)
            {
                item.Value.domain.Clear();
                item.Value.domain.AddRange(colors);
            }
            //MessageBox.Show("Successfully saved colors.", "Saved colors...", MessageBoxButtons.OK);
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
                Graph.Add(i, new Node(i, Color.Snow, new List<Color>()));
                if (i < points.Length) Graph[i].point = points[i];
                else if (i < 40) Graph[i].point = new Point(i, (i - points.Length) * 20);
                else if (i < 70) Graph[i].point = new Point(i + 20, (i - 40) * 20);
                else Graph[i].point = new Point(i + 20, (i - 70) * 20);
            }
            grbNumOfVertices.Enabled = false;
            grbEdges.Enabled = grbSelectVar_Val.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want exit this program?", "Exit!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void btnOKEdge_Click(object sender, EventArgs e)
        {
            try
            {
                if (State[cmbFromVertices.SelectedIndex, cmbToVertices.SelectedIndex])
                    State[cmbFromVertices.SelectedIndex, cmbToVertices.SelectedIndex] = State[cmbToVertices.SelectedIndex, cmbFromVertices.SelectedIndex] = false;
                else
                    State[cmbFromVertices.SelectedIndex, cmbToVertices.SelectedIndex] = State[cmbToVertices.SelectedIndex, cmbFromVertices.SelectedIndex] = true;
            }
            catch { }
            grbNumOfVertices.Enabled = false;
            Draw(pnlProblem);
        }

        private void clbVar_Val_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbVar_Val.GetItemCheckState(0) == CheckState.Checked || clbVar_Val.GetItemCheckState(1) == CheckState.Checked)
            {
                clbVar_Val.SetItemCheckState(1, CheckState.Checked);
                clbVar_Val.SetItemCheckState(0, CheckState.Checked);
            }
            if (clbVar_Val.GetItemCheckState(0) == CheckState.Unchecked || clbVar_Val.GetItemCheckState(1) == CheckState.Unchecked)
            {
                clbVar_Val.SetItemCheckState(1, CheckState.Unchecked);
                clbVar_Val.SetItemCheckState(0, CheckState.Unchecked);
            }
        }

        private void btnForwardChecking_Click(object sender, EventArgs e)
        {
            Begin();
            //if (clbVar_Val.GetItemChecked(0) && clbVar_Val.GetItemChecked(1) && clbVar_Val.GetItemChecked(2))
            //    BT.BT(colors, true, true, true, ref log);
            //else
            //{
            //    if (clbVar_Val.GetItemChecked(0) && clbVar_Val.GetItemChecked(1)) BT.BT(colors, false, true, true, ref log);
            //    else if (clbVar_Val.GetItemChecked(2)) BT.BT(colors, true, false, true, ref log);
            //    else BT.BT(colors, false, false, true, ref log);
            //}
            start = DateTime.Now;
            BT.BT(colors, clbVar_Val.GetItemChecked(2), clbVar_Val.GetItemChecked(1), true, ref log);
            finish = DateTime.Now;
            End();
            log += (finish - start).Milliseconds.ToString();
        }

        private void btnBackTracking_Click(object sender, EventArgs e)
        {
            Begin();
            start = DateTime.Now;
            BT.BT(colors, clbVar_Val.GetItemChecked(2), clbVar_Val.GetItemChecked(1), false, ref log);
            finish = DateTime.Now;
            End();
            log += (finish - start).Milliseconds.ToString();
        }

        private void btnRandomGenerateGraph_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < NumOfVertices; i++)
            {
                int row = random.Next(0, NumOfVertices);
                int col = random.Next(0, NumOfVertices);
                State[row, col] = State[col, row] = true;
            }
            Draw(pnlProblem);
        }
        #endregion
    }
}