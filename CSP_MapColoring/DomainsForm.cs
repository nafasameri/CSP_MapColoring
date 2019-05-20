using System;
using System.Collections.Generic;
using System.Drawing;
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
            Color.Crimson,

            Color.MediumPurple,
            Color.MediumSeaGreen,
            Color.MediumSlateBlue,
            Color.MediumSpringGreen,
            Color.MediumTurquoise,
            Color.MediumOrchid,
            Color.MintCream,
            Color.Moccasin,
            Color.NavajoWhite,
            Color.Navy,
            Color.OldLace,
            Color.OliveDrab,
            Color.Orange,
            Color.MistyRose,
            Color.OrangeRed,
            Color.MediumBlue,
            Color.Maroon,
            Color.LightBlue,
            Color.LightCoral,
            Color.LightGoldenrodYellow,
            Color.LightGreen,
            Color.LightGray,
            Color.LightPink,
            Color.LightSalmon,
            Color.MediumAquamarine,
            Color.LightSeaGreen,
            Color.LightSlateGray,
            Color.LightSteelBlue,
            Color.LightYellow,
            Color.LimeGreen,
            Color.Linen,
            Color.Magenta,
            Color.LightSkyBlue,
            Color.LemonChiffon,
            Color.Orchid,
            Color.SlateBlue,
            Color.SlateGray,
            Color.SpringGreen,
            Color.SteelBlue,
            Color.Tan,
            Color.Teal,
            Color.SkyBlue,
            Color.Thistle,
            Color.Turquoise,
            Color.Wheat,
            Color.WhiteSmoke,
            Color.Yellow,
            Color.YellowGreen,
            Color.PaleGoldenrod,
            Color.Silver,
            Color.SeaShell,
            Color.PaleVioletRed,
            Color.PapayaWhip,
            Color.PeachPuff,
            Color.Peru,
            Color.Pink,
            Color.Plum,
            Color.Sienna,
            Color.PowderBlue,
            Color.Red,
            Color.RosyBrown,
            Color.RoyalBlue,
            Color.SaddleBrown,
            Color.Salmon,
            Color.SandyBrown,
            Color.SeaGreen,
            Color.Purple,
            Color.LawnGreen,
            Color.LightCyan,
            Color.Lavender,
            Color.DarkGreen,
            Color.DarkGray,
            Color.DarkGoldenrod,
            Color.DarkCyan,
            Color.DarkBlue,
            Color.Cyan,
            Color.Cornsilk,
            Color.LavenderBlush,
            Color.Coral,
            Color.Chocolate,
            Color.Chartreuse,
            Color.DarkMagenta,
            Color.CadetBlue,
            Color.Brown,
            Color.BlueViolet,
            Color.Blue,
            Color.BlanchedAlmond,
            Color.Beige,
            Color.Azure,
            Color.Aquamarine,
            Color.Aqua,
            Color.AntiqueWhite,
            Color.AliceBlue,
            Color.Transparent,
            Color.BurlyWood,
            Color.DarkOliveGreen,
            Color.CornflowerBlue,
            Color.DarkOrchid,
            Color.Ivory,
            Color.DarkOrange,
            Color.Indigo,
            Color.HotPink,
            Color.Honeydew,
            Color.GreenYellow,
            Color.Green,
            Color.Gray,
            Color.Goldenrod,
            Color.GhostWhite,
            Color.Gainsboro,
            Color.Fuchsia,
            Color.FloralWhite,
            Color.DarkRed,
            Color.DarkSalmon,
            Color.DarkSeaGreen,
            Color.ForestGreen,
            Color.DarkSlateGray,
            Color.DarkTurquoise,
            Color.DarkSlateBlue,
            Color.DeepSkyBlue,
            Color.DimGray,
            Color.DodgerBlue,
            Color.Firebrick,
            Color.DarkViolet
        };

        public DomainsForm()
        {
            InitializeComponent();
        }

        public List<Color> retItems()
        {
            List<Color> list = new List<Color>();
            for (int i = 0; i < obj.Length; i++)
                if (clbDomains.GetItemCheckState(i) == CheckState.Checked)
                    list.Add((Color)clbDomains.Items[i]);
            return list;
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
                //clbDomains.SetItemCheckState(i, CheckState.Checked);
            }
        }
    }
}
