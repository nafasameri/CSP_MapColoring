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
    public partial class DomainsForm : Form
    {
        object[] obj = new object[]
        {
            Color.MidnightBlue,
            Color.IndianRed,
            Color.Bisque,
            Color.Violet,
            Color.Tomato,
            Color.MediumVioletRed,
            Color.DarkKhaki,
            Color.Lime,
            Color.PaleGreen,
            Color.PaleTurquoise,
            Color.Khaki,
            Color.DeepPink,
            Color.Gold,
            Color.Olive,
            Color.Crimson
        };

        public DomainsForm()
        {
            InitializeComponent();
        }

        public void retItems(ref ArrayList list)
        {
            for (int i = 0; i < obj.Length; i++)
                if (clbDomains.GetItemCheckState(i) == CheckState.Checked)
                    list.Add((Color)clbDomains.Items[i]);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Domains_Load(object sender, EventArgs e)
        {
            clbDomains.Items.Clear();
            clbDomains.Items.AddRange(obj);
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            int t = 0;
            for (int i = 0; i < obj.Length; i++)
            {
                g.FillEllipse(new SolidBrush((Color)obj[i]), 5, (t++ * 20) + 4, 20, 20);
                clbDomains.SetItemCheckState(i, CheckState.Checked);
            }
        }
    }
}
