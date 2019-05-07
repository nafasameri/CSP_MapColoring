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
    public partial class Domains : Form
    {
        object[] obj = new object[]
        {
            Color.AliceBlue,
            Color.Aqua,
            Color.BlueViolet,
            Color.DarkSeaGreen,
            Color.DeepSkyBlue,
            Color.Violet,
            Color.Tomato,
            Color.Teal,
            Color.Thistle,
            Color.Tan,
            Color.Snow,
            Color.SlateBlue,
            Color.Silver,
            Color.SeaGreen,
            Color.Salmon
        };


        public Domains()
        {
            InitializeComponent();
            clbDomains.Items.AddRange(obj);          
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
    }
}
